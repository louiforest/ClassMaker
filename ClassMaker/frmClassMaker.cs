using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassMaker
{
    public partial class frmClassMaker : Form
    {
        public frmClassMaker()
        {
            InitializeComponent();

            InitEventHandler();
            InitDGVUsing();
        }

        private void InitEventHandler()
        {
            bSelectSql.Click += SelectSqlFile;
            bGenerate.Click += Generate;
            cbAddSelectAll.Click += CbAddSelectAll_Click;
        }

        private void CbAddSelectAll_Click(object sender, EventArgs e)
        {
            if (cbAddSelectAll.Checked && !cbAddGenerateRecord.Checked)
                cbAddGenerateRecord.Checked = true;
        }

        private void InitDGVUsing()
        {
            string[] Data;

            dgvUsing.Columns.Clear();
            dgvUsing.Rows.Clear();

            dgvUsing.Columns.Add("Declarations", "Using Declarations");

            foreach (string itm in GenerateDefaultUsing())
            {
                Data = new string[1];
                Data[0] = itm;

                dgvUsing.Rows.Add(Data);
            }
        }

        private List<string> GenerateDefaultUsing()
        {
            List<string> Usings = new List<string>();

            Usings.Add("using System;");
            Usings.Add("using System.Collections.Generic;");
            Usings.Add("using MySql.Data;");
            Usings.Add("using MySql.Data.MySqlClient;");

            return Usings;
        }

        private void SelectSqlFile(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();

            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                tbSqlFile.Text = dialog.FileName;
                bGenerate.Enabled = true;
            }            
        }

        private void Generate(object sender, EventArgs e)
        {
            List<CSqlTable> tables = CSqlTable.ReadSqlFile(tbSqlFile.Text);

            if (tables != null && tables.Count > 0)
            {
                if (cbPropertyTxt.Checked)
                    GeneratePropertiesText(tables);
                if (cbGenerateCs.Checked)
                    GenerateClassFiles(tables);
            }
        }

        private void AddGenerateRecords(CSqlTable tbl, System.IO.StreamWriter fWrite)
        {
            string ClassName = string.Empty;
            string PluralClassName = string.Empty;
            string STab = "    ";
            string Q = '"'.ToString();

            if (tbl.TableName.EndsWith("s"))
                ClassName = tbClassPrefix.Text + tbl.TableName.Substring(0, tbl.TableName.Length - 1);
            else
                ClassName = tbClassPrefix.Text + tbl.TableName;

            PluralClassName = ClassName + "s";

            fWrite.WriteLine(STab + STab +"private static " + PluralClassName + " GenerateRecords(CDBReader reader, object argument)");
            fWrite.WriteLine(STab + STab + "{");
            fWrite.WriteLine(STab + STab + STab + PluralClassName + " records = new " + PluralClassName + "();");
            fWrite.WriteLine(STab + STab + STab + ClassName + " rec;");
            fWrite.WriteLine(STab + STab + STab + "string StringArgument = (string)argument;");
            fWrite.WriteLine("");
            fWrite.WriteLine(STab + STab + STab + "while (reader.Read())");
            fWrite.WriteLine(STab + STab + STab + "{");
            fWrite.WriteLine(STab + STab + STab + STab + "rec = new " + ClassName + "();");
            fWrite.WriteLine("");

            foreach (CSqlItem itm in tbl.fields)
            {
                switch (itm.DataType)
                {
                    case enumDataType.Astring:
                        fWrite.WriteLine(STab + STab + STab + STab + "rec." + itm.Name + " = reader.GetString(" + Q + itm.Name + Q + ");");                
                        break;
                    case enumDataType.Aint:
                        fWrite.WriteLine(STab + STab + STab + STab + "rec." + itm.Name + " = reader.GetInt32(" + Q + itm.Name + Q + ");");
                        break;
                    case enumDataType.Adouble:
                        fWrite.WriteLine(STab + STab + STab + STab + "rec." + itm.Name + " = reader.GetDouble(" + Q + itm.Name + Q + ");");
                        break;
                    case enumDataType.Afloat:
                        fWrite.WriteLine(STab + STab + STab + STab + "rec." + itm.Name + " = reader.GetFloat(" + Q + itm.Name + Q + ");");
                        break;
                    case enumDataType.ADateTime:
                        fWrite.WriteLine(STab + STab + STab + STab + "rec." + itm.Name + " = reader.GetDateTime(" + Q + itm.Name + Q + ");");
                        break;
                    case enumDataType.Invalid:    
                    case enumDataType.Undefined:
                        default:
                        break;
                }
                
            }

            fWrite.WriteLine("");
            fWrite.WriteLine(STab + STab + STab + STab + "records.Add(rec);");
            fWrite.WriteLine(STab + STab + STab + "}");
            //fWrite.WriteLine(STab + STab + STab + "reader.Close();");
            //fWrite.WriteLine("");
            fWrite.WriteLine(STab + STab + STab + "return records;");
            fWrite.WriteLine(STab + STab + "}");
        }

        private void AddSelectAll(CSqlTable tbl, System.IO.StreamWriter fWrite, string PluralClassName)
        {
            string STab = "    ";
            string Guil = '"'.ToString();

            fWrite.WriteLine(STab + STab + "public static " + tbClassPrefix.Text + PluralClassName + " SelectAll()");
            fWrite.WriteLine(STab + STab + "{");

            fWrite.WriteLine(STab + STab + STab + tbClassPrefix.Text + PluralClassName + " response;");
            fWrite.WriteLine(STab + STab + STab + "string Sql = string.Empty;");
            fWrite.WriteLine("");
            fWrite.WriteLine(STab + STab + STab + "Sql += " + Guil + "SELECT *" + Guil + " + Environment.NewLine;");
            fWrite.WriteLine(STab + STab + STab + "Sql += " + Guil + " FROM " + tbl.TableName + Guil + " + Environment.NewLine;");
            fWrite.WriteLine("");
            fWrite.WriteLine(STab + STab + STab + "CDBCommand cmd = new CDBCommand(CDBConnection.Instance(), Sql);");
            fWrite.WriteLine(STab + STab + STab + "CDBReader reader = cmd.ExecuteQuery();");
            fWrite.WriteLine("");
            fWrite.WriteLine(STab + STab + STab + "response = GenerateRecords(reader, string.Empty);");
            fWrite.WriteLine(STab + STab + STab + "if (response == null || response.Count == 0)");
            fWrite.WriteLine(STab + STab + STab + STab + "return null;");
            fWrite.WriteLine("");
            fWrite.WriteLine(STab + STab + STab + "return response;");

            fWrite.WriteLine(STab + STab + "}");
        }

        private void GenerateClassFiles(List<CSqlTable> tables)
        {
            string SingleClassName = string.Empty;
            string PluralClassName = string.Empty;
            string OutputFileName = string.Empty;
            string STab = "    ";

            foreach (CSqlTable tbl in tables)
            {
                if (tbl.TableName.ToLower().EndsWith("s"))
                {
                    PluralClassName = tbl.TableName;
                    SingleClassName = PluralClassName.Substring(0, PluralClassName.Length - 1);
                }
                else
                {
                    SingleClassName = tbl.TableName;
                    PluralClassName = SingleClassName + "s";
                }                
                
                OutputFileName = tbClassPrefix.Text + tbl.TableName + ".cs";
                using (System.IO.StreamWriter fWrite = new System.IO.StreamWriter(OutputFileName, false))
                {
                    foreach (string UsingLine in GrabUsings())
                        fWrite.WriteLine(UsingLine);

                    fWrite.WriteLine(string.Empty);
                    fWrite.WriteLine("namespace " + tbNameSpace.Text);
                    fWrite.WriteLine("{");

                    if (string.IsNullOrEmpty(tbInhirits.Text))
                        fWrite.WriteLine(STab + tbClassModifiers.Text + " class " + tbClassPrefix.Text + SingleClassName);
                    else
                        fWrite.WriteLine(STab + tbClassModifiers.Text + " class " + tbClassPrefix.Text + SingleClassName + " : " +tbInhirits.Text);

                    fWrite.WriteLine(STab + "{");

                    if (cbRegion.Checked)
                        fWrite.WriteLine(STab + STab + "#region Properties");

                    foreach (CSqlItem itm in tbl.fields)
                        fWrite.WriteLine(STab + STab + "private " + itm.DataTypeToString + " " + tbPrivatePrefix.Text + itm.Name + itm.PrivateInitiator);

                    fWrite.WriteLine(string.Empty);

                    foreach (CSqlItem itm in tbl.fields)
                    {
                        if (rbGet.Checked)
                            fWrite.WriteLine(STab + STab + "public " + itm.DataTypeToString + " " + itm.Name + " { get { return " + tbPrivatePrefix.Text + itm.Name + "; } }");
                        else if (rbSet.Checked)
                            fWrite.WriteLine(STab + STab + "public " + itm.DataTypeToString + " " + itm.Name + " { set { " + tbPrivatePrefix.Text + itm.Name + " = value; } }");
                        else
                            fWrite.WriteLine(STab + STab + "public " + itm.DataTypeToString + " " + itm.Name + " { get { return " + tbPrivatePrefix.Text + itm.Name + "; } set { " + tbPrivatePrefix.Text + itm.Name + " = value; } }");
                    }

                    if (cbRegion.Checked)
                    {
                        fWrite.WriteLine(STab + STab + "#endregion");
                        fWrite.WriteLine(string.Empty);
                        fWrite.WriteLine(STab + STab + "#region DataBaseNonQuery");
                        fWrite.WriteLine(STab + STab + "#endregion");
                        fWrite.WriteLine(string.Empty);
                        fWrite.WriteLine(STab + STab + "#region OtherMethods");
                        fWrite.WriteLine(STab + STab + "#endregion");
                        fWrite.WriteLine(string.Empty);
                    }

                    if (cbRegion.Checked)
                        fWrite.WriteLine(STab + STab + "#region DataBaseQuery");

                    if (cbAddGenerateRecord.Checked && cbAddSelectAll.Checked)
                        AddSelectAll(tbl, fWrite, PluralClassName);

                    if (cbAddGenerateRecord.Checked)
                        AddGenerateRecords(tbl, fWrite);

                    if (cbRegion.Checked)
                        fWrite.WriteLine(STab + STab + "#endregion");

                    fWrite.WriteLine(STab + "}");

                    if (cbGeneratePlural.Checked)
                    {
                        fWrite.WriteLine(STab + tbClassModifiers.Text + " class " + tbClassPrefix.Text + PluralClassName + " : List<" + tbClassPrefix.Text + SingleClassName + ">");
                        fWrite.WriteLine(STab + "{");
                        fWrite.WriteLine(STab + "}");
                    }

                    fWrite.WriteLine("}");
                }       
            }
        }

        private List<string> GrabUsings()
        {
            List<string> UsingLines = new List<string>();

            for (int iUsing = 0; iUsing < dgvUsing.Rows.Count - 1; iUsing++)
            {
                UsingLines.Add(dgvUsing[0, iUsing].Value.ToString());
            }

            return UsingLines;
        }

        private void GeneratePropertiesText(List<CSqlTable> tables)
        {
            string OutputFileName = "Properties.txt";

            using (System.IO.StreamWriter fWrite = new System.IO.StreamWriter(OutputFileName, false))
            {
                foreach (CSqlTable tbl in tables)
                {
                    fWrite.WriteLine(@"//" + tbClassModifiers.Text + " class " + tbClassPrefix.Text + tbl.TableName);
                    fWrite.WriteLine(string.Empty);

                    if (cbRegion.Checked)
                        fWrite.WriteLine("#region Properties");

                    foreach (CSqlItem itm in tbl.fields)
                        fWrite.WriteLine("private " + itm.DataTypeToString + " " + tbPrivatePrefix.Text + itm.Name + itm.PrivateInitiator);

                    fWrite.WriteLine(string.Empty);

                    foreach (CSqlItem itm in tbl.fields)
                    {
                        if (rbGet.Checked)
                            fWrite.WriteLine("public " + itm.DataTypeToString + " " + itm.Name + " { get { return " + tbPrivatePrefix.Text + itm.Name + "; } }");
                        else if (rbSet.Checked)
                            fWrite.WriteLine("public " + itm.DataTypeToString + " " + itm.Name + " { set { " + tbPrivatePrefix.Text + itm.Name + " = value; } }");
                        else
                            fWrite.WriteLine("public " + itm.DataTypeToString + " " + itm.Name + " { get { return " + tbPrivatePrefix.Text + itm.Name + "; } set { " + tbPrivatePrefix.Text + itm.Name + " = value; } }");
                    }

                    if (cbRegion.Checked)
                        fWrite.WriteLine("#endregion");

                    fWrite.WriteLine(string.Empty);
                    fWrite.WriteLine(string.Empty);
                }
            }
        }

        
    }
}

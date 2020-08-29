using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMaker
{
    public class CSqlTable
    {
        private string _TableName = string.Empty;
        private List<CSqlItem> _fields = new List<CSqlItem>();

        public string TableName { get { return _TableName; } set { _TableName = value; } }
        public List<CSqlItem> fields { get { return _fields; } set { _fields = value; } }

        public static List<CSqlTable> ReadSqlFile(string FileName)
        {
            List<CSqlTable> result = new List<CSqlTable>();
            CSqlTable table = new CSqlTable();
            CSqlItem sqlItem = new CSqlItem();
            string[] SplitString;
            string TableBeginMarker = "create table";
            string TableName = string.Empty;
            string Line = string.Empty;
            bool NowReadingTableDefinition = false;
            bool NowWaitingForParenthesis = false;

            if (string.IsNullOrEmpty(FileName))
                return null;
            if (!System.IO.File.Exists(FileName))
                return null;

            using (System.IO.StreamReader fRead = new System.IO.StreamReader(FileName))
            {
                while (fRead.Peek() > -1)
                {
                    Line = fRead.ReadLine();

                    if (Line.ToLower().Contains(TableBeginMarker))
                    {
                        TableName = string.Empty;

                        SplitString = Line.Split(' ');
                        foreach (string itm in SplitString)
                        {
                            if (itm.ToLower() != "create" && itm.ToLower() != "table" && string.IsNullOrEmpty(TableName))
                                TableName = itm.Replace("{", "");
                        }

                        if (!string.IsNullOrEmpty(TableName))
                        {
                            table = new CSqlTable();
                            table.TableName = TableName;

                            if (Line.Contains("("))
                                NowReadingTableDefinition = true;
                            else
                                NowWaitingForParenthesis = true;
                        }
                    }
                    else if (NowWaitingForParenthesis && Line.Contains("("))
                    {
                        NowWaitingForParenthesis = false;
                        NowReadingTableDefinition = true;
                    }
                    else if (NowReadingTableDefinition)
                    {
                        sqlItem = new CSqlItem(Line);

                        if (sqlItem != null && sqlItem.DataType != enumDataType.Invalid && sqlItem.DataType != enumDataType.Undefined)
                            table.fields.Add(sqlItem);

                        if (Line.Contains(";"))
                        {
                            result.Add(table);

                            NowReadingTableDefinition = false;
                            NowWaitingForParenthesis = false;
                        }
                    }                   
                }
            }

            return result;
        }
    }
}

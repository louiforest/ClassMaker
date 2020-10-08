namespace ClassMaker
{
    partial class frmClassMaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bSelectSql = new System.Windows.Forms.Button();
            this.tbSqlFile = new System.Windows.Forms.TextBox();
            this.cbGenerateCs = new System.Windows.Forms.CheckBox();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cbGeneratePlural = new System.Windows.Forms.CheckBox();
            this.cbAddGenerateRecord = new System.Windows.Forms.CheckBox();
            this.tbInhirits = new System.Windows.Forms.TextBox();
            this.lInhirits = new System.Windows.Forms.Label();
            this.tbClassModifiers = new System.Windows.Forms.TextBox();
            this.lClassModifiers = new System.Windows.Forms.Label();
            this.tbNameSpace = new System.Windows.Forms.TextBox();
            this.lNameSpace = new System.Windows.Forms.Label();
            this.tbClassPrefix = new System.Windows.Forms.TextBox();
            this.lClassPrefix = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.CheckBox();
            this.rbSet = new System.Windows.Forms.RadioButton();
            this.rbGet = new System.Windows.Forms.RadioButton();
            this.rbGetSet = new System.Windows.Forms.RadioButton();
            this.tbPrivatePrefix = new System.Windows.Forms.TextBox();
            this.lPrivatePrefix = new System.Windows.Forms.Label();
            this.cbPropertyTxt = new System.Windows.Forms.CheckBox();
            this.bGenerate = new System.Windows.Forms.Button();
            this.dgvUsing = new System.Windows.Forms.DataGridView();
            this.lUsing = new System.Windows.Forms.Label();
            this.cbAddSelectAll = new System.Windows.Forms.CheckBox();
            this.cbUserPrivates = new System.Windows.Forms.CheckBox();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsing)).BeginInit();
            this.SuspendLayout();
            // 
            // bSelectSql
            // 
            this.bSelectSql.Location = new System.Drawing.Point(12, 12);
            this.bSelectSql.Name = "bSelectSql";
            this.bSelectSql.Size = new System.Drawing.Size(117, 23);
            this.bSelectSql.TabIndex = 0;
            this.bSelectSql.Text = "Select SQL File";
            this.bSelectSql.UseVisualStyleBackColor = true;
            // 
            // tbSqlFile
            // 
            this.tbSqlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSqlFile.Enabled = false;
            this.tbSqlFile.Location = new System.Drawing.Point(135, 14);
            this.tbSqlFile.Name = "tbSqlFile";
            this.tbSqlFile.Size = new System.Drawing.Size(599, 20);
            this.tbSqlFile.TabIndex = 1;
            // 
            // cbGenerateCs
            // 
            this.cbGenerateCs.AutoSize = true;
            this.cbGenerateCs.Location = new System.Drawing.Point(6, 19);
            this.cbGenerateCs.Name = "cbGenerateCs";
            this.cbGenerateCs.Size = new System.Drawing.Size(108, 17);
            this.cbGenerateCs.TabIndex = 2;
            this.cbGenerateCs.Text = "Generate .cs files";
            this.cbGenerateCs.UseVisualStyleBackColor = true;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.cbUserPrivates);
            this.gbOptions.Controls.Add(this.cbGeneratePlural);
            this.gbOptions.Controls.Add(this.cbAddGenerateRecord);
            this.gbOptions.Controls.Add(this.tbInhirits);
            this.gbOptions.Controls.Add(this.lInhirits);
            this.gbOptions.Controls.Add(this.tbClassModifiers);
            this.gbOptions.Controls.Add(this.lClassModifiers);
            this.gbOptions.Controls.Add(this.tbNameSpace);
            this.gbOptions.Controls.Add(this.lNameSpace);
            this.gbOptions.Controls.Add(this.tbClassPrefix);
            this.gbOptions.Controls.Add(this.lClassPrefix);
            this.gbOptions.Controls.Add(this.cbRegion);
            this.gbOptions.Controls.Add(this.rbSet);
            this.gbOptions.Controls.Add(this.rbGet);
            this.gbOptions.Controls.Add(this.rbGetSet);
            this.gbOptions.Controls.Add(this.tbPrivatePrefix);
            this.gbOptions.Controls.Add(this.lPrivatePrefix);
            this.gbOptions.Controls.Add(this.cbPropertyTxt);
            this.gbOptions.Controls.Add(this.cbGenerateCs);
            this.gbOptions.Location = new System.Drawing.Point(12, 40);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(342, 270);
            this.gbOptions.TabIndex = 3;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // cbGeneratePlural
            // 
            this.cbGeneratePlural.AutoSize = true;
            this.cbGeneratePlural.Location = new System.Drawing.Point(115, 19);
            this.cbGeneratePlural.Name = "cbGeneratePlural";
            this.cbGeneratePlural.Size = new System.Drawing.Size(127, 17);
            this.cbGeneratePlural.TabIndex = 19;
            this.cbGeneratePlural.Text = "Generate Plural Class";
            this.cbGeneratePlural.UseVisualStyleBackColor = true;
            // 
            // cbAddGenerateRecord
            // 
            this.cbAddGenerateRecord.AutoSize = true;
            this.cbAddGenerateRecord.Location = new System.Drawing.Point(96, 114);
            this.cbAddGenerateRecord.Name = "cbAddGenerateRecord";
            this.cbAddGenerateRecord.Size = new System.Drawing.Size(127, 17);
            this.cbAddGenerateRecord.TabIndex = 18;
            this.cbAddGenerateRecord.Text = "Add GenerateRecord";
            this.cbAddGenerateRecord.UseVisualStyleBackColor = true;
            // 
            // tbInhirits
            // 
            this.tbInhirits.Location = new System.Drawing.Point(90, 244);
            this.tbInhirits.Name = "tbInhirits";
            this.tbInhirits.Size = new System.Drawing.Size(246, 20);
            this.tbInhirits.TabIndex = 17;
            // 
            // lInhirits
            // 
            this.lInhirits.AutoSize = true;
            this.lInhirits.Location = new System.Drawing.Point(7, 247);
            this.lInhirits.Name = "lInhirits";
            this.lInhirits.Size = new System.Drawing.Size(37, 13);
            this.lInhirits.TabIndex = 16;
            this.lInhirits.Text = "Inhirits";
            // 
            // tbClassModifiers
            // 
            this.tbClassModifiers.Location = new System.Drawing.Point(90, 218);
            this.tbClassModifiers.Name = "tbClassModifiers";
            this.tbClassModifiers.Size = new System.Drawing.Size(246, 20);
            this.tbClassModifiers.TabIndex = 15;
            this.tbClassModifiers.Text = "public";
            // 
            // lClassModifiers
            // 
            this.lClassModifiers.AutoSize = true;
            this.lClassModifiers.Location = new System.Drawing.Point(7, 221);
            this.lClassModifiers.Name = "lClassModifiers";
            this.lClassModifiers.Size = new System.Drawing.Size(77, 13);
            this.lClassModifiers.TabIndex = 14;
            this.lClassModifiers.Text = "Class Modifiers";
            // 
            // tbNameSpace
            // 
            this.tbNameSpace.Location = new System.Drawing.Point(90, 192);
            this.tbNameSpace.Name = "tbNameSpace";
            this.tbNameSpace.Size = new System.Drawing.Size(246, 20);
            this.tbNameSpace.TabIndex = 13;
            this.tbNameSpace.Text = "ClassMaker";
            // 
            // lNameSpace
            // 
            this.lNameSpace.AutoSize = true;
            this.lNameSpace.Location = new System.Drawing.Point(7, 195);
            this.lNameSpace.Name = "lNameSpace";
            this.lNameSpace.Size = new System.Drawing.Size(69, 13);
            this.lNameSpace.TabIndex = 12;
            this.lNameSpace.Text = "Name Space";
            // 
            // tbClassPrefix
            // 
            this.tbClassPrefix.Location = new System.Drawing.Point(90, 166);
            this.tbClassPrefix.Name = "tbClassPrefix";
            this.tbClassPrefix.Size = new System.Drawing.Size(53, 20);
            this.tbClassPrefix.TabIndex = 11;
            this.tbClassPrefix.Text = "C";
            // 
            // lClassPrefix
            // 
            this.lClassPrefix.AutoSize = true;
            this.lClassPrefix.Location = new System.Drawing.Point(7, 169);
            this.lClassPrefix.Name = "lClassPrefix";
            this.lClassPrefix.Size = new System.Drawing.Size(61, 13);
            this.lClassPrefix.TabIndex = 10;
            this.lClassPrefix.Text = "Class Prefix";
            // 
            // cbRegion
            // 
            this.cbRegion.AutoSize = true;
            this.cbRegion.Location = new System.Drawing.Point(6, 114);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(84, 17);
            this.cbRegion.TabIndex = 9;
            this.cbRegion.Text = "Add #region";
            this.cbRegion.UseVisualStyleBackColor = true;
            // 
            // rbSet
            // 
            this.rbSet.AutoSize = true;
            this.rbSet.Location = new System.Drawing.Point(118, 91);
            this.rbSet.Name = "rbSet";
            this.rbSet.Size = new System.Drawing.Size(41, 17);
            this.rbSet.TabIndex = 8;
            this.rbSet.Text = "Set";
            this.rbSet.UseVisualStyleBackColor = true;
            // 
            // rbGet
            // 
            this.rbGet.AutoSize = true;
            this.rbGet.Location = new System.Drawing.Point(70, 91);
            this.rbGet.Name = "rbGet";
            this.rbGet.Size = new System.Drawing.Size(42, 17);
            this.rbGet.TabIndex = 7;
            this.rbGet.Text = "Get";
            this.rbGet.UseVisualStyleBackColor = true;
            // 
            // rbGetSet
            // 
            this.rbGetSet.AutoSize = true;
            this.rbGetSet.Checked = true;
            this.rbGetSet.Location = new System.Drawing.Point(6, 91);
            this.rbGetSet.Name = "rbGetSet";
            this.rbGetSet.Size = new System.Drawing.Size(58, 17);
            this.rbGetSet.TabIndex = 6;
            this.rbGetSet.TabStop = true;
            this.rbGetSet.Text = "GetSet";
            this.rbGetSet.UseVisualStyleBackColor = true;
            // 
            // tbPrivatePrefix
            // 
            this.tbPrivatePrefix.Location = new System.Drawing.Point(90, 63);
            this.tbPrivatePrefix.Name = "tbPrivatePrefix";
            this.tbPrivatePrefix.Size = new System.Drawing.Size(53, 20);
            this.tbPrivatePrefix.TabIndex = 5;
            this.tbPrivatePrefix.Text = "_";
            // 
            // lPrivatePrefix
            // 
            this.lPrivatePrefix.AutoSize = true;
            this.lPrivatePrefix.Location = new System.Drawing.Point(7, 66);
            this.lPrivatePrefix.Name = "lPrivatePrefix";
            this.lPrivatePrefix.Size = new System.Drawing.Size(69, 13);
            this.lPrivatePrefix.TabIndex = 4;
            this.lPrivatePrefix.Text = "Private Prefix";
            // 
            // cbPropertyTxt
            // 
            this.cbPropertyTxt.AutoSize = true;
            this.cbPropertyTxt.Location = new System.Drawing.Point(6, 42);
            this.cbPropertyTxt.Name = "cbPropertyTxt";
            this.cbPropertyTxt.Size = new System.Drawing.Size(147, 17);
            this.cbPropertyTxt.TabIndex = 3;
            this.cbPropertyTxt.Text = "Generate property text file";
            this.cbPropertyTxt.UseVisualStyleBackColor = true;
            // 
            // bGenerate
            // 
            this.bGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bGenerate.Enabled = false;
            this.bGenerate.Location = new System.Drawing.Point(617, 291);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(117, 23);
            this.bGenerate.TabIndex = 4;
            this.bGenerate.Text = "Generate";
            this.bGenerate.UseVisualStyleBackColor = true;
            // 
            // dgvUsing
            // 
            this.dgvUsing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsing.Location = new System.Drawing.Point(363, 69);
            this.dgvUsing.Name = "dgvUsing";
            this.dgvUsing.Size = new System.Drawing.Size(371, 216);
            this.dgvUsing.TabIndex = 5;
            // 
            // lUsing
            // 
            this.lUsing.AutoSize = true;
            this.lUsing.Location = new System.Drawing.Point(360, 53);
            this.lUsing.Name = "lUsing";
            this.lUsing.Size = new System.Drawing.Size(69, 13);
            this.lUsing.TabIndex = 18;
            this.lUsing.Text = "Private Prefix";
            // 
            // cbAddSelectAll
            // 
            this.cbAddSelectAll.AutoSize = true;
            this.cbAddSelectAll.Location = new System.Drawing.Point(241, 154);
            this.cbAddSelectAll.Name = "cbAddSelectAll";
            this.cbAddSelectAll.Size = new System.Drawing.Size(89, 17);
            this.cbAddSelectAll.TabIndex = 20;
            this.cbAddSelectAll.Text = "Add SelectAll";
            this.cbAddSelectAll.UseVisualStyleBackColor = true;
            // 
            // cbUserPrivates
            // 
            this.cbUserPrivates.AutoSize = true;
            this.cbUserPrivates.Location = new System.Drawing.Point(96, 137);
            this.cbUserPrivates.Name = "cbUserPrivates";
            this.cbUserPrivates.Size = new System.Drawing.Size(181, 17);
            this.cbUserPrivates.TabIndex = 20;
            this.cbUserPrivates.Text = "Use privates in Generate Record";
            this.cbUserPrivates.UseVisualStyleBackColor = true;
            // 
            // frmClassMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 322);
            this.Controls.Add(this.cbAddSelectAll);
            this.Controls.Add(this.lUsing);
            this.Controls.Add(this.dgvUsing);
            this.Controls.Add(this.bGenerate);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.tbSqlFile);
            this.Controls.Add(this.bSelectSql);
            this.Name = "frmClassMaker";
            this.Text = "Class Maker";
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSelectSql;
        private System.Windows.Forms.TextBox tbSqlFile;
        private System.Windows.Forms.CheckBox cbGenerateCs;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox cbRegion;
        private System.Windows.Forms.RadioButton rbSet;
        private System.Windows.Forms.RadioButton rbGet;
        private System.Windows.Forms.RadioButton rbGetSet;
        private System.Windows.Forms.TextBox tbPrivatePrefix;
        private System.Windows.Forms.Label lPrivatePrefix;
        private System.Windows.Forms.CheckBox cbPropertyTxt;
        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.TextBox tbClassPrefix;
        private System.Windows.Forms.Label lClassPrefix;
        private System.Windows.Forms.TextBox tbNameSpace;
        private System.Windows.Forms.Label lNameSpace;
        private System.Windows.Forms.TextBox tbClassModifiers;
        private System.Windows.Forms.Label lClassModifiers;
        private System.Windows.Forms.TextBox tbInhirits;
        private System.Windows.Forms.Label lInhirits;
        private System.Windows.Forms.DataGridView dgvUsing;
        private System.Windows.Forms.Label lUsing;
        private System.Windows.Forms.CheckBox cbAddGenerateRecord;
        private System.Windows.Forms.CheckBox cbGeneratePlural;
        private System.Windows.Forms.CheckBox cbAddSelectAll;
        private System.Windows.Forms.CheckBox cbUserPrivates;
    }
}


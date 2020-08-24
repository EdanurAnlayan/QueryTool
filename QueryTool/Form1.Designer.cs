namespace QueryTool
{
    partial class Form1
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
            this.ListOfMuseum = new System.Windows.Forms.CheckedListBox();
            this.Query = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GetQuery = new System.Windows.Forms.Button();
            this.LimitBox = new System.Windows.Forms.CheckedListBox();
            this.saveDocument = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListOfMuseum
            // 
            this.ListOfMuseum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListOfMuseum.CheckOnClick = true;
            this.ListOfMuseum.FormattingEnabled = true;
            this.ListOfMuseum.Location = new System.Drawing.Point(12, 12);
            this.ListOfMuseum.Name = "ListOfMuseum";
            this.ListOfMuseum.Size = new System.Drawing.Size(149, 469);
            this.ListOfMuseum.TabIndex = 0;
            this.ListOfMuseum.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListOfMuseum_ItemCheck);
            // 
            // Query
            // 
            this.Query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Query.Location = new System.Drawing.Point(167, 12);
            this.Query.Multiline = true;
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(737, 79);
            this.Query.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(167, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(886, 331);
            this.dataGridView1.TabIndex = 3;
            // 
            // GetQuery
            // 
            this.GetQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GetQuery.Location = new System.Drawing.Point(954, 109);
            this.GetQuery.Name = "GetQuery";
            this.GetQuery.Size = new System.Drawing.Size(99, 35);
            this.GetQuery.TabIndex = 4;
            this.GetQuery.Text = "Submit Query";
            this.GetQuery.UseVisualStyleBackColor = true;
            this.GetQuery.Click += new System.EventHandler(this.GetQuery_Click);
            // 
            // LimitBox
            // 
            this.LimitBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LimitBox.CheckOnClick = true;
            this.LimitBox.FormattingEnabled = true;
            this.LimitBox.Items.AddRange(new object[] {
            "50",
            "100",
            "1000",
            "1500",
            "Tümü"});
            this.LimitBox.Location = new System.Drawing.Point(910, 12);
            this.LimitBox.Name = "LimitBox";
            this.LimitBox.Size = new System.Drawing.Size(143, 79);
            this.LimitBox.TabIndex = 6;
            this.LimitBox.SelectedIndexChanged += new System.EventHandler(this.LimitBox_SelectedIndexChanged);
            // 
            // saveDocument
            // 
            this.saveDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDocument.Location = new System.Drawing.Point(954, 487);
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Size = new System.Drawing.Size(99, 35);
            this.saveDocument.TabIndex = 7;
            this.saveDocument.Text = "Save Document";
            this.saveDocument.UseVisualStyleBackColor = true;
            this.saveDocument.Click += new System.EventHandler(this.saveDocument_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "List Of Museums";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(177, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Qury Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(910, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selected Limits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(177, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Query List";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 542);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveDocument);
            this.Controls.Add(this.LimitBox);
            this.Controls.Add(this.GetQuery);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Query);
            this.Controls.Add(this.ListOfMuseum);
            this.Name = "Form1";
            this.Text = "Museum Sql Adapter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ListOfMuseum;
        private System.Windows.Forms.TextBox Query;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button GetQuery;
        private System.Windows.Forms.CheckedListBox LimitBox;
        private System.Windows.Forms.Button saveDocument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}


namespace lab_1
{
    partial class MainBankForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SortByName = new System.Windows.Forms.Button();
            this.SortByCard = new System.Windows.Forms.Button();
            this.SortByAge = new System.Windows.Forms.Button();
            this.sortType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(227, 187);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(417, 124);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 439);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(391, 439);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(559, 439);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(402, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bank";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SortByName
            // 
            this.SortByName.Location = new System.Drawing.Point(227, 358);
            this.SortByName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SortByName.Name = "SortByName";
            this.SortByName.Size = new System.Drawing.Size(86, 51);
            this.SortByName.TabIndex = 5;
            this.SortByName.Text = "Sort by name";
            this.SortByName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SortByName.UseVisualStyleBackColor = false;
            this.SortByName.Click += new System.EventHandler(this.SortByName_Click);
            // 
            // SortByCard
            // 
            this.SortByCard.Location = new System.Drawing.Point(391, 358);
            this.SortByCard.Name = "SortByCard";
            this.SortByCard.Size = new System.Drawing.Size(86, 51);
            this.SortByCard.TabIndex = 6;
            this.SortByCard.Text = "Sort by card";
            this.SortByCard.UseVisualStyleBackColor = false;
            this.SortByCard.Click += new System.EventHandler(this.SortByCard_Click);
            // 
            // SortByAge
            // 
            this.SortByAge.Location = new System.Drawing.Point(559, 358);
            this.SortByAge.Name = "SortByAge";
            this.SortByAge.Size = new System.Drawing.Size(85, 51);
            this.SortByAge.TabIndex = 7;
            this.SortByAge.Text = "Sort by age";
            this.SortByAge.UseVisualStyleBackColor = false;
            this.SortByAge.Click += new System.EventHandler(this.SortByAge_Click);
            // 
            // sortType
            // 
            this.sortType.FormattingEnabled = true;
            this.sortType.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
            this.sortType.Location = new System.Drawing.Point(355, 324);
            this.sortType.Name = "sortType";
            this.sortType.Size = new System.Drawing.Size(151, 28);
            this.sortType.TabIndex = 8;
            this.sortType.SelectedIndexChanged += new System.EventHandler(this.sortType_SelectedIndexChanged);
            // 
            // MainBankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.sortType);
            this.Controls.Add(this.SortByAge);
            this.Controls.Add(this.SortByCard);
            this.Controls.Add(this.SortByName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainBankForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Button SortByName;
        private Button SortByCard;
        private Button SortByAge;
        private ComboBox sortType;
    }
}
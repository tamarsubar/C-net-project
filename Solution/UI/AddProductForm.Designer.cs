namespace UI
{
    partial class AddProductForm
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
            label4 = new Label();
            CustomerPhone = new TextBox();
            label3 = new Label();
            label2 = new Label();
            CustomerName = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(453, 239);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 15;
            label4.Text = "טלפון";
            // CustomerPhone
            // 
            CustomerPhone.Location = new Point(300, 235);
            CustomerPhone.Name = "CustomerPhone";
            CustomerPhone.Size = new Size(100, 23);
            CustomerPhone.TabIndex = 14;
            CustomerPhone.TextChanged += CustomerPhone_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(453, 206);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 13;
            label3.Text = "קטגוריה";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(453, 159);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 11;
            label2.Text = "שם מוצר";
            // 
            // CustomerName
            // 
            CustomerName.Location = new Point(300, 151);
            CustomerName.Name = "CustomerName";
            CustomerName.Size = new Size(100, 23);
            CustomerName.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(453, 281);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 17;
            label5.Text = "טלפון";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(300, 277);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 16;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "לאישה" });
            comboBox1.Location = new Point(300, 198);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 23);
            comboBox1.TabIndex = 18;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(CustomerPhone);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(CustomerName);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox CustomerPhone;
        private Label label3;
        private Label label2;
        private TextBox CustomerName;
        private Label label5;
        private TextBox textBox1;
        private ComboBox comboBox1;
    }
}
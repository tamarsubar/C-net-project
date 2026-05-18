namespace UI
{
    partial class AddCustomerForm
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
            customerId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            CustomerName = new TextBox();
            label3 = new Label();
            CustomerAdress = new TextBox();
            label4 = new Label();
            CustomerPhone = new TextBox();
            SuspendLayout();
            // 
            // customerId
            // 
            customerId.Location = new Point(313, 150);
            customerId.Name = "customerId";
            customerId.Size = new Size(100, 23);
            customerId.TabIndex = 0;
            customerId.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(466, 158);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "תעודת זהות";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(466, 204);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 3;
            label2.Text = "שם ";
            // 
            // CustomerName
            // 
            CustomerName.Location = new Point(313, 196);
            CustomerName.Name = "CustomerName";
            CustomerName.Size = new Size(100, 23);
            CustomerName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(466, 251);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "כתובת";
            // 
            // CustomerAdress
            // 
            CustomerAdress.Location = new Point(313, 243);
            CustomerAdress.Name = "CustomerAdress";
            CustomerAdress.Size = new Size(100, 23);
            CustomerAdress.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(466, 284);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "טלפון";
            label4.Click += label4_Click;
            // 
            // CustomerPhone
            // 
            CustomerPhone.Location = new Point(313, 280);
            CustomerPhone.Name = "CustomerPhone";
            CustomerPhone.Size = new Size(100, 23);
            CustomerPhone.TabIndex = 6;
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(CustomerPhone);
            Controls.Add(label3);
            Controls.Add(CustomerAdress);
            Controls.Add(label2);
            Controls.Add(CustomerName);
            Controls.Add(label1);
            Controls.Add(customerId);
            Name = "AddCustomerForm";
            Text = "AddCustomerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox customerId;
        private Label label1;
        private Label label2;
        private TextBox CustomerName;
        private Label label3;
        private TextBox CustomerAdress;
        private Label label4;
        private TextBox CustomerPhone;
    }
}
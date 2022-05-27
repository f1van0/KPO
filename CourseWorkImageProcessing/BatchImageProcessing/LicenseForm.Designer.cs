
namespace BatchImageProcessing
{
    partial class LicenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usbTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timeStartTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timeEndTextBox = new System.Windows.Forms.TextBox();
            this.LicenseFoundText = new System.Windows.Forms.Label();
            this.LicenseStatusText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(12, 120);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.ReadOnly = true;
            this.usernameTextBox.Size = new System.Drawing.Size(192, 23);
            this.usernameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя пользвателя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "USB накопитель";
            // 
            // usbTextBox
            // 
            this.usbTextBox.Location = new System.Drawing.Point(12, 171);
            this.usbTextBox.Name = "usbTextBox";
            this.usbTextBox.ReadOnly = true;
            this.usbTextBox.Size = new System.Drawing.Size(192, 23);
            this.usbTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Время начала лицензии";
            // 
            // timeStartTextBox
            // 
            this.timeStartTextBox.Location = new System.Drawing.Point(12, 224);
            this.timeStartTextBox.Name = "timeStartTextBox";
            this.timeStartTextBox.ReadOnly = true;
            this.timeStartTextBox.Size = new System.Drawing.Size(192, 23);
            this.timeStartTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Время конца лицензии";
            // 
            // timeEndTextBox
            // 
            this.timeEndTextBox.Location = new System.Drawing.Point(12, 277);
            this.timeEndTextBox.Name = "timeEndTextBox";
            this.timeEndTextBox.ReadOnly = true;
            this.timeEndTextBox.Size = new System.Drawing.Size(192, 23);
            this.timeEndTextBox.TabIndex = 9;
            // 
            // LicenseFoundText
            // 
            this.LicenseFoundText.AutoSize = true;
            this.LicenseFoundText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LicenseFoundText.Location = new System.Drawing.Point(12, 67);
            this.LicenseFoundText.Name = "LicenseFoundText";
            this.LicenseFoundText.Size = new System.Drawing.Size(148, 21);
            this.LicenseFoundText.TabIndex = 11;
            this.LicenseFoundText.Text = "Лицензия найдена:";
            // 
            // LicenseStatusText
            // 
            this.LicenseStatusText.BackColor = System.Drawing.Color.PaleGreen;
            this.LicenseStatusText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LicenseStatusText.Location = new System.Drawing.Point(12, 12);
            this.LicenseStatusText.Name = "LicenseStatusText";
            this.LicenseStatusText.ReadOnly = true;
            this.LicenseStatusText.Size = new System.Drawing.Size(680, 32);
            this.LicenseStatusText.TabIndex = 12;
            this.LicenseStatusText.Text = "Лицензия активна";
            this.LicenseStatusText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(233, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 227);
            this.label1.TabIndex = 13;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 306);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LicenseStatusText);
            this.Controls.Add(this.LicenseFoundText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeEndTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timeStartTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usbTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameTextBox);
            this.Name = "LicenseForm";
            this.Text = "Информация о лицензии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LicenseForm_FormClosing);
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usbTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox timeStartTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox timeEndTextBox;
        private System.Windows.Forms.Label LicenseFoundText;
        private System.Windows.Forms.TextBox LicenseStatusText;
        private System.Windows.Forms.Label label1;
    }
}
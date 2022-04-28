
namespace MainProgram
{
    partial class MainProgram
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.licenseInfoLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usbBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serialBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.endBox = new System.Windows.Forms.TextBox();
            this.verifyButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.abTextBox = new System.Windows.Forms.TextBox();
            this.devicesTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(12, 62);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.ReadOnly = true;
            this.usernameBox.Size = new System.Drawing.Size(217, 23);
            this.usernameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя пользователя";
            // 
            // licenseInfoLabel
            // 
            this.licenseInfoLabel.AutoSize = true;
            this.licenseInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.licenseInfoLabel.Name = "licenseInfoLabel";
            this.licenseInfoLabel.Size = new System.Drawing.Size(83, 15);
            this.licenseInfoLabel.TabIndex = 2;
            this.licenseInfoLabel.Text = "Нет лицензии";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "USB";
            // 
            // usbBox
            // 
            this.usbBox.Location = new System.Drawing.Point(12, 114);
            this.usbBox.Name = "usbBox";
            this.usbBox.ReadOnly = true;
            this.usbBox.Size = new System.Drawing.Size(217, 23);
            this.usbBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Серийный номер";
            // 
            // serialBox
            // 
            this.serialBox.Location = new System.Drawing.Point(12, 164);
            this.serialBox.Name = "serialBox";
            this.serialBox.ReadOnly = true;
            this.serialBox.Size = new System.Drawing.Size(217, 23);
            this.serialBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Начало лицензии";
            // 
            // startBox
            // 
            this.startBox.Location = new System.Drawing.Point(12, 233);
            this.startBox.Name = "startBox";
            this.startBox.ReadOnly = true;
            this.startBox.Size = new System.Drawing.Size(217, 23);
            this.startBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Конец лицензии";
            // 
            // endBox
            // 
            this.endBox.Location = new System.Drawing.Point(12, 284);
            this.endBox.Name = "endBox";
            this.endBox.ReadOnly = true;
            this.endBox.Size = new System.Drawing.Size(217, 23);
            this.endBox.TabIndex = 9;
            // 
            // verifyButton
            // 
            this.verifyButton.Location = new System.Drawing.Point(12, 338);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(217, 40);
            this.verifyButton.TabIndex = 11;
            this.verifyButton.Text = "Проверить лицензию";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "Функция 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(478, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "Функция 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(554, 85);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 36);
            this.progressBar1.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(478, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 81);
            this.button3.TabIndex = 15;
            this.button3.Text = "Функция 3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(554, 135);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(100, 23);
            this.aTextBox.TabIndex = 16;
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(554, 164);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(100, 23);
            this.bTextBox.TabIndex = 17;
            // 
            // abTextBox
            // 
            this.abTextBox.Location = new System.Drawing.Point(554, 193);
            this.abTextBox.Name = "abTextBox";
            this.abTextBox.ReadOnly = true;
            this.abTextBox.Size = new System.Drawing.Size(100, 23);
            this.abTextBox.TabIndex = 18;
            // 
            // devicesTextBox
            // 
            this.devicesTextBox.Location = new System.Drawing.Point(478, 255);
            this.devicesTextBox.Name = "devicesTextBox";
            this.devicesTextBox.Size = new System.Drawing.Size(176, 123);
            this.devicesTextBox.TabIndex = 19;
            this.devicesTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Список устройств";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Логи:";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(12, 423);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(642, 123);
            this.logBox.TabIndex = 22;
            this.logBox.Text = "";
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(554, 552);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(100, 23);
            this.clearLogButton.TabIndex = 23;
            this.clearLogButton.Text = "Очистить логи";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 594);
            this.Controls.Add(this.clearLogButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.devicesTextBox);
            this.Controls.Add(this.abTextBox);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serialBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usbBox);
            this.Controls.Add(this.licenseInfoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameBox);
            this.Name = "MainProgram";
            this.Text = "MainProgram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label licenseInfoLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usbBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serialBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox endBox;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.TextBox abTextBox;
        private System.Windows.Forms.RichTextBox devicesTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button clearLogButton;
    }
}


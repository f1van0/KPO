
namespace BatchImageProcessing
{
    partial class ImageItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.processProgressBar = new System.Windows.Forms.ProgressBar();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.imageName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // processProgressBar
            // 
            this.processProgressBar.Location = new System.Drawing.Point(0, 133);
            this.processProgressBar.MarqueeAnimationSpeed = 100000;
            this.processProgressBar.Name = "processProgressBar";
            this.processProgressBar.Size = new System.Drawing.Size(188, 12);
            this.processProgressBar.Step = 1;
            this.processProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.processProgressBar.TabIndex = 7;
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(0, 23);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(188, 113);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePictureBox.TabIndex = 6;
            this.imagePictureBox.TabStop = false;
            this.imagePictureBox.Click += new System.EventHandler(this.imagePictureBox_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeButton.Location = new System.Drawing.Point(163, -1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 25);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "x";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // imageName
            // 
            this.imageName.AutoSize = true;
            this.imageName.Location = new System.Drawing.Point(-3, 2);
            this.imageName.Name = "imageName";
            this.imageName.Size = new System.Drawing.Size(111, 15);
            this.imageName.TabIndex = 4;
            this.imageName.Text = "1. image_name.png";
            // 
            // ImageItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.processProgressBar);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.imageName);
            this.Name = "ImageItem";
            this.Size = new System.Drawing.Size(187, 144);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar processProgressBar;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label imageName;
    }
}

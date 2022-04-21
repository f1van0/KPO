
namespace BatchImageProcessing
{
    partial class OptionsControl
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
            this.NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VariableNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDown
            // 
            this.NumericUpDown.Location = new System.Drawing.Point(3, 18);
            this.NumericUpDown.Name = "NumericUpDown";
            this.NumericUpDown.Size = new System.Drawing.Size(200, 23);
            this.NumericUpDown.TabIndex = 0;
            // 
            // VariableNameLabel
            // 
            this.VariableNameLabel.AutoSize = true;
            this.VariableNameLabel.Location = new System.Drawing.Point(3, 0);
            this.VariableNameLabel.Name = "VariableNameLabel";
            this.VariableNameLabel.Size = new System.Drawing.Size(38, 15);
            this.VariableNameLabel.TabIndex = 1;
            this.VariableNameLabel.Text = "label1";
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VariableNameLabel);
            this.Controls.Add(this.NumericUpDown);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(207, 46);
            this.Load += new System.EventHandler(this.OptionsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumericUpDown;
        private System.Windows.Forms.Label VariableNameLabel;
    }
}

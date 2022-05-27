
namespace BatchImageProcessing
{
    partial class FiltersForm
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
            this.FiltersRadioButtonList = new System.Windows.Forms.CheckedListBox();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FiltersRadioButtonList
            // 
            this.FiltersRadioButtonList.FormattingEnabled = true;
            this.FiltersRadioButtonList.HorizontalScrollbar = true;
            this.FiltersRadioButtonList.Items.AddRange(new object[] {
            "Увеличение контрастности (images/dll/contrast.dll)",
            "Увеличение яркости (images/dll/brightness.dll)",
            "Удаление заднего фона (images/dll/eraser.dll)",
            "Медианный фильтр (images/dll/median.dll)"});
            this.FiltersRadioButtonList.Location = new System.Drawing.Point(12, 12);
            this.FiltersRadioButtonList.Name = "FiltersRadioButtonList";
            this.FiltersRadioButtonList.Size = new System.Drawing.Size(487, 292);
            this.FiltersRadioButtonList.TabIndex = 0;
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(10, 318);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 23);
            this.UpButton.TabIndex = 1;
            this.UpButton.Text = "Вверх";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(92, 318);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(75, 23);
            this.DownButton.TabIndex = 2;
            this.DownButton.Text = "Вниз";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.Location = new System.Drawing.Point(354, 320);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(145, 22);
            this.OptionsButton.TabIndex = 3;
            this.OptionsButton.Text = "Настройки плагина";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 361);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.FiltersRadioButtonList);
            this.Name = "FiltersForm";
            this.Text = "Список плагинов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiltersForm_FormClosing);
            this.Load += new System.EventHandler(this.FiltersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox FiltersRadioButtonList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button OptionsButton;
    }
}
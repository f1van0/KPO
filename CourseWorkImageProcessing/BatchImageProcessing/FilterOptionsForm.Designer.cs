
namespace BatchImageProcessing
{
    partial class FilterOptionsForm
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
            this.FilterNameLabel = new System.Windows.Forms.Label();
            this.FilterVersionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OptionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // FilterNameLabel
            // 
            this.FilterNameLabel.AutoSize = true;
            this.FilterNameLabel.Location = new System.Drawing.Point(12, 23);
            this.FilterNameLabel.Name = "FilterNameLabel";
            this.FilterNameLabel.Size = new System.Drawing.Size(228, 15);
            this.FilterNameLabel.TabIndex = 0;
            this.FilterNameLabel.Text = "Название фильтра: Увеличение яркости";
            // 
            // FilterVersionLabel
            // 
            this.FilterVersionLabel.AutoSize = true;
            this.FilterVersionLabel.Location = new System.Drawing.Point(12, 51);
            this.FilterVersionLabel.Name = "FilterVersionLabel";
            this.FilterVersionLabel.Size = new System.Drawing.Size(67, 15);
            this.FilterVersionLabel.TabIndex = 1;
            this.FilterVersionLabel.Text = "Версия: 1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Настройки фильтра:";
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OptionsPanel.Controls.Add(this.label2);
            this.OptionsPanel.Controls.Add(this.numericUpDown1);
            this.OptionsPanel.Controls.Add(this.trackBar1);
            this.OptionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.OptionsPanel.Location = new System.Drawing.Point(12, 141);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.OptionsPanel.Size = new System.Drawing.Size(461, 297);
            this.OptionsPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(13, 28);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 1;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(13, 57);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 2;
            // 
            // FilterOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 450);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilterVersionLabel);
            this.Controls.Add(this.FilterNameLabel);
            this.Name = "FilterOptionsForm";
            this.Text = "FilterOptionsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FilterOptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.FilterOptionsForm_Load);
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FilterNameLabel;
        private System.Windows.Forms.Label FilterVersionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel OptionsPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}
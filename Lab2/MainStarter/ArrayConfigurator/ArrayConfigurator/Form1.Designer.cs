
namespace ArrayConfigurator
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ArrayTextBox = new System.Windows.Forms.RichTextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OptionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ModulePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ArrayPanel = new System.Windows.Forms.Panel();
            this.ApplyOptionsPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьПлагинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModulePanel.SuspendLayout();
            this.ArrayPanel.SuspendLayout();
            this.ApplyOptionsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArrayTextBox
            // 
            this.ArrayTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ArrayTextBox.Location = new System.Drawing.Point(5, 49);
            this.ArrayTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArrayTextBox.Name = "ArrayTextBox";
            this.ArrayTextBox.Size = new System.Drawing.Size(823, 155);
            this.ArrayTextBox.TabIndex = 0;
            this.ArrayTextBox.Text = "";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ApplyButton.Location = new System.Drawing.Point(5, 450);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(823, 41);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Functrions:";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TimeLabel.Location = new System.Drawing.Point(5, 433);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(96, 17);
            this.TimeLabel.TabIndex = 4;
            this.TimeLabel.Text = "Duration time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current array:";
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.OptionsPanel.Location = new System.Drawing.Point(5, 22);
            this.OptionsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Padding = new System.Windows.Forms.Padding(6);
            this.OptionsPanel.Size = new System.Drawing.Size(823, 387);
            this.OptionsPanel.TabIndex = 6;
            this.OptionsPanel.TabStop = true;
            this.OptionsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OptionsPanel_Paint);
            // 
            // ModulePanel
            // 
            this.ModulePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ModulePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModulePanel.Controls.Add(this.label1);
            this.ModulePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ModulePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ModulePanel.Location = new System.Drawing.Point(0, 28);
            this.ModulePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModulePanel.Name = "ModulePanel";
            this.ModulePanel.Padding = new System.Windows.Forms.Padding(5);
            this.ModulePanel.Size = new System.Drawing.Size(171, 717);
            this.ModulePanel.TabIndex = 1;
            // 
            // ArrayPanel
            // 
            this.ArrayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArrayPanel.Controls.Add(this.label3);
            this.ArrayPanel.Controls.Add(this.ArrayTextBox);
            this.ArrayPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArrayPanel.Location = new System.Drawing.Point(171, 28);
            this.ArrayPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ArrayPanel.Name = "ArrayPanel";
            this.ArrayPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ArrayPanel.Size = new System.Drawing.Size(835, 211);
            this.ArrayPanel.TabIndex = 8;
            // 
            // ApplyOptionsPanel
            // 
            this.ApplyOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ApplyOptionsPanel.Controls.Add(this.OptionsPanel);
            this.ApplyOptionsPanel.Controls.Add(this.TimeLabel);
            this.ApplyOptionsPanel.Controls.Add(this.label4);
            this.ApplyOptionsPanel.Controls.Add(this.ApplyButton);
            this.ApplyOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ApplyOptionsPanel.Location = new System.Drawing.Point(171, 247);
            this.ApplyOptionsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ApplyOptionsPanel.Name = "ApplyOptionsPanel";
            this.ApplyOptionsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ApplyOptionsPanel.Size = new System.Drawing.Size(835, 498);
            this.ApplyOptionsPanel.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Options:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьПлагинToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьПлагинToolStripMenuItem
            // 
            this.открытьПлагинToolStripMenuItem.Name = "открытьПлагинToolStripMenuItem";
            this.открытьПлагинToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.открытьПлагинToolStripMenuItem.Text = "Открыть плагин";
            this.открытьПлагинToolStripMenuItem.Click += new System.EventHandler(this.открытьПлагинToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 745);
            this.Controls.Add(this.ApplyOptionsPanel);
            this.Controls.Add(this.ArrayPanel);
            this.Controls.Add(this.ModulePanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "ArrayConfigurator";
            this.ModulePanel.ResumeLayout(false);
            this.ModulePanel.PerformLayout();
            this.ArrayPanel.ResumeLayout(false);
            this.ArrayPanel.PerformLayout();
            this.ApplyOptionsPanel.ResumeLayout(false);
            this.ApplyOptionsPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ArrayTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel ModulePanel;
        private System.Windows.Forms.Panel ArrayPanel;
        private System.Windows.Forms.Panel ApplyOptionsPanel;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.FlowLayoutPanel OptionsPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьПлагинToolStripMenuItem;
    }
}


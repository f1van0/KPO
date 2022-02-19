
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OptionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ModulePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ArrayPanel = new System.Windows.Forms.Panel();
            this.ApplyOptionsPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.ModulePanel.SuspendLayout();
            this.ArrayPanel.SuspendLayout();
            this.ApplyOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(5, 21);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(589, 155);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ApplyButton.Location = new System.Drawing.Point(5, 184);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(589, 41);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modules";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(5, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duration time:";
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
            this.OptionsPanel.Controls.Add(this.label5);
            this.OptionsPanel.Controls.Add(this.radioButton3);
            this.OptionsPanel.Controls.Add(this.radioButton1);
            this.OptionsPanel.Controls.Add(this.radioButton2);
            this.OptionsPanel.Controls.Add(this.numericUpDown1);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.OptionsPanel.Location = new System.Drawing.Point(5, 22);
            this.OptionsPanel.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.OptionsPanel.Size = new System.Drawing.Size(589, 140);
            this.OptionsPanel.TabIndex = 6;
            this.OptionsPanel.TabStop = true;
            this.OptionsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OptionsPanel_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Return";
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(17, 33);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(120, 21);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Average value";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 62);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Min value";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(31, 91);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Max value";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(144, 15);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 11;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 114);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(187, 41);
            this.button7.TabIndex = 5;
            this.button7.Text = "MinMaxAvg";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 69);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(187, 41);
            this.button6.TabIndex = 4;
            this.button6.Text = "SortArray";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 24);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(187, 41);
            this.button5.TabIndex = 3;
            this.button5.Text = "RandomArray";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // ModulePanel
            // 
            this.ModulePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ModulePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModulePanel.Controls.Add(this.label1);
            this.ModulePanel.Controls.Add(this.button5);
            this.ModulePanel.Controls.Add(this.button6);
            this.ModulePanel.Controls.Add(this.button7);
            this.ModulePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ModulePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ModulePanel.Location = new System.Drawing.Point(0, 0);
            this.ModulePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModulePanel.Name = "ModulePanel";
            this.ModulePanel.Padding = new System.Windows.Forms.Padding(5);
            this.ModulePanel.Size = new System.Drawing.Size(199, 423);
            this.ModulePanel.TabIndex = 1;
            // 
            // ArrayPanel
            // 
            this.ArrayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArrayPanel.Controls.Add(this.label3);
            this.ArrayPanel.Controls.Add(this.richTextBox1);
            this.ArrayPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArrayPanel.Location = new System.Drawing.Point(199, 0);
            this.ArrayPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ArrayPanel.Name = "ArrayPanel";
            this.ArrayPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ArrayPanel.Size = new System.Drawing.Size(601, 183);
            this.ArrayPanel.TabIndex = 8;
            // 
            // ApplyOptionsPanel
            // 
            this.ApplyOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ApplyOptionsPanel.Controls.Add(this.OptionsPanel);
            this.ApplyOptionsPanel.Controls.Add(this.label2);
            this.ApplyOptionsPanel.Controls.Add(this.label4);
            this.ApplyOptionsPanel.Controls.Add(this.ApplyButton);
            this.ApplyOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ApplyOptionsPanel.Location = new System.Drawing.Point(199, 191);
            this.ApplyOptionsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ApplyOptionsPanel.Name = "ApplyOptionsPanel";
            this.ApplyOptionsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ApplyOptionsPanel.Size = new System.Drawing.Size(601, 232);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 423);
            this.Controls.Add(this.ApplyOptionsPanel);
            this.Controls.Add(this.ArrayPanel);
            this.Controls.Add(this.ModulePanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ModulePanel.ResumeLayout(false);
            this.ModulePanel.PerformLayout();
            this.ArrayPanel.ResumeLayout(false);
            this.ArrayPanel.PerformLayout();
            this.ApplyOptionsPanel.ResumeLayout(false);
            this.ApplyOptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.FlowLayoutPanel ModulePanel;
        private System.Windows.Forms.Panel ArrayPanel;
        private System.Windows.Forms.Panel ApplyOptionsPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.FlowLayoutPanel OptionsPanel;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}


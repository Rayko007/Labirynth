namespace Labirynth
{
    partial class Add_Item
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
            this.radioButton_Agent = new System.Windows.Forms.RadioButton();
            this.radioButton_Flag = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_ToSelected = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_Y = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numeric_X = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_X)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_Agent
            // 
            this.radioButton_Agent.AutoSize = true;
            this.radioButton_Agent.Checked = true;
            this.radioButton_Agent.Location = new System.Drawing.Point(12, 12);
            this.radioButton_Agent.Name = "radioButton_Agent";
            this.radioButton_Agent.Size = new System.Drawing.Size(53, 17);
            this.radioButton_Agent.TabIndex = 0;
            this.radioButton_Agent.TabStop = true;
            this.radioButton_Agent.Text = "Agent";
            this.radioButton_Agent.UseVisualStyleBackColor = true;
            this.radioButton_Agent.CheckedChanged += new System.EventHandler(this.radioButton_Agent_CheckedChanged);
            // 
            // radioButton_Flag
            // 
            this.radioButton_Flag.AutoSize = true;
            this.radioButton_Flag.Location = new System.Drawing.Point(103, 12);
            this.radioButton_Flag.Name = "radioButton_Flag";
            this.radioButton_Flag.Size = new System.Drawing.Size(45, 17);
            this.radioButton_Flag.TabIndex = 1;
            this.radioButton_Flag.Text = "Flag";
            this.radioButton_Flag.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.checkBox_ToSelected);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numeric_Y);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numeric_X);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 138);
            this.panel1.TabIndex = 2;
            // 
            // checkBox_ToSelected
            // 
            this.checkBox_ToSelected.AutoSize = true;
            this.checkBox_ToSelected.Location = new System.Drawing.Point(6, 78);
            this.checkBox_ToSelected.Name = "checkBox_ToSelected";
            this.checkBox_ToSelected.Size = new System.Drawing.Size(98, 17);
            this.checkBox_ToSelected.TabIndex = 8;
            this.checkBox_ToSelected.Text = "To All Selected";
            this.checkBox_ToSelected.UseVisualStyleBackColor = true;
            this.checkBox_ToSelected.CheckedChanged += new System.EventHandler(this.checkBox_ToSelected_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 4;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(6, 54);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Speed";
            // 
            // numeric_Y
            // 
            this.numeric_Y.Location = new System.Drawing.Point(97, 15);
            this.numeric_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_Y.Name = "numeric_Y";
            this.numeric_Y.Size = new System.Drawing.Size(45, 20);
            this.numeric_Y.TabIndex = 4;
            this.numeric_Y.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // numeric_X
            // 
            this.numeric_X.Location = new System.Drawing.Point(26, 15);
            this.numeric_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numeric_X.Name = "numeric_X";
            this.numeric_X.Size = new System.Drawing.Size(45, 20);
            this.numeric_X.TabIndex = 2;
            this.numeric_X.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "None"});
            this.listBox1.Location = new System.Drawing.Point(148, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(116, 121);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 10;
            // 
            // Add_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 185);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioButton_Flag);
            this.Controls.Add(this.radioButton_Agent);
            this.Name = "Add_Item";
            this.Text = "Add";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_X)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_Agent;
        private System.Windows.Forms.RadioButton radioButton_Flag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numeric_Y;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numeric_X;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_ToSelected;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}
namespace Labirynth
{
    partial class ProjectManager
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WorldViewport = new System.Windows.Forms.PictureBox();
            this.panel_areaAssert = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Assert = new System.Windows.Forms.Button();
            this.numericUpDown_Friction = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox_IsBlocked = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.current_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_saveWorld = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_constructor = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.heightNumeric = new System.Windows.Forms.NumericUpDown();
            this.widthNumeric = new System.Windows.Forms.NumericUpDown();
            this.button_createWorld = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numeric_Seed = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorldViewport)).BeginInit();
            this.panel_areaAssert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Friction)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel_constructor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Seed)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.WorldViewport);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 300);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.world_view_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.world_view_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.world_view_MouseUp);
            // 
            // WorldViewport
            // 
            this.WorldViewport.Location = new System.Drawing.Point(0, 0);
            this.WorldViewport.Name = "WorldViewport";
            this.WorldViewport.Size = new System.Drawing.Size(296, 296);
            this.WorldViewport.TabIndex = 0;
            this.WorldViewport.TabStop = false;
            this.WorldViewport.DragDrop += new System.Windows.Forms.DragEventHandler(this.world_view_DragDrop);
            this.WorldViewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.world_view_MouseDown);
            this.WorldViewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.world_view_MouseMove);
            this.WorldViewport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.world_view_MouseUp);
            // 
            // panel_areaAssert
            // 
            this.panel_areaAssert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_areaAssert.Controls.Add(this.button1);
            this.panel_areaAssert.Controls.Add(this.button_Assert);
            this.panel_areaAssert.Controls.Add(this.numericUpDown_Friction);
            this.panel_areaAssert.Controls.Add(this.label8);
            this.panel_areaAssert.Controls.Add(this.checkBox_IsBlocked);
            this.panel_areaAssert.Controls.Add(this.label7);
            this.panel_areaAssert.Location = new System.Drawing.Point(3, 3);
            this.panel_areaAssert.Name = "panel_areaAssert";
            this.panel_areaAssert.Size = new System.Drawing.Size(117, 140);
            this.panel_areaAssert.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add item...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_Assert
            // 
            this.button_Assert.Location = new System.Drawing.Point(3, 81);
            this.button_Assert.Name = "button_Assert";
            this.button_Assert.Size = new System.Drawing.Size(105, 23);
            this.button_Assert.TabIndex = 4;
            this.button_Assert.Text = "Assert";
            this.button_Assert.UseVisualStyleBackColor = true;
            this.button_Assert.Click += new System.EventHandler(this.button_Assert_Click);
            // 
            // numericUpDown_Friction
            // 
            this.numericUpDown_Friction.DecimalPlaces = 5;
            this.numericUpDown_Friction.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown_Friction.Location = new System.Drawing.Point(3, 55);
            this.numericUpDown_Friction.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Friction.Name = "numericUpDown_Friction";
            this.numericUpDown_Friction.Size = new System.Drawing.Size(105, 20);
            this.numericUpDown_Friction.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Friction";
            // 
            // checkBox_IsBlocked
            // 
            this.checkBox_IsBlocked.AutoSize = true;
            this.checkBox_IsBlocked.Location = new System.Drawing.Point(3, 19);
            this.checkBox_IsBlocked.Name = "checkBox_IsBlocked";
            this.checkBox_IsBlocked.Size = new System.Drawing.Size(105, 17);
            this.checkBox_IsBlocked.TabIndex = 1;
            this.checkBox_IsBlocked.Text = "Is area blocked?";
            this.checkBox_IsBlocked.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Assert area parameters";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.current_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(806, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // current_status
            // 
            this.current_status.Name = "current_status";
            this.current_status.Size = new System.Drawing.Size(39, 17);
            this.current_status.Text = "Ready";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(456, 73);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Log";
            // 
            // button_saveWorld
            // 
            this.button_saveWorld.Location = new System.Drawing.Point(247, 1);
            this.button_saveWorld.Name = "button_saveWorld";
            this.button_saveWorld.Size = new System.Drawing.Size(88, 23);
            this.button_saveWorld.TabIndex = 4;
            this.button_saveWorld.Text = "Save World";
            this.button_saveWorld.UseVisualStyleBackColor = true;
            this.button_saveWorld.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(247, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Load World";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(247, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Start Simulation";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(2, 19);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(81, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tiles per Screen";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(2, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Default View";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 79);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Camera Control";
            // 
            // panel_constructor
            // 
            this.panel_constructor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_constructor.Controls.Add(this.panel_areaAssert);
            this.panel_constructor.Controls.Add(this.vScrollBar1);
            this.panel_constructor.Location = new System.Drawing.Point(100, 19);
            this.panel_constructor.Name = "panel_constructor";
            this.panel_constructor.Size = new System.Drawing.Size(141, 176);
            this.panel_constructor.TabIndex = 12;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(123, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(16, 174);
            this.vScrollBar1.TabIndex = 7;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Type";
            // 
            // typeBox
            // 
            this.typeBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Empty",
            "Blocked",
            "Random"});
            this.typeBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.typeBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.typeBox.DisplayMember = "1";
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Empty",
            "Blocked",
            "Random"});
            this.typeBox.Location = new System.Drawing.Point(385, 80);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(88, 21);
            this.typeBox.TabIndex = 5;
            this.typeBox.Tag = "";
            this.typeBox.Text = "Random";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Width";
            // 
            // heightNumeric
            // 
            this.heightNumeric.Location = new System.Drawing.Point(428, 41);
            this.heightNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.heightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumeric.Name = "heightNumeric";
            this.heightNumeric.Size = new System.Drawing.Size(45, 20);
            this.heightNumeric.TabIndex = 2;
            this.heightNumeric.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // widthNumeric
            // 
            this.widthNumeric.Location = new System.Drawing.Point(385, 41);
            this.widthNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.widthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumeric.Name = "widthNumeric";
            this.widthNumeric.Size = new System.Drawing.Size(43, 20);
            this.widthNumeric.TabIndex = 1;
            this.widthNumeric.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // button_createWorld
            // 
            this.button_createWorld.Location = new System.Drawing.Point(385, 1);
            this.button_createWorld.Name = "button_createWorld";
            this.button_createWorld.Size = new System.Drawing.Size(88, 23);
            this.button_createWorld.TabIndex = 0;
            this.button_createWorld.Text = "Create New World";
            this.button_createWorld.UseVisualStyleBackColor = true;
            this.button_createWorld.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.numeric_Seed);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.typeBox);
            this.panel4.Controls.Add(this.panel_constructor);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.button_saveWorld);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.heightNumeric);
            this.panel4.Controls.Add(this.widthNumeric);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.button_createWorld);
            this.panel4.Location = new System.Drawing.Point(316, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(478, 300);
            this.panel4.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(247, 172);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Help";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(385, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Seed";
            // 
            // numeric_Seed
            // 
            this.numeric_Seed.Location = new System.Drawing.Point(385, 125);
            this.numeric_Seed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numeric_Seed.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numeric_Seed.Name = "numeric_Seed";
            this.numeric_Seed.Size = new System.Drawing.Size(88, 20);
            this.numeric_Seed.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.richTextBox1);
            this.panel5.Location = new System.Drawing.Point(3, 201);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(470, 94);
            this.panel5.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 357);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "ProjectManager";
            this.Text = "ProjectManager";
            this.ResizeEnd += new System.EventHandler(this.trackBar1_Scroll);
            this.Click += new System.EventHandler(this.trackBar1_Scroll);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectManager_KeyDown);
            this.Resize += new System.EventHandler(this.ProjectManager_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorldViewport)).EndInit();
            this.panel_areaAssert.ResumeLayout(false);
            this.panel_areaAssert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Friction)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_constructor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Seed)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel current_status;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_saveWorld;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_constructor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown heightNumeric;
        private System.Windows.Forms.NumericUpDown widthNumeric;
        private System.Windows.Forms.Button button_createWorld;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.PictureBox WorldViewport;
        private System.Windows.Forms.Panel panel_areaAssert;
        private System.Windows.Forms.NumericUpDown numericUpDown_Friction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_IsBlocked;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Assert;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numeric_Seed;
        private System.Windows.Forms.Button button5;
    }
}


namespace Wf_WakeUp_MousControl
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MoveMouseCheckBox = new CheckBox();
            TimerProgressBar = new ProgressBar();
            IntervalTXT = new TextBox();
            label1 = new Label();
            TXTBA1B1 = new Label();
            BoostcheckBox = new CheckBox();
            SuspendLayout();
            // 
            // MoveMouseCheckBox
            // 
            MoveMouseCheckBox.AutoSize = true;
            MoveMouseCheckBox.Location = new Point(15, 16);
            MoveMouseCheckBox.Margin = new Padding(4);
            MoveMouseCheckBox.Name = "MoveMouseCheckBox";
            MoveMouseCheckBox.Size = new Size(69, 24);
            MoveMouseCheckBox.TabIndex = 0;
            MoveMouseCheckBox.Text = "MAM";
            MoveMouseCheckBox.UseVisualStyleBackColor = true;
            MoveMouseCheckBox.CheckedChanged += MoveMouseCheckBox_CheckedChanged;
            // 
            // TimerProgressBar
            // 
            TimerProgressBar.Location = new Point(15, 77);
            TimerProgressBar.Margin = new Padding(4);
            TimerProgressBar.Name = "TimerProgressBar";
            TimerProgressBar.Size = new Size(436, 31);
            TimerProgressBar.TabIndex = 1;
            // 
            // IntervalTXT
            // 
            IntervalTXT.Location = new Point(333, 13);
            IntervalTXT.Margin = new Padding(4);
            IntervalTXT.Name = "IntervalTXT";
            IntervalTXT.Size = new Size(117, 27);
            IntervalTXT.TabIndex = 2;
            IntervalTXT.Text = "111";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(230, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 3;
            label1.Text = "Interval(sec):";
            // 
            // TXTBA1B1
            // 
            TXTBA1B1.AutoSize = true;
            TXTBA1B1.BackColor = SystemColors.Window;
            TXTBA1B1.Location = new Point(15, 53);
            TXTBA1B1.Margin = new Padding(4, 0, 4, 0);
            TXTBA1B1.Name = "TXTBA1B1";
            TXTBA1B1.Size = new Size(78, 20);
            TXTBA1B1.TabIndex = 4;
            TXTBA1B1.Text = "TXTBA1B1";
            // 
            // BoostcheckBox
            // 
            BoostcheckBox.AutoSize = true;
            BoostcheckBox.Location = new Point(91, 17);
            BoostcheckBox.Name = "BoostcheckBox";
            BoostcheckBox.Size = new Size(69, 24);
            BoostcheckBox.TabIndex = 5;
            BoostcheckBox.Text = "Boost";
            BoostcheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(467, 124);
            Controls.Add(BoostcheckBox);
            Controls.Add(TXTBA1B1);
            Controls.Add(label1);
            Controls.Add(IntervalTXT);
            Controls.Add(TimerProgressBar);
            Controls.Add(MoveMouseCheckBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            Text = "M";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox MoveMouseCheckBox;
        private ProgressBar TimerProgressBar;
        private TextBox IntervalTXT;
        private Label label1;
        private Label TXTBA1B1;
        private CheckBox BoostcheckBox;
    }
}

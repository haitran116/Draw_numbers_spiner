namespace Draw_numbers_spiner
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
            components = new System.ComponentModel.Container();
            timer_playing = new System.Windows.Forms.Timer(components);
            btn_chot = new Button();
            btn_quay = new Button();
            btn_quaytiep = new Button();
            timer_fireworks = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // timer_playing
            // 
            timer_playing.Interval = 10;
            timer_playing.Tick += timer_playing_Tick;
            // 
            // btn_chot
            // 
            btn_chot.BackColor = Color.BlueViolet;
            btn_chot.Font = new Font("UTM HelvetIns", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_chot.ForeColor = SystemColors.ButtonFace;
            btn_chot.Location = new Point(599, 653);
            btn_chot.Margin = new Padding(9, 13, 9, 13);
            btn_chot.Name = "btn_chot";
            btn_chot.Size = new Size(141, 64);
            btn_chot.TabIndex = 0;
            btn_chot.Text = "Chốt";
            btn_chot.UseVisualStyleBackColor = false;
            btn_chot.Click += btn_chot_Click;
            // 
            // btn_quay
            // 
            btn_quay.BackColor = Color.Red;
            btn_quay.Font = new Font("UTM HelvetIns", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_quay.ForeColor = SystemColors.ButtonFace;
            btn_quay.Location = new Point(452, 653);
            btn_quay.Margin = new Padding(9, 13, 9, 13);
            btn_quay.Name = "btn_quay";
            btn_quay.Size = new Size(141, 64);
            btn_quay.TabIndex = 1;
            btn_quay.Text = "Quay";
            btn_quay.UseVisualStyleBackColor = false;
            btn_quay.Click += btn_quay_Click;
            // 
            // btn_quaytiep
            // 
            btn_quaytiep.BackColor = Color.Gold;
            btn_quaytiep.Font = new Font("UTM HelvetIns", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_quaytiep.ForeColor = SystemColors.ActiveCaptionText;
            btn_quaytiep.Location = new Point(746, 653);
            btn_quaytiep.Margin = new Padding(9, 13, 9, 13);
            btn_quaytiep.Name = "btn_quaytiep";
            btn_quaytiep.Size = new Size(141, 64);
            btn_quaytiep.TabIndex = 2;
            btn_quaytiep.Text = "Tiếp giải";
            btn_quaytiep.UseVisualStyleBackColor = false;
            btn_quaytiep.Click += btn_quaytiep_Click;
            // 
            // timer_fireworks
            // 
            timer_fireworks.Tick += timer_fireworks_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(452, 318);
            label1.Name = "label1";
            label1.Size = new Size(355, 44);
            label1.TabIndex = 3;
            label1.Text = "Chúc mừng - Trần Mạnh Hải";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 43F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1350, 729);
            Controls.Add(label1);
            Controls.Add(btn_quaytiep);
            Controls.Add(btn_quay);
            Controls.Add(btn_chot);
            DoubleBuffered = true;
            Font = new Font("UTM HelvetIns", 22F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(9, 13, 9, 13);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer_playing;
        private Button btn_chot;
        private Button btn_quay;
        private Button btn_quaytiep;
        private System.Windows.Forms.Timer timer_fireworks;
        private Label label1;
    }
}
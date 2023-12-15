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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer_playing = new System.Windows.Forms.Timer(components);
            btn_chot = new Button();
            btn_quay = new Button();
            btn_quaytiep = new Button();
            timer_fireworks = new System.Windows.Forms.Timer(components);
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
            btn_chot.Location = new Point(563, 605);
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
            btn_quay.Location = new Point(416, 605);
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
            btn_quaytiep.Location = new Point(710, 605);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1264, 681);
            Controls.Add(btn_quaytiep);
            Controls.Add(btn_quay);
            Controls.Add(btn_chot);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer_playing;
        private Button btn_chot;
        private Button btn_quay;
        private Button btn_quaytiep;
        private System.Windows.Forms.Timer timer_fireworks;
    }
}
using NAudio.Wave;
using System;
using System.Diagnostics;
using System.Media;

namespace Draw_numbers_spiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.DarkMagenta;
            this.DoubleBuffered = true;

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            creats_number_spiner();

            timer_playing.Start();

        }

        List<Numbers> list_number = new List<Numbers>();

        List<Firework> fireworks_list = new List<Firework>();

        SoundPlayer sound_firework = new SoundPlayer("sound/fw.wav");

        string roll_number = "";

        Boolean check_wait = true;

        Boolean check_roll_stop = false;

        int n1, n2, n3, n4;

        int x, y;

        int check_show_final = 0;

        List<int> list_number_roll = new List<int>();

        Boolean check_wait_roll = false;
        Boolean check_rolling = false;
        Boolean check_roll_final = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (list_number != null)
            {
                int px = 0;
                foreach (Numbers number in list_number.ToList())
                {
                    e.Graphics.DrawImage(number.number, 235 + (162 * px), 100, number.number.Width, number.number.Height);

                    px++;
                }

                Debug.WriteLine("Vẽ số");
            }

            if(fireworks_list != null)
            {
                foreach (Firework newFirework in fireworks_list.ToList())
                {
                    if (newFirework.animationComplete == false)
                    {
                        e.Graphics.DrawImage(newFirework.firework, newFirework.position.X, newFirework.position.Y, newFirework.width, newFirework.height);
                    }
                    Debug.WriteLine("Vẽ pháo hoa");
                }
            }
        }

        Boolean check_on_sound_firework = false;
        private void timer_playing_Tick(object sender, EventArgs e)
        {
            //roll wait
            if (list_number != null && check_wait == true && check_roll_stop == false)
            {
                foreach (Numbers number in list_number.ToList())
                {
                    number.animation_number();
                }
            }

            // roll fast
            if (list_number != null && check_wait == false && check_roll_stop == false)
            {
                foreach (Numbers number in list_number.ToList())
                {
                    number.speed = 64;
                    number.animation_number();
                }
            }

            //roll slowly
            if (check_roll_stop == true && check_show_final < list_number.Count)
            {
                int index_ = 0;

                foreach (Numbers number in list_number.ToList())
                {
                    int n = list_number_roll[index_];
                    number.animation_number_slowly(n);
                    index_++;
                }
            }

            // kiểm tra xem đã vẽ đủ số kết quả chưa
            check_show_final = 0;
            foreach (Numbers number in list_number.ToList())
            {
                if (number.check_final == true)
                {
                    check_show_final++;
                }
            }

            // nếu chưa vẽ đủ số kết quả thì vẽ cho đến khi nào xong
            if (check_show_final < list_number.Count)
            {
                this.Invalidate();
            }

            // nhi trả kết quả ra thì bắt pháo hoa
            if (check_show_final == list_number.Count)
            {
                if (!timer_fireworks.Enabled)
                {
                    timer_fireworks.Start();

                    check_on_sound_firework = true;
                }

                if (check_on_sound_firework ==  true)
                {
                    sound_firework.PlayLooping();

                    check_on_sound_firework = false;
                }
            }

            // firework ----
            if (fireworks_list != null)
            {
                foreach (Firework firework in fireworks_list.ToList())
                {

                    if (firework.animationComplete == false)
                    {
                        firework.AnimateFireWork();
                    }
                    else
                    {
                        fireworks_list.Remove(firework);
                    }
                }
            }
            this.Invalidate();
        }

        private void creats_number_spiner()
        {
            for (int i = 0; i < 5; i++)
            {
                Numbers number = new Numbers();
                Random random = new Random();

                number.random_vecter = random.Next(0, 2);
                number.speed = number.speed = random.Next(4, 1212);

                int dk = 0;

                if (number.speed != 1)
                {
                    do
                    {

                        if (192 % number.speed == 0)
                        {
                            dk = 1;
                        }
                        else
                        {
                            number.speed = random.Next(4, 12);
                        }
                    } while (dk == 0);
                }
                list_number.Add(number);
            }
        }

        private void btn_chot_Click(object sender, EventArgs e)
        {
            check_wait = false;
            check_roll_stop = true;

            btn_quay.Enabled = false;
            btn_quaytiep.Enabled = true;

            Random random = new Random();

            list_number_roll.Add(random.Next(0, 9));
            list_number_roll.Add(random.Next(0, 9));
            list_number_roll.Add(random.Next(0, 9));
            list_number_roll.Add(random.Next(0, 9));
            list_number_roll.Add(random.Next(0, 9));
        }

        private void btn_quay_Click(object sender, EventArgs e)
        {
            list_number_roll.Clear();

            btn_chot.Enabled = true;
            btn_quaytiep.Enabled = false;

            check_roll_stop = false;
            check_wait = false;
        }

        private void btn_quaytiep_Click(object sender, EventArgs e)
        {
            list_number.Clear();
            creats_number_spiner();

            btn_quay.Enabled = true;
            btn_chot.Enabled = false;

            check_wait = true;
            check_roll_stop = false;

            timer_fireworks.Stop();
            sound_firework.Stop(); 
        }

        private void timer_fireworks_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            Firework newFirework = new Firework();
            newFirework.position.X = random.Next(0, 1280) - (newFirework.width / 2);
            newFirework.position.Y = random.Next(0, 1280) - (newFirework.height / 2);
            fireworks_list.Add(newFirework);          

        }
    }
}
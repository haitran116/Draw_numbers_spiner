﻿using System;
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
            this.DoubleBuffered = true;

            this.BackgroundImage = new Bitmap(@"images/back.png");
            //this.BackgroundImageLayout = ImageLayout.Stretch;

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;


            timer_playing.Start();
        }
        //-- hiệu ứng âm thanh --
        SoundPlayer sound_firework = new SoundPlayer("sound/fw.wav");
        SoundPlayer sound_quay = new SoundPlayer("sound/quay.wav");
        SoundPlayer sound_chot = new SoundPlayer("sound/chot.wav");


        //-- biến toàn cục --
        List<Numbers> list_numbers = new List<Numbers>();
        List<Firework> fireworks_list = new List<Firework>();

        Boolean check_on_sound_firework = false;

        Boolean check_open_game = true;

        Boolean click_quay = false;
        Boolean click_chot = false;
        Boolean click_tiep = false;

        int quay_giai_nao = 0;

        List<int> list_number_roll = new List<int>();


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (list_numbers != null)
            {
                int px = 0;
                foreach (Numbers number in list_numbers.ToList())
                {
                    e.Graphics.DrawImage(number.number, 278 + (162 * px), 100, number.number.Width, number.number.Height);

                    px++;
                }

                Debug.WriteLine("Vẽ số");
            }

            if (fireworks_list != null)
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

        private void timer_playing_Tick(object sender, EventArgs e)
        {
            if (check_open_game == true)
            {
                if (list_numbers.Count == 0)
                {
                    list_numbers = creats_number_spiner();
                }

                roll_wait(list_numbers);          
            }

            if (click_quay == true)
            {
                roll_fast(list_numbers);
            }

            if (click_chot == true)
            {
                roll_slowly(list_numbers);
                set_firework();
            }

            if (click_tiep == true)
            {
                if(list_numbers.Count == 0)
                {
                    list_numbers = creats_number_spiner();
                }
                roll_wait(list_numbers);
            }

            // giải nhất
            if (quay_giai_nao == 1)
            {
                
            }

        }

        // hàm tạo list đối tượng số
        List<Numbers> creats_number_spiner()
        {
            List<Numbers> list_number = new List<Numbers>();
            for (int i = 0; i < 5; i++)
            {
                Numbers number = new Numbers();
                Random random = new Random();

                number.random_vecter = random.Next(0, 2);
                number.speed = random.Next(4, 1212);

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
            return list_number;
        }

        // hàm quay chậm lúc chờ
        private void roll_wait(List<Numbers> list_number)
        {
            //roll wait
            if (list_number != null)
            {
                foreach (Numbers number in list_number.ToList())
                {
                    number.animation_number();
                }
            }
            this.Invalidate();
        }

        // hàm quay số nhanh
        private void roll_fast(List<Numbers> list_number)
        {
            // roll fast
            if (list_number != null)
            {
                foreach (Numbers number in list_number.ToList())
                {
                    // set tốc độ lên 
                    number.speed = 64;
                    number.animation_number();
                }
            }
            this.Invalidate();
        }

        // hàm quay chậm dần rồi trả kết quả
        private void roll_slowly(List<Numbers> list_number)
        {
            int check_show_final = 0;
            //roll slowly
            if (check_show_final < list_number.Count)
            {
                int index_ = 0;

                foreach (Numbers number in list_number.ToList())
                {
                    // truyền từng tham số kết quả vòng quay
                    int n = list_number_roll[index_];
                    number.animation_number_slowly(n);
                    index_++;

                    // nếu 1 vòng số trả xong kết quả thì cộng check lên 1 khi nào đủ tức là trả xong hết kết quả
                    if (number.check_final == true)
                    {
                        check_show_final++;
                    }
                }

                // nhi trả kết quả ra thì bắt pháo hoa
                if (check_show_final == list_number.Count)
                {
                    if (!timer_fireworks.Enabled)
                    {
                        timer_fireworks.Start();

                        check_on_sound_firework = true;
                    }

                    if (check_on_sound_firework == true)
                    {
                        sound_firework.PlayLooping();

                        check_on_sound_firework = false;
                    }
                }

                this.Invalidate();
            }
        }

        // hàm setup pháo hoa
        private void set_firework()
        {
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
                
                this.Invalidate();
            }
        }

        private void btn_quay_Click(object sender, EventArgs e)
        {
            click_quay = true;
            click_tiep = false;
            click_chot = false;
            check_open_game = false;


            btn_chot.Enabled = true;
            btn_quaytiep.Enabled = false;

            list_number_roll.Clear();

            sound_quay.PlayLooping();
        }

        private void btn_chot_Click(object sender, EventArgs e)
        {
            click_chot = true;
            click_tiep = false;
            click_quay = false;
            check_open_game = false;

            btn_quay.Enabled = false;
            btn_quaytiep.Enabled = true;

            Random random = new Random();

            list_number_roll.Add(random.Next(0, 10));
            list_number_roll.Add(random.Next(0, 10));
            list_number_roll.Add(random.Next(0, 10));
            list_number_roll.Add(random.Next(0, 10));
            list_number_roll.Add(random.Next(0, 10));

            sound_quay.Stop();
            sound_chot.Play();
        }


        private void btn_quaytiep_Click(object sender, EventArgs e)
        {
            click_tiep = true;
            click_quay = false;
            click_chot = false;
            check_open_game = false;


            btn_quay.Enabled = true;
            btn_chot.Enabled = false;

            list_numbers.Clear();

            fireworks_list.Clear();

            timer_fireworks.Stop();
            sound_firework.Stop();
        }

        private void timer_fireworks_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            Firework newFirework = new Firework();
            newFirework.position.X = random.Next(0, 1366) - (newFirework.width / 2);
            newFirework.position.Y = random.Next(0, 1366) - (newFirework.height / 2);
            fireworks_list.Add(newFirework);

        }
    }
}
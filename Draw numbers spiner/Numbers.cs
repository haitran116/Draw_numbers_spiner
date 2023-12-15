using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw_numbers_spiner
{
    internal class Numbers
    {
        public int x, y;

        public Image number;

        List<string> image_location = new List<string>();

        int index_frame = 0;

        int index_frame_phase = 1920;

        public int random_vecter = 0;

        public int speed = 1;

        public Boolean check_final = false;       


        int delta_time_slow = 0;

        int frame_end = 0;

        public Numbers() 
        {
            number = ResizeImage(new Bitmap(@"images/numbers/0.png"), 100, 100);
        }

        public void animation_number()
        {
            if(random_vecter == 0)
            {
                if (index_frame <= 1920)
                {
                    number = Image.FromFile(string.Format(@"images/numbers/{0}.png", index_frame));
                    index_frame += speed;

                }
                else
                {
                    index_frame = 0;

                }
            }
            else
            {
                if (index_frame_phase >= 0)
                {
                    number = Image.FromFile(string.Format(@"images/numbers/{0}.png", index_frame_phase));
                    index_frame_phase -= speed;

                }
                else
                {
                    index_frame_phase = 1920;

                }
            }
        }

        public void animation_number_slowly(int n)
        {
            int chiso = 999;

            Debug.WriteLine(n);

            if (index_frame <= 1920 && frame_end <= 1920)
            {              

                if(n == 9)
                {
                    chiso = 1920;
                }
                else
                {
                    chiso = 192 * (9 - n);
                }

                if(delta_time_slow < 150)
                {
                    number = Image.FromFile(string.Format(@"images/numbers/{0}.png", index_frame));
                    index_frame += 32;
                    delta_time_slow++;
                }
                else
                {
                    if(frame_end < (chiso - 32))
                    {
                        number = Image.FromFile(string.Format(@"images/numbers/{0}.png", frame_end));
                        frame_end += 16;
                    }
                    else if (frame_end != chiso)
                    {
                        number = Image.FromFile(string.Format(@"images/numbers/{0}.png", frame_end));
                        frame_end += 1;
                    }
                    else
                    {
                        number = Image.FromFile(string.Format(@"images/numbers/{0}.png", frame_end));
                        check_final = true;
                    }
                }

            }
            else
            {
                index_frame = 0; 
            }
        }

        public static Bitmap ResizeImage(Bitmap originalImage, int newWidth, int newHeight)
        {
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            double widthRatio = (double)originalImage.Width / newWidth;
            double heightRatio = (double)originalImage.Height / newHeight;

            for (int i = 0; i < newWidth; i++)
            {
                for (int j = 0; j < newHeight; j++)
                {
                    int originalX = (int)(i * widthRatio);
                    int originalY = (int)(j * heightRatio);

                    Color pixel1 = originalImage.GetPixel(originalX, originalY);
                    Color pixel2 = originalImage.GetPixel(originalX + 1, originalY);
                    Color pixel3 = originalImage.GetPixel(originalX, originalY + 1);
                    Color pixel4 = originalImage.GetPixel(originalX + 1, originalY + 1);

                    int red = (int)((pixel1.R + pixel2.R + pixel3.R + pixel4.R) / 4);
                    int green = (int)((pixel1.G + pixel2.G + pixel3.G + pixel4.G) / 4);
                    int blue = (int)((pixel1.B + pixel2.B + pixel3.B + pixel4.B) / 4);

                    resizedImage.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return resizedImage;
        }
    }
}

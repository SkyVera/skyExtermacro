using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;
using System.Timers;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Threading;
namespace skyMacro
{
    public partial class skyMacro : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Eğer F11 tuşuna basıldıysa ve program aktif değilse, Attack Start metotunu çağır
            if (keyData == Keys.F11)
            {
                AttackStart();
                return true; // Tuş işleme işlemi tamamlandı
            }
            // Eğer F12 tuşuna basıldıysa ve program aktifse, Attack Stop metotunu çağır
            else if (keyData == Keys.F12)
            {
                AttackStop();
                return true; // Tuş işleme işlemi tamamlandı
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }
        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }
        private static Color inttorgb(int rgbColor)
        {
            var byteAry = BitConverter.GetBytes(rgbColor);

            return Color.FromArgb(byteAry[3], byteAry[0], byteAry[1], byteAry[2]);

        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        AutoItX3 au3 = new AutoItX3();
        static string handle = "";

        
        public skyMacro()
        {
            au3.AutoItSetOption("SendKeyDelay", 25);
            au3.AutoItSetOption("SendKeyDownDelay", 25);
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(OnKeyPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handle = au3.WinGetHandle(textBox1.Text);
            MessageBox.Show(handle);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer5.Enabled==false)
            {
            au3.WinActivate(textBox1.Text);
            au3.Sleep(3000);
            timer1.Interval = trackBar1.Value;
                
                button2.Text = "Attack Start";

            if (OtoAtak.Checked==true)
            {
                timer1.Enabled = true;
            }
            if (OtoWolf.Checked==true)
            {
                timer2.Enabled = true;
            }
            if (OtoDef.Checked==true)
            {
                timer3.Enabled = true;
            }
            if (OtoHp.Checked==true)
            {
                timer4.Enabled = true;
            }
            if (OtoHp52.Checked==true)
            {
                timer6.Enabled = true;
            }
            if (OtoHp53.Checked==true)
            {
                timer7.Enabled = true;
            }
            if (OtoHp54.Checked==true)
            {
                timer8.Enabled = true;
            }
            if (OtoHp55.Checked==true)
            {
                timer9.Enabled = true;
            }
            if (OtoHp56.Checked==true)
            {
                timer10.Enabled = true;
            }
            if (OtoHp57.Checked==true)
            {
                timer11.Enabled = true;
            }
            if (OtoHp58.Checked==true)
            {
                timer12.Enabled = true;
            }
            if (OtoMp.Checked == true)
            {
                timer5.Enabled = true;
            }
                button2.Text = "Attack Stop";
            }
            else
            {
                button2.Text = "Attack Start";
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                timer7.Enabled = false;
                timer8.Enabled = false;
                timer9.Enabled = false;
                timer10.Enabled = false;
                timer11.Enabled = false;
                timer12.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            au3.Send(textBox2.Text,0);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    Hp52KoordX.Text = cursorhp.X.ToString();
                    Hp52KoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("2.Kordinat alındı.");
                        break;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    HpKoordX.Text = cursorhp.X.ToString();
                    HpKoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("1.Kordinat alındı.");
                        break;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point cursormp;


            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursormp = GetCursorPosition();

                    MpKoordX.Text = cursormp.X.ToString();
                    MpKoordY.Text = cursormp.Y.ToString();
                    flag++;

                    if (flag != 0)
                    {
                        MessageBox.Show("MP Kordinat alındı.");
                        break;
                    }

                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (OtoAtak.Checked==true)
            {
                timer1.Enabled = false;
                au3.Send(textBox5.Text, 0);
                au3.Sleep(3000);
                au3.Send(textBox5.Text, 0);
                timer1.Enabled = true;
            }
            else
            {
                au3.Send(textBox5.Text, 0);
                au3.Sleep(3000);
                au3.Send(textBox5.Text, 0);
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            au3.Send(textBox6.Text, 0);
            au3.Sleep(500);
            au3.Send(textBox6.Text, 0);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor =au3.PixelGetColor(Convert.ToInt32(HpKoordX.Text), Convert.ToInt32(HpKoordY.Text));
            Color hp = inttorgb(hpcolor);
            
            if (hp.B <40)
            {
                au3.Send(textBox3.Text);
            }
        }



        private void timer5_Tick(object sender, EventArgs e)
        {
            var mpcolor = 0x1B2BD3;
            mpcolor = au3.PixelGetColor(Convert.ToInt32(MpKoordX.Text), Convert.ToInt32(MpKoordY.Text));
            Color mp = inttorgb(mpcolor);

            if (mp.R < 40)
            {
                au3.Send(textBox4.Text);
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor = au3.PixelGetColor(Convert.ToInt32(Hp52KoordX.Text), Convert.ToInt32(Hp52KoordY.Text));
            Color hp = inttorgb(hpcolor);

            if (hp.B < 40)
            {
                au3.Send(textBox7.Text);
            }
    
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    Hp53KoordX.Text = cursorhp.X.ToString();
                    Hp53KoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("3.Kordinat alındı.");
                        break;
                    }
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor = au3.PixelGetColor(Convert.ToInt32(Hp53KoordX.Text), Convert.ToInt32(Hp53KoordY.Text));
            Color hp = inttorgb(hpcolor);

            if (hp.B < 40)
            {
                au3.Send(textBox8.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    Hp54KoordX.Text = cursorhp.X.ToString();
                    Hp54KoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("4.Kordinat alındı.");
                        break;
                    }
                }
            }
        }


        private void timer8_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor = au3.PixelGetColor(Convert.ToInt32(Hp54KoordX.Text), Convert.ToInt32(Hp54KoordY.Text));
            Color hp = inttorgb(hpcolor);

            if (hp.B < 40)
            {
                au3.Send(textBox9.Text);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    Hp55KoordX.Text = cursorhp.X.ToString();
                    Hp55KoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("5.Kordinat alındı.");
                        break;
                    }
                }
            }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor = au3.PixelGetColor(Convert.ToInt32(Hp55KoordX.Text), Convert.ToInt32(Hp55KoordY.Text));
            Color hp = inttorgb(hpcolor);

            if (hp.B < 40)
            {
                au3.Send(textBox10.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    Hp56KoordX.Text = cursorhp.X.ToString();
                    Hp56KoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("6.Kordinat alındı.");
                        break;
                    }
                }
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor = au3.PixelGetColor(Convert.ToInt32(Hp56KoordX.Text), Convert.ToInt32(Hp56KoordY.Text));
            Color hp = inttorgb(hpcolor);

            if (hp.B < 40)
            {
                au3.Send(textBox11.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    Hp57KoordX.Text = cursorhp.X.ToString();
                    Hp57KoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("7.Kordinat alındı.");
                        break;
                    }
                }
            }
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor = au3.PixelGetColor(Convert.ToInt32(Hp57KoordX.Text), Convert.ToInt32(Hp57KoordY.Text));
            Color hp = inttorgb(hpcolor);

            if (hp.B < 40)
            {
                au3.Send(textBox12.Text);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Point cursorhp;
            while (true)
            {
                int flag = 0;
                if ((GetAsyncKeyState(Keys.K) & 0x8000) != 0)
                {
                    cursorhp = GetCursorPosition();
                    Hp58KoordX.Text = cursorhp.X.ToString();
                    Hp58KoordY.Text = cursorhp.Y.ToString();
                    flag++;
                    if (flag != 0)
                    {
                        MessageBox.Show("8.Kordinat alındı.");
                        break;
                    }
                }
            }
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            var hpcolor = 0xB90000;
            hpcolor = au3.PixelGetColor(Convert.ToInt32(Hp58KoordX.Text), Convert.ToInt32(Hp58KoordY.Text));
            Color hp = inttorgb(hpcolor);

            if (hp.B < 40)
            {
                au3.Send(textBox13.Text);
            }
        }


        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer A tuşuna basıldıysa, Attack Start metotunu çağır
            if (e.KeyChar == (char)Keys.F11)
            {
                AttackStart();
            }
            // Eğer D tuşuna basıldıysa, Attack Stop metotunu çağır
            else if (e.KeyChar == (char)Keys.F12)
            {
                AttackStop();
            }
        }


        // Attack Start metotu
        private void AttackStart()
        {
                au3.WinActivate(textBox1.Text);
                au3.Sleep(3000);
                timer1.Interval = trackBar1.Value;
                button2.Text = "Attack Start";

                if (OtoAtak.Checked == true)
                {
                    timer1.Enabled = true;
                }
                if (OtoWolf.Checked == true)
                {
                    timer2.Enabled = true;
                }
                if (OtoDef.Checked == true)
                {
                    timer3.Enabled = true;
                }
                if (OtoHp.Checked == true)
                {
                    timer4.Enabled = true;
                }
                if (OtoHp52.Checked == true)
                {
                    timer6.Enabled = true;
                }
                if (OtoHp53.Checked == true)
                {
                    timer7.Enabled = true;
                }
                if (OtoHp54.Checked == true)
                {
                    timer8.Enabled = true;
                }
                if (OtoHp55.Checked == true)
                {
                    timer9.Enabled = true;
                }
                if (OtoHp56.Checked == true)
                {
                    timer10.Enabled = true;
                }
                if (OtoHp57.Checked == true)
                {
                    timer11.Enabled = true;
                }
                if (OtoHp58.Checked == true)
                {
                    timer12.Enabled = true;
                }
                if (OtoMp.Checked == true)
                {
                    timer5.Enabled = true;
                }

                button2.Text = "Attack Stop";

            // Eğer "Attack Start" düğmesine tıklamış gibi davran
            button2.PerformClick();
            }

    // Attack Stop metotu
        private void AttackStop()
        {
            button2.Text = "Attack Start";
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;
            timer8.Enabled = false;
            timer9.Enabled = false;
            timer10.Enabled = false;
            timer11.Enabled = false;
            timer12.Enabled = false;
            // Eğer "Attack Stop" düğmesine tıklamış gibi davran
            button2.PerformClick();
        }

    }
}
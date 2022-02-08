using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int yerCekimi = 5;
        int hiz = 7;
        Random rnd = new Random();
        int score = 0;


        public Form1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            score += 1;

                if (score > 0)
                {
                    lblPuan.Text = Convert.ToString(score);

                }
            pbBird.Top += yerCekimi;


            if (pbBird.Bottom == pictureBox1.Top)
            {
                tmrGame.Stop();
            }
            pbPipe1.Left -= hiz;
            pbPipe2.Left -= hiz;
            pbPipe3.Left -= hiz;
            pbPipe4.Left -= hiz;



            if (pbPipe1.Right <= 0)
            {
                pbPipe1.Left = ClientSize.Width + rnd.Next(200);
            }
            if (pbPipe2.Right <= 0)
            {
                pbPipe2.Left = ClientSize.Width + rnd.Next(200);
            }
            if (pbPipe3.Right <= 0)
            {
                pbPipe3.Left = pbPipe1.Left + rnd.Next(200) + pbPipe1.Width;
            }

            if (pbPipe4.Right <= 0)
            {
                pbPipe4.Left = pbPipe2.Left + rnd.Next(200) + pbPipe2.Width;
            }

            if (pbPipe1.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe2.Bounds.IntersectsWith(pbBird.Bounds)
                || pbPipe3.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe4.Bounds.IntersectsWith(pbBird.Bounds)
                 || pictureBox1.Bounds.IntersectsWith(pbBird.Bounds)) // 4 boru ve zemin için...
            {
                tmrGame.Stop();
                DialogResult dr = MessageBox.Show($" Points : {score} \r\n GAME OVER! \r\n Do you want to play again ? ", "Flappy Bird", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    tmrGame.Start();
                    pbBird.Left = 10;
                    pbBird.Top = 200;
                    score = 0;
                    pbPipe1.Left = ClientSize.Width;
                    pbPipe2.Left = ClientSize.Width;
                    pbPipe3.Left = pbPipe1.Left + rnd.Next(200) + pbPipe1.Width;
                    pbPipe4.Left = pbPipe2.Left + rnd.Next(200) + pbPipe2.Width;

                }
                else
                {
                    Close();
                }





            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && tmrGame.Enabled)
            {
                if (pbBird.Top > 0)
                {
                    pbBird.Top -= 50;
                    pbBird.Top = pbBird.Top < 0 ? 0 : pbBird.Top;    // ekrandan taşmaması için...
                }

            }



        }

    }
}

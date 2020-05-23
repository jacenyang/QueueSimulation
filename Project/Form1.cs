using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile("../Image/logo.png");

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            label4.Text = "Nama";
            label5.Text = "No.";
            label6.Text = "Total Waktu Antrian";
        }

        public Queue antriNama = new Queue();
        public Queue antriWaktu = new Queue();
        private Timer timer1;
        private Timer timer2;
        private int waktu = 0;
        private int nomor = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (waktu == 0)
            {
                timer1 = new Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 detik

                timer2 = new Timer();
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Interval = 60000; // 60 detik / 1 menit

                timer1.Start();
                timer2.Start();
            }

            else
            {

            }         

            waktu += 60;
            label2.Text = waktu.ToString();
            nomor++;

            if (antriNama.Count < 5 && antriWaktu.Count < 5)
            {
                label1.Text = "";
                antriNama.Enqueue(textBox1.Text.ToString());
                foreach (string a in antriNama)
                {
                    label1.Text += a.ToString() + "\n";
                }

                label3.Text = "";
                antriWaktu.Enqueue(nomor.ToString());
                foreach (string b in antriWaktu)
                {
                    label3.Text += b.ToString() + "\n";
                }
            }

            else
            {
                MessageBox.Show("Antrian penuh, mohon tunggu beberapa saat.");
            }
            textBox1.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (waktu > 0)
            {
                waktu--;
                label2.Text = waktu.ToString();
            }

            else
            {
                timer1.Stop();
                timer2.Stop();

                nomor = 0;
                label2.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string sekarang = new StringReader(label3.Text).ReadLine();
            switch (sekarang)
            {
                case "1":
                    System.Media.SoundPlayer player1 = new System.Media.SoundPlayer("../Audio/1.wav");
                    player1.Play();
                    break;
                case "2":
                    System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("../Audio/2.wav");
                    player2.Play();
                    break;
                case "3":
                    System.Media.SoundPlayer player3 = new System.Media.SoundPlayer("../Audio/3.wav");
                    player3.Play();
                    break;
                case "4":
                    System.Media.SoundPlayer player4 = new System.Media.SoundPlayer("../Audio/4.wav");
                    player4.Play();
                    break;
                case "5":
                    System.Media.SoundPlayer player5 = new System.Media.SoundPlayer("../Audio/5.wav");
                    player5.Play();
                    break;
                default:
                    break;
            }

            label1.Text = "";
            string c = (string)antriNama.Dequeue();
            foreach (string a in antriNama)
            {
                label1.Text += a.ToString() + "\n";
            }

            label3.Text = "";
            string d = (string)antriWaktu.Dequeue();
            foreach (string b in antriWaktu)
            {
                label3.Text += b.ToString() + "\n";
            }
        }
    }
}
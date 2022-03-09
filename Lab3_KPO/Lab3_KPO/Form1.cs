using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_KPO
{
    public partial class Form1 : Form
    {
		public Form1()
		{
			InitializeComponent();

		}
		VideoStream videoStream1, videoStream2;


		private void button1_Click(object sender, EventArgs e)
		{
			videoStream1.Start(textBox1.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			videoStream1.Pause();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			videoStream1.Stop();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			videoStream2.Stop();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			videoStream2.Pause();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			videoStream2.Start(textBox2.Text);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			videoStream1 = new VideoStream(pictureBox1, "http://87.74.39.57:80/mjpg/video.mjpg", flowLayoutPanel1);
			videoStream2 = new VideoStream(pictureBox2, "http://79.206.128.86:80/mjpg/video.mjpg", flowLayoutPanel2);
		}
	}
}

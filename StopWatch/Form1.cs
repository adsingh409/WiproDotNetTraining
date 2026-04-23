using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        int seconds = 0;
        int minutes = 0;
        int hours = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            hours = 0;
            minutes = 0;
            seconds = 0;

            label1.Text = "00:00:00";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }

            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }

            label1.Text = hours.ToString("00") + " : " +
                          minutes.ToString("00") + " : " +
                          seconds.ToString("00");


        }
    }
}

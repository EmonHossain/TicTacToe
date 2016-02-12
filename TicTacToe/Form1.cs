using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        private Button[] button;
        private int x = 50, y = 50;
        private int n = 1,checker=0;
        private int flag = 1;
        private int begin = 0;
        private Label label;
        private Timer timer,t;
        private Random random;
        public Form1()
        {
            InitializeComponent();
            button = new Button[9];
            random = new Random(); 

            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 800;

            t = new Timer();
            t.Interval = 500;
            t.Tick += t_Tick;

            for (int i = 0; i < 9; i++)
            {
                button[i] = new Button();
                button[i].Size = new Size(50,50);
                button[i].Location = new Point(x, y);
                button[i].Click += Form1_Click;
                Controls.Add(button[i]);
                if (n == 3)
                {
                    y += 50;
                    n = 0;
                    x = 50;
                }
                else
                    x+=50;
                n++;
            }
            label = new Label();
            label.Text = "Your turn";
            label.Location = new Point(300, 120);
            Controls.Add(label);

            playButton.Enabled = false;
            playButton.BackColor = Color.Red;

        }

        void t_Tick(object sender, EventArgs e)
        {
            if (flag >= 5 && flag <=10)
            {
                if ((button[0].Text.Equals("X") && button[1].Text.Equals("X") && button[2].Text.Equals("X")) || (button[0].Text.Equals("X") && button[3].Text.Equals("X") && button[6].Text.Equals("X")) || (button[0].Text.Equals("X") && button[4].Text.Equals("X") && button[8].Text.Equals("X")) || (button[1].Text.Equals("X") && button[4].Text.Equals("X") && button[7].Text.Equals("X")) || (button[2].Text.Equals("X") && button[4].Text.Equals("X") && button[6].Text.Equals("X")) || (button[2].Text.Equals("X") && button[5].Text.Equals("X") && button[8].Text.Equals("X")) || (button[3].Text.Equals("X") && button[4].Text.Equals("X") && button[5].Text.Equals("X")) || (button[6].Text.Equals("X") && button[7].Text.Equals("X") && button[8].Text.Equals("X")))
                {
                    t.Enabled = false;
                    t.Stop();
                    timer.Enabled = false;
                    timer.Stop();
                    deactivator();
                    label.Text = "";
                    playButton.Enabled = true;
                    MessageBox.Show("You won....!!!");
                    checker = 0;
                }
                else if ((button[0].Text.Equals("O") && button[1].Text.Equals("O") && button[2].Text.Equals("O")) || (button[0].Text.Equals("O") && button[3].Text.Equals("O") && button[6].Text.Equals("O")) || (button[0].Text.Equals("O") && button[4].Text.Equals("O") && button[8].Text.Equals("O")) || (button[1].Text.Equals("O") && button[4].Text.Equals("O") && button[7].Text.Equals("O")) || (button[2].Text.Equals("O") && button[4].Text.Equals("O") && button[6].Text.Equals("O")) || (button[2].Text.Equals("O") && button[5].Text.Equals("O") && button[8].Text.Equals("O")) || (button[3].Text.Equals("O") && button[4].Text.Equals("O") && button[5].Text.Equals("O")) || (button[6].Text.Equals("O") && button[7].Text.Equals("O") && button[8].Text.Equals("O")))
                {
                    t.Enabled = false;
                    t.Stop();
                    timer.Enabled = false;
                    timer.Stop();
                    deactivator();
                    label.Text = "";
                    playButton.Enabled = true;
                    MessageBox.Show("You lose..!!!");
                    checker = 0;
                }
                else if (flag == 10 && checker != 0)
                {
                    t.Enabled = false;
                    t.Stop();
                    timer.Enabled = false;
                    timer.Stop();
                    deactivator();
                    label.Text = "";
                    MessageBox.Show("Tie");
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (flag % 2 == 0)
            {
                while (flag%2==0) { 
                    int rand = random.Next(0, 8);
                    if (!button[rand].Text.Equals("O") && !button[rand].Text.Equals("X"))
                    {
                        button[rand].Text = "O";
                        label.Text = "Your turn";
                        flag++;
                        if(flag>=9){
                            timer.Enabled = false;
                            timer.Stop();
                        }
                    }
                }
            }
        }

        void Form1_Click(object sender, EventArgs e)
        {
            if (begin == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (sender.Equals(button[i]))
                    {
                        button[i].Text = "X";
                        //button[i].Enabled = false;
                        label.Text = "Computer turn";
                        flag++;
                    }
                }
                timer.Enabled = true;
                timer.Start();

                
                t.Enabled = true;
                t.Start();

                begin++;
            }
            if (sender.Equals(button[0]) && !button[0].Text.Equals("O") && !button[0].Text.Equals("X"))
            {
                button[0].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[1]) && !button[1].Text.Equals("O") && !button[1].Text.Equals("X"))
            {
                button[1].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[2]) && !button[2].Text.Equals("O") && !button[2].Text.Equals("X"))
            {
                button[2].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[3]) && !button[3].Text.Equals("O") && !button[3].Text.Equals("X"))
            {
                button[3].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[4]) && !button[4].Text.Equals("O") && !button[4].Text.Equals("X"))
            {
                button[4].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[5]) && !button[5].Text.Equals("O") && !button[5].Text.Equals("X"))
            {
                button[5].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[6]) && !button[6].Text.Equals("O") && !button[6].Text.Equals("X"))
            {
                button[6].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[7]) && !button[7].Text.Equals("O") && !button[7].Text.Equals("X"))
            {
                button[7].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }
            else if (sender.Equals(button[8]) && !button[8].Text.Equals("O") && !button[8].Text.Equals("X"))
            {
                button[8].Text = "X";
                label.Text = "Computer turn";
                flag++;
            }           
        }
        private void deactivator()
        {
            for (int i = 0; i < 9; i++)
            {
                button[i].Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            for (int i=0; i < 9; i++)
            {
                button[i].Text = null;
                button[i].Enabled = true;
            }
            flag = 1;
            begin = 0;
            playButton.Enabled = false;
            playButton.BackColor = Color.Red;
        }
    }
}

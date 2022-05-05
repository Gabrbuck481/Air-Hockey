using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(275, 550, 60, 10);
        Rectangle player2 = new Rectangle(275, 50, 60, 10);
        Rectangle ball = new Rectangle(295, 292, 20, 20);
        Rectangle topGoal = new Rectangle(200, 0, 150, 5);
        Rectangle bottomGoal = new Rectangle(200, 600, 150, 5);


        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 10;
        int ballXSpeed = 8;
        int ballYSpeed = -8;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        Pen drawPen = new Pen(Color.Blue);
        public Form1()
        {
            InitializeComponent();
        }





        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        private void gameEngine_Tick(object sender, EventArgs e)
        {
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //move player 1 
            if (wDown == true && player1.Y > 300)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }
            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }
            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }
            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < 290)
            {
                player2.Y += playerSpeed;
            }
            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }
            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }


            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
            }
            if (ball.X < 0 || ball.X > this.Width - ball.Width)
            {
                ballXSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
            }


            if (player1.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                if (ballYSpeed < 0) //moving up
                {
                    ball.Y = player1.Y - ball.Height;
                }
                else
                {
                    ball.Y = player1.Y + ball.Height;
                }
            }


            if (player2.IntersectsWith(ball))
            {
                ballYSpeed *= -1;

                if (ballYSpeed < 0) //moving up
                {
                    ball.Y = player2.Y - ball.Height;
                }
                else
                {
                    ball.Y = player2.Y + ball.Height;
                }


            }

            if (topGoal.IntersectsWith(ball))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";

                ball.X = 295;
                ball.Y = 195;

                //player1.Y = 170;
                //player2.Y = 170;
            }
            if (bottomGoal.IntersectsWith(ball))
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                ball.X = 295;
                ball.Y = 195;

                //player1.Y = 170;
                //player2.Y = 170;
            }
            //else if (ball.X > 600)
            //{
            //    player1Score++;
            //    p1ScoreLabel.Text = $"{player1Score}";

            //    ball.X = 295;
            //    ball.Y = 195;

            //    player1.Y = 170;
            //    player2.Y = 170;
            //}
            //if (player1Score == 3)
            //{
            //    gameTimer.Enabled = false;
            //    winLabel.Visible = true;
            //    winLabel.Text = "Player 1 Wins!!";
            //}
            //else if (player2Score == 3)
            //{
            //    gameTimer.Enabled = false;
            //    winLabel.Visible = true;
            //    winLabel.Text = "Player 2 Wins!!";
            //}

            //}




            Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(drawPen, 0, 297, 583, 297);
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball);
            e.Graphics.FillRectangle(whiteBrush, topGoal);
            e.Graphics.FillRectangle(whiteBrush, bottomGoal);
        }

        private void p2ScoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at
        public static int guess = 0;
        SoundPlayer red = new SoundPlayer(Properties.Resources.red);
        SoundPlayer blue = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer green = new SoundPlayer(Properties.Resources.green);
        SoundPlayer yellow = new SoundPlayer(Properties.Resources.yellow);
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.game.Stop();
            GraphicsPath greenPath = new GraphicsPath();
            GraphicsPath redPath = new GraphicsPath();
            GraphicsPath yellowPath = new GraphicsPath();
            GraphicsPath bluePath = new GraphicsPath();
            greenPath.AddEllipse(10, 10, 200, 200);
            redPath.AddEllipse(-100, 10, 200, 200);
            yellowPath.AddEllipse(10, -100, 200, 200);
            bluePath.AddEllipse(-100, -100, 200, 200);
            greenPath.AddEllipse(75, 75, 80, 80);
            redPath.AddEllipse(-47, 75, 80, 80);
            yellowPath.AddEllipse(75, -40, 80, 80);
            bluePath.AddEllipse(-47, -40, 80, 80);
            greenButton.Region = new Region(greenPath);
            redButton.Region = new Region(redPath);
            yellowButton.Region = new Region(yellowPath);
            blueButton.Region = new Region(bluePath);
            Form1.Pattern.Clear();
            this.Refresh();
            Thread.Sleep(1000);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            Random randNum = new Random();
            int CPU;
            CPU = randNum.Next(0, 4);
            Form1.Pattern.Add(CPU);

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for(int i = 0; i < Form1.Pattern.Count(); i++)
            {
                if(Form1.Pattern[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    green.Play();
                    greenButton.Refresh();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    greenButton.Refresh();
                }
                if(Form1.Pattern[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    red.Play();
                    redButton.Refresh();
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                    redButton.Refresh();
                }
                if(Form1.Pattern[i] == 2)
                {
                    yellowButton.BackColor = Color.Yellow;
                    yellow.Play();
                    yellowButton.Refresh();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    yellowButton.Refresh();
                }
                if(Form1.Pattern[i] == 3)
                {
                    blueButton.BackColor = Color.Blue;
                    blue.Play();                  
                    blueButton.Refresh();
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                    blueButton.Refresh();
                }
                
            }
            //TODO: get guess index value back to 0
            guess = 0;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index equal to a green. If so:
            if (Form1.Pattern[guess] == 0)
            {
                greenButton.BackColor = Color.LimeGreen;
                green.Play();
                greenButton.Refresh();
                Thread.Sleep(500);
                greenButton.BackColor = Color.ForestGreen;
                greenButton.Refresh();
                // light up button, play sound, and pause
                // set button colour back to original
                // add one to the guess index
                guess++;
            }
            else
            {
                // else call GameOver method
                GameOver();
            }
            if (guess == Form1.Pattern.Count)
            {
                // check to see if we are at the end of the pattern. If so:
                ComputerTurn();
                // call ComputerTurn() method
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.Pattern[guess] == 1)
            {
                redButton.BackColor = Color.Red;
                red.Play();
                redButton.Refresh();
                Thread.Sleep(500);
                redButton.BackColor = Color.DarkRed;
                redButton.Refresh();
                // light up button, play sound, and pause
                // set button colour back to original
                // add one to the guess index
                guess++;
            }
            else
            {
                // else call GameOver method
                GameOver();
            }
            if (guess == Form1.Pattern.Count)
            {
                // check to see if we are at the end of the pattern. If so:
                ComputerTurn();
                // call ComputerTurn() method
            }

        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.Pattern[guess] == 2)
            {
                yellowButton.BackColor = Color.Yellow;
                yellow.Play();
                yellowButton.Refresh();
                Thread.Sleep(500);
                yellowButton.BackColor = Color.Goldenrod;
                yellowButton.Refresh();
                // light up button, play sound, and pause
                // set button colour back to original
                // add one to the guess index
                guess++;
            }
            else
            {
                // else call GameOver method
                GameOver();
            }
            if (guess == Form1.Pattern.Count)
            {
                // check to see if we are at the end of the pattern. If so:
                ComputerTurn();
                // call ComputerTurn() method
            }

        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.Pattern[guess] == 3)
            {
                blueButton.BackColor = Color.Blue;
                blue.Play();
                blueButton.Refresh();
                Thread.Sleep(500);
                blueButton.BackColor = Color.DarkBlue;
                blueButton.Refresh();
                // light up button, play sound, and pause
                // set button colour back to original
                // add one to the guess index
                guess++;
            }
            else
            {
                // else call GameOver method
                GameOver();
            }
            if (guess == Form1.Pattern.Count)
            {
                // check to see if we are at the end of the pattern. If so:
                ComputerTurn();
                // call ComputerTurn() method
            }

        }
    }
}

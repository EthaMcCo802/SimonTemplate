﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            //TODO: remove this screen and start the GameScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            //TODO: end the application
            Form f = this.FindForm();
            f.Close();
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            Form1.game.Play();
        }
    }
}

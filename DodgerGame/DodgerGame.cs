﻿using DodgerGame.Constants;
using DodgerGame.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgerGame
{
    public partial class DodgerGame : Form
    {
        DodgerWorld _dodgerWorld;
        GameState _gameState = GameState.Loaded;

        public DodgerGame()
        {
            this.Shown += DodgerGame_Shown;
            this.Height = 600;
            this.Width = 800;
            InitializeComponent();
            _gameState = GameState.Loaded;
            GameTimer.Interval = 50;
            GameTimer.Enabled = true;
            GameTimer.Start();
            _gameState = GameState.Running;
        }

        void DodgerGame_Shown(object sender, EventArgs e)
        {
            _dodgerWorld = new DodgerWorld();
            this.Controls.Clear();
            this.Controls.Add(_dodgerWorld.dodgerWorld);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _dodgerWorld.DropRain();
            _dodgerWorld.RenderWorld();
        }

        private void DodgerGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(_gameState == GameState.Running))
                return;


            switch (e.KeyCode)
            {
                case Keys.Left:
                    _dodgerWorld.MovePlayerLeft();
                    break;
                case Keys.Right:
                    _dodgerWorld.MovePlayerRight();
                    break;
                default:
                    return;
            }

        }

        private void DodgerGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(_gameState == GameState.Running))
                return;


            switch (e.KeyChar)
            {
                case (char)Keys.Left:
                    _dodgerWorld.MovePlayerLeft();
                    break;
                case (char)Keys.Right:
                    _dodgerWorld.MovePlayerRight();
                    break;
                default:
                    return;
            }

        }
    }
}

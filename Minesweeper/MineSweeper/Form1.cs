using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _squareWidth = 30;
        private int _height;
        private int _width;
        private int _numberOfMines;
        private int _numberOfFlaggedFields;
        private MineSweeper _mineSweeper;
        private DateTime _startTime;
        private bool _opening; // to check if it's the player's first time clicking on the pictureBox, if it is then method for setting mines should be called
        private bool _gameOver;




        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_gameOver)
            {
                int x = e.X;
                int y = e.Y;
                MouseEventArgs mouse = e;
                var clickedField = _mineSweeper.FindField(x, y);
                if (!clickedField.Open)
                {
                    if (mouse.Button == MouseButtons.Right)
                    {
                        if (clickedField.Flagged)
                        {
                            clickedField.Flagged = false;
                            _numberOfFlaggedFields--;
                        }
                        else
                        {
                            clickedField.Flagged = true;
                            _numberOfFlaggedFields++;
                        }
                    }

                    if (mouse.Button == MouseButtons.Left)
                    {
                        if (!clickedField.Flagged)
                        {
                            clickedField.Open = true;
                            if (_opening)
                            {
                                _opening = false;
                                _mineSweeper.SettingMines(startField: clickedField);
                                _startTime = DateTime.UtcNow;
                                timer1.Start(); // start measuring time
                            }

                            if (clickedField.Mine)
                            {
                                _mineSweeper.ShowMines();
                                _gameOver = true;
                                MessageBox.Show("YOU LOST!");
                                return;
                            }
                            else
                            {
                                clickedField.Show(_mineSweeper.GraphicTools);
                                _mineSweeper.OpenFields(clickedField);
                            }
                        }
                    }

                    minesRemainingLBL.Text = (_numberOfMines - _numberOfFlaggedFields).ToString();
                    clickedField.Show(_mineSweeper.GraphicTools);
                    if (_numberOfMines == _numberOfFlaggedFields) // check if player won
                    {
                        if (_mineSweeper.PlayerWon())
                        {
                            _gameOver = true;
                            MessageBox.Show("YOU WON!");
                        }
                    }
                }
            }
        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            if (beginnerRB.Checked)
            {
                _height = 9;
                _width = 9;
                _numberOfMines = 10;
            }
            if (intermediateRB.Checked)
            {
                _height = 16;
                _width = 16;
                _numberOfMines = 40;
            }
            if (expertRB.Checked)
            {
                _height = 16;
                _width = 30;
                _numberOfMines = 99;
            }

            _opening = true;
            _gameOver = false;
            _numberOfFlaggedFields = 0;
            minesRemainingLBL.Text = (_numberOfMines - _numberOfFlaggedFields).ToString();
            timer1.Stop();
            timeLBL.Text = "000";
            int distanceFromTopOfForm = 100;
            pictureBox1.SetBounds(
                x: ClientRectangle.Width / 2 - _width * _squareWidth / 2,
                y: distanceFromTopOfForm + ((ClientRectangle.Height - distanceFromTopOfForm) - _height * _squareWidth) / 2,
                width: _width * _squareWidth,
                height: _height * _squareWidth);
            pictureBox1.Refresh();
            var graphicTools = new GraphicTools(pictureBox1.CreateGraphics(), new Pen(Color.Gray, 2),
                new SolidBrush(Color.LightSlateGray), new SolidBrush(Color.DarkGray));
            _mineSweeper = new MineSweeper(_height, _width, _numberOfMines, _squareWidth, graphicTools);
            _mineSweeper.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_gameOver)
                return;
            var timeSpent = DateTime.UtcNow - _startTime;
            timeLBL.Text = timeSpent.TotalSeconds.ToString("000");
        }
    }
}

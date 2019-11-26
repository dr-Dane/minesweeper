using System;
using System.Collections.Generic;
using System.Drawing;

namespace MineSweeper
{
    public class MineSweeper
    {
        private Field[,] _fields;
        private int _height;
        private int _width;
        public int NumberOfMines { get; set; }
        public int SquareWidth { get; set; }
        private GraphicTools _graphicTools;

        public GraphicTools GraphicTools
        {
            get { return _graphicTools; }
        }


        public MineSweeper(int height, int width, int numberOfMines, int squareWidth, GraphicTools graphicTools)
        {
            this._height = height;
            this._width = width;
            this.NumberOfMines = numberOfMines;
            this.SquareWidth = squareWidth;
            this._graphicTools = graphicTools;
            this._fields = new Field[height, width];
            Form();
        }

        private void Form()
        {
            int currentY = 0;
            for (int i = 0; i < _height; i++)
            {
                int currentX = 0;
                for (int j = 0; j < _width; j++)
                {
                    _fields[i, j] = new Field(currentX, currentY, SquareWidth);
                    currentX += SquareWidth;
                }

                currentY += SquareWidth;
            }
        }

        public void Show()
        {
            //_graphicTools.Graphic.Clear(Color.Black);
            foreach (var field in _fields)
            {
                field.Show(_graphicTools);
            }
        }

        public Field FindField(int x, int y)
        {
            return _fields[y / SquareWidth, x / SquareWidth];
        }

        private void GetFieldCoordinates(Field field, out int i, out int j)
        {
            i = field.Y / SquareWidth;
            j = field.X / SquareWidth;
        }

        public void SettingMines(Field startField) // I don't want first opened field to be surrounded by mines, so the player is guaranteed
        {                                          // that area around first field(radious of two blocks) doesn't contain mines        
            int startI; //indexes of starting field in matrix
            int startJ;

            GetFieldCoordinates(startField, out startI, out startJ);

            Random random = new Random();
            int minesCount = 0;
            List<int> fieldsWithMines = new List<int>();
            while (minesCount < NumberOfMines)
            {
                int nextMine = random.Next(0, _height * _width);
                if (fieldsWithMines.Contains(nextMine))
                    continue;
                int nextI = nextMine / _width; // indexes of randomly chosen field, now they should be checked to make sure that next field is not close to starting field
                int nextJ = nextMine % _width;

                if (Math.Abs(nextI - startI) <= 2 && Math.Abs(nextJ - startJ) <= 2)
                {
                    continue; // if they are in radious of 2 fields around starting field, I won't set mine to them
                }

                fieldsWithMines.Add(nextMine);
                _fields[nextI, nextJ].Mine = true;
                minesCount++;
            }

            CountMines();
        }

        private void CountMines()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_fields[i, j].Mine)
                        continue;
                    int mines = 0;
                    // left side
                    if (i > 0)
                    {
                        // top left
                        if (j > 0)
                        {
                            if (_fields[i - 1, j - 1].Mine)
                                mines++;
                        }

                        // center left
                        if (_fields[i - 1, j].Mine)
                        {
                            mines++;
                        }

                        //bottom left
                        if (j < _width - 1)
                        {
                            if (_fields[i - 1, j + 1].Mine)
                            {
                                mines++;
                            }
                        }
                    }

                    //top
                    if (j > 0)
                    {
                        if (_fields[i, j - 1].Mine)
                        {
                            mines++;
                        }
                    }

                    //bottom
                    if (j < _width - 1)
                    {
                        if (_fields[i, j + 1].Mine)
                        {
                            mines++;
                        }

                    }

                    //right side
                    if (i < _height - 1)
                    {
                        // top right
                        if (j > 0)
                        {
                            if (_fields[i + 1, j - 1].Mine)
                                mines++;
                        }

                        // center right
                        if (_fields[i + 1, j].Mine)
                        {
                            mines++;
                        }

                        //bottom right
                        if (j < _width - 1)
                        {
                            if (_fields[i + 1, j + 1].Mine)
                            {
                                mines++;
                            }
                        }
                    }

                    _fields[i, j].SurroundingMines = mines;
                }
            }
        }

        public void OpenFields(Field clickedField)
        {
            if (clickedField.SurroundingMines > 0)
                return;

            while (true)
            {
                bool openingFinished = true;
                foreach (var field in _fields)
                {
                    if (field.Open && field.SurroundingMines == 0)
                    {
                        //open surrounding fields
                        int i, j;
                        GetFieldCoordinates(field, out i, out j);

                        // left side
                        if (i > 0)
                        {
                            // top left
                            if (j > 0)
                            {
                                OpenField(_fields[i - 1, j - 1], ref openingFinished);
                            }
                            // center left
                            OpenField(_fields[i - 1, j], ref openingFinished);
                            //bottom left
                            if (j < _width - 1)
                            {
                                OpenField(_fields[i - 1, j + 1], ref openingFinished);
                            }
                        }
                        //top
                        if (j > 0)
                        {
                            OpenField(_fields[i, j - 1], ref openingFinished);
                        }
                        //bottom
                        if (j < _width - 1)
                        {
                            OpenField(_fields[i, j + 1], ref openingFinished);
                        }
                        //right side
                        if (i < _height - 1)
                        {
                            // top right
                            if (j > 0)
                            {
                                OpenField(_fields[i + 1, j - 1], ref openingFinished);
                            }

                            // center right
                            OpenField(_fields[i + 1, j], ref openingFinished);
                            //bottom right
                            if (j < _width - 1)
                            {
                                OpenField(_fields[i + 1, j + 1], ref openingFinished);
                            }
                        }
                    }
                }

                if (openingFinished)
                    break;
            }
        }

        private void OpenField(Field field, ref bool openingFinished)
        {
            if (field.Open || field.Flagged)
                return;
            openingFinished = false;
            field.Open = true;
            field.Show(_graphicTools);
        }


        public void ShowMines()
        {
            foreach (var field in _fields)
            {
                if (field.Mine)
                {
                    if (!field.Flagged)
                    {
                        field.Open = true;
                        field.Show(_graphicTools);

                        _graphicTools.Graphic.FillEllipse(new SolidBrush(Color.Black), field.X + SquareWidth / 6,
                            field.Y + SquareWidth / 6, 2 * SquareWidth / 3, 2 * SquareWidth / 3);
                    }
                }
                else
                {
                    if (field.Flagged) // drawing X over false flag
                    {
                        field.Flagged = false;
                        field.Open = true;
                        field.Show(_graphicTools);
                        _graphicTools.Graphic.FillEllipse(new SolidBrush(Color.Black), field.X + SquareWidth / 6,
                            field.Y + SquareWidth / 6, 2 * SquareWidth / 3, 2 * SquareWidth / 3);

                        _graphicTools.Graphic.DrawLine(Pens.Red, field.X + 1, field.Y + 1, field.X + SquareWidth - 1, field.Y + SquareWidth - 1);
                        _graphicTools.Graphic.DrawLine(Pens.Red, field.X + 1, field.Y + SquareWidth - 1, field.X + SquareWidth - 1, field.Y + 1);
                    }
                }
            }
        }

        public bool PlayerWon()
        {
            foreach (var field in _fields)
            {
                if (field.Mine && !field.Flagged)
                    return false;
                if (!field.Mine && !field.Open)
                    return false;
            }

            return true;
        }
    }
}
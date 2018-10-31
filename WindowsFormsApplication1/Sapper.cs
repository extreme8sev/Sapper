#region Usings

using System;
using System.Drawing;

#endregion

namespace WindowsFormsApplication1
{
    public class Sapper
    {
        public const int FieldSqX = 18; // Размер поля в ячейках
        public const int FieldSqY = 12;
        private const int NumberOfBomb = 40;
        public const int SquareF = 25; //Размер ячейки

        private readonly Cell[,] _field = new Cell[FieldSqX, FieldSqY];

        private readonly Graphics _gameFieldGraph;

        private readonly Pen _userBlack = new Pen(Color.Black, 2);
        private readonly Brush _userDarkGreyBrush = Brushes.DarkGray;
        private readonly Font _userFont = new Font("Times New Roman", 15);
        private readonly Brush _userLightGreyBrush = Brushes.LightGray;
        private bool _isFirstClick;
        public int NumberOfBombLeft;


        public Sapper(Graphics grf)
        {
            _gameFieldGraph = grf;
            for (var i = 0; i < FieldSqX; i++)
            {
                for (var j = 0; j < FieldSqY; j++)
                {
                    _field[i, j] = new Cell();
                }
            }
        }

        public void DrawGameFieldLines() //Рисует СЕТКУ ПОЛЯ
        {
            for (var i = 0; i < FieldSqX + 1; i++)
            {
                _gameFieldGraph.DrawLine(_userBlack, 
                                        i * SquareF + 5,
                                        5,
                                        i * SquareF + 5,
                                        SquareF * FieldSqY + 5);
            }

            for (var i = 0; i < FieldSqY + 1; i++)
            {
                _gameFieldGraph.DrawLine(_userBlack,
                                        5,
                                        i * SquareF + 5,
                                        SquareF * FieldSqX + 5,
                                        i * SquareF + 5);
            }
        }

        public void ClickThisPoint(Point point)
        {
            var x = (point.X - 5) / SquareF;
            var y = (point.Y - 5) / SquareF;
            if (x >= 0 && y >= 0 && x < FieldSqX && y < FieldSqY)
            {
                _field[x, y].Open();
                if (_field[x, y].Value == 0)
                {
                    ExpandZeroes();
                }
                else if (_isFirstClick)
                {
                    RandomizeBomb();
                    ClickThisPoint(point);
                }
                DrawOneCell(x, y);
                _isFirstClick = false;
            }
        }

        public int thisPoinIsChoosed(Point thisPoint)
        {
            var x = (thisPoint.X - 5) / SquareF;
            var y = (thisPoint.Y - 5) / SquareF;
            if (x >= 0 && y >= 0 && x < FieldSqX && y < FieldSqY && !_field[x, y].IsOpened) //wtf???
            {
                if (_field[x, y].IsSelected)
                {
                    NumberOfBombLeft++;
                }
                else
                {
                    NumberOfBombLeft--;
                }

                _field[x, y].Select();
                DrawOneCell(x, y);
            }

            return NumberOfBombLeft;
        }


        private void ExpandZeroes()
        {
            var counter = 0;
            //Раскрываем нули 
            for (int i = 0; i < FieldSqX; i++)
            {
                for (int j = 0; j < FieldSqY; j++)
                {
                    if (_field[i, j].Value == 0 && _field[i, j].IsOpened)
                    {
                        if (j < FieldSqY - 1 && !_field[i, j + 1].IsOpened)
                        {
                            if (_field[i, j + 1].Value == 0)
                                {
                                   counter++;
                                }

                            _field[i, j + 1].Open();
                            DrawOneCell(i, j + 1);
                        }

                    if (j > 0 && !_field[i, j - 1].IsOpened)
                    {
                        if (_field[i, j - 1].Value == 0)
                            {
                                counter++;
                            }

                         _field[i, j - 1].Open();
                         DrawOneCell(i, j - 1);
                    }

                    if (i < FieldSqX - 1 && !_field[i + 1, j].IsOpened)
                    {
                        if (_field[i + 1, j].Value == 0)
                            {
                                counter++;
                            }

                         _field[i + 1, j].Open();
                         DrawOneCell(i + 1, j);
                    }

                    if (i > 0 && !_field[i - 1, j].IsOpened)
                    {
                        if (_field[i - 1, j].Value == 0)
                            {
                                counter++;
                            }

                        _field[i - 1, j].Open();
                        DrawOneCell(i - 1, j);
                    }

                    if (i < FieldSqX - 1 && j < FieldSqY - 1 && !_field[i + 1, j + 1].IsOpened)
                    {
                        if (_field[i + 1, j + 1].Value == 0)
                            {
                                counter++;
                            }

                        _field[i + 1, j + 1].Open();
                        DrawOneCell(i + 1, j + 1);
                    }

                    if (i < FieldSqX - 1 && j > 0 && !_field[i + 1, j - 1].IsOpened)
                    {
                        if (_field[i + 1, j - 1].Value == 0)
                            {
                                counter++;
                            }

                        _field[i + 1, j - 1].Open();
                        DrawOneCell(i + 1, j - 1);
                    }

                    if (i > 0 && j < FieldSqY - 1 && !_field[i - 1, j + 1].IsOpened)
                    {
                        if (_field[i - 1, j + 1].Value == 0)
                            {
                                counter++;
                            }

                        _field[i - 1, j + 1].Open();
                        DrawOneCell(i - 1, j + 1);
                    }

                    if (i > 0 && j > 0 && !_field[i - 1, j - 1].IsOpened)
                    {
                        if (_field[i - 1, j - 1].Value == 0)
                            {
                                counter++;
                            }

                        _field[i - 1, j - 1].Open();
                        DrawOneCell(i - 1, j - 1);
                    }
                }
                }
            }

            if (counter != 0)
            {
                ExpandZeroes();
            }
        }


        public void RandomizeBomb() //Расставляем бомбы
        {
            ClearGameField();
            _isFirstClick = true; //Обнуляем счетчик первого клика
            NumberOfBombLeft = NumberOfBomb; //Обнуляем количество оставшихся бомб
            //расставляем бомбы
            var rnd = new Random();
            int x, y;
            for (int i = 0; i < NumberOfBomb;)
            {
                x = rnd.Next(0, FieldSqX);
                y = rnd.Next(0, FieldSqY);
                if (_field[x, y].Value == 0)
                {
                    _field[x, y].Value = 13;
                    i++;
                }
            }

            //расставляем циферки 
            for (var i = 0; i < FieldSqX; i++)
            {
                for (var j = 0; j < FieldSqY; j++)
                {
                    if (_field[i, j].Value != 13)
                    {
                        var numberOfBomb = 0;
                        if (i == 0) //Верхний ряд
                        {
                            if (j == 0) //Верхний левый угол
                            {
                                if (_field[i + 1, j].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i + 1, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }
                            }
                            else if (j == FieldSqY - 1) //Верхний правый угол
                            {
                                if (_field[i + 1, j].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i + 1, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }
                            }
                            else
                            {
                                if (_field[i + 1, j].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i + 1, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i + 1, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }
                            }
                        }
                        else if (i == FieldSqX - 1) //Нижний ряд
                        {
                            if (j == 0) //Нижний левый угол
                            {
                                if (_field[i - 1, j].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i - 1, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }
                            }
                            else if (j == FieldSqY - 1) //Нижний правый угол
                            {
                                if (_field[i - 1, j].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i - 1, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }
                            }
                            else
                            {
                                if (_field[i - 1, j].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i - 1, j + 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }

                                if (_field[i - 1, j - 1].Value == 13)
                                {
                                    numberOfBomb++;
                                }
                            }
                        }
                        else if (j == 0) //Левый столбец
                        {
                            if (_field[i - 1, j].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i - 1, j + 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i, j + 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i + 1, j + 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i + 1, j].Value == 13)
                            {
                                numberOfBomb++;
                            }
                        }
                        else if (j == FieldSqY - 1) //Правый столбец
                        {
                            if (_field[i - 1, j].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i - 1, j - 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i, j - 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i + 1, j - 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i + 1, j].Value == 13)
                            {
                                numberOfBomb++;
                            }
                        }
                        else //Все остальное
                        {
                            if (_field[i + 1, j].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i, j + 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i + 1, j + 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i, j - 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i + 1, j - 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i - 1, j].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i - 1, j + 1].Value == 13)
                            {
                                numberOfBomb++;
                            }

                            if (_field[i - 1, j - 1].Value == 13)
                            {
                                numberOfBomb++;
                            }
                        }

                        _field[i, j].Value = (byte) numberOfBomb;
                    }
                }
            }
        }

        public void DrawAllCells()
        {
            for (var i = 0; i < FieldSqX; i++)
            {
                for (var j = 0; j < FieldSqY; j++)
                {
                    DrawOneCell(i, j);
                }
            }
        }

        private void DrawOneCell(int x, int y)
        {
            _gameFieldGraph.FillRectangle(_userLightGreyBrush, 7 + x * SquareF, 7 + y * SquareF, SquareF - 4, SquareF - 4);

            if (_field[x, y].IsSelected)
            {
                _gameFieldGraph.FillRectangle(Brushes.Orange, 7 + x * SquareF, 7 + y * SquareF, SquareF - 4, SquareF - 4);
                _gameFieldGraph.DrawString("!", _userFont, Brushes.Black, 7 + x * SquareF, 7 + y * SquareF);
            }
            else if (!_field[x, y].IsOpened)
            {
                _gameFieldGraph.FillRectangle(_userDarkGreyBrush, 7 + x * SquareF, 7 + y * SquareF, SquareF - 4, SquareF - 4);
            }
            else
            {
                switch (_field[x, y].Value)
                {
                    case 13:
                        _gameFieldGraph.FillRectangle(Brushes.DarkRed, 7 + x * SquareF, 7 + y * SquareF, SquareF - 4, SquareF - 4);
                        break;

                    case 0:
                        break;

                    case 1:
                        _gameFieldGraph.DrawString("1", _userFont, Brushes.Blue, 7 + x * SquareF, 7 + y * SquareF);
                        break;

                    case 2:
                        _gameFieldGraph.DrawString("2", _userFont, Brushes.Azure, 7 + x * SquareF, 7 + y * SquareF);
                        break;

                    case 3:
                        _gameFieldGraph.DrawString("3", _userFont, Brushes.Green, 7 + x * SquareF, 7 + y * SquareF);
                        break;

                    case 4:
                        _gameFieldGraph.DrawString("4", _userFont, Brushes.GreenYellow, 7 + x * SquareF, 7 + y * SquareF);
                        break;

                    case 5:
                        _gameFieldGraph.DrawString("5", _userFont, Brushes.Yellow, 7 + x * SquareF, 7 + y * SquareF);
                        break;

                    case 6:
                        _gameFieldGraph.DrawString("6", _userFont, Brushes.Orange, 7 + x * SquareF, 7 + y * SquareF);
                        break;

                    case 7:
                        _gameFieldGraph.DrawString("7", _userFont, Brushes.OrangeRed, 7 + x * SquareF, 7 + y * SquareF);
                        break;

                    case 8:
                        _gameFieldGraph.DrawString("8", _userFont, Brushes.Red, 7 + x * SquareF, 7 + y * SquareF);
                        break;
                }
            }
        }


        private void ClearGameField() //Снимаем бомбы и циферки с поля
        {
            for (var i = 0; i < FieldSqX; i++)
            {
                for (var j = 0; j < FieldSqY; j++)
                {
                    _field[i, j].SetToZero();
                }
            }

            DrawAllCells();
        }

        private Cell[] GetNeighbors(int x, int y)
        {

        }
    }
}
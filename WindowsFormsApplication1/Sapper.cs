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
                    DrawAllCells();
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

        public int OpenAllNeighbours(Point thisPoint)
        {
            var x = (thisPoint.X - 5) / SquareF;
            var y = (thisPoint.Y - 5) / SquareF;
            if (x >= 0 && y >= 0 && x < FieldSqX && y < FieldSqY && _field[x, y].IsOpened)
            {
                var NumberOfSelectedCells = 0;
                Cell[] NeighboursArrey = GetNeighbors(x, y);
                foreach (Cell cell in NeighboursArrey)
                {
                    if (cell != null && cell.IsSelected)
                    {
                        NumberOfSelectedCells++;
                    }
                }
                if (NumberOfSelectedCells == _field[x, y].Value)
                    foreach (Cell cell in NeighboursArrey)
                    {
                        if (cell != null && !cell.IsSelected && !cell.IsOpened)
                        {
                            cell.Open();
                            if (cell.Value == 0)
                            {
                                ExpandZeroes();
                            }
                        }
                    }
                DrawAllCells();
                return NumberOfSelectedCells;
            }
            return 0;
        }

        private void ExpandZeroes()
        {
            var counter = 0;
            //Раскрываем нули цепной реакцией 
            for (int i = 0; i < FieldSqX; i++)
            {
                for (int j = 0; j < FieldSqY; j++)
                {
                    if (_field[i, j].Value == 0 && _field[i, j].IsOpened)
                    {
                        Cell[] neighborsArray = GetNeighbors(i, j);
                        for (var v = 0; v < 8; v++)
                        {
                            if (neighborsArray[v]?.Value == 0)
                            {
                                if (!neighborsArray[v].IsOpened)
                                {
                                    counter++;
                                }
                            }
                            neighborsArray[v]?.Open();
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
                        Cell[] neighborsArray = GetNeighbors(i,j);
                        for (var v = 0; v < 8; v++)
                        {
                            if (neighborsArray[v]?.Value == 13)
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

        private Cell[] GetNeighbors(int i, int j) 
        //Возвращает массив всех соседних клеток для заданной координатами i,j.
        //Если клетка вышла за границу - ее место в массиве занимает null
        {
            Cell[] neighborsArray = new Cell[8];

            //----------------------------------------------
            //Find all neighborhoods cells for _field[i,j]'s cell
            var n = 0;

            if (j < FieldSqY - 1)
            {
                neighborsArray[n] = _field[i, j + 1];
            }
            n++;

            if (j > 0)
            {
                neighborsArray[n] = _field[i, j - 1];
            }
            n++;

            if (i < FieldSqX - 1)
            {
                neighborsArray[n] = _field[i + 1, j];
            }
            n++;

            if (i > 0 && !_field[i - 1, j].IsOpened)
            {
                neighborsArray[n] = _field[i - 1, j];
            }
            n++;


            if (i < FieldSqX - 1 && j < FieldSqY - 1)
            {
                neighborsArray[n] = _field[i + 1, j + 1];
            }
            n++;


            if (i < FieldSqX - 1 && j > 0)
            {
                neighborsArray[n] = _field[i + 1, j - 1];
            }
            n++;

            if (i > 0 && j < FieldSqY - 1)
            {
                neighborsArray[n] = _field[i - 1, j + 1];
            }
            n++;

            if (i > 0 && j > 0)
            {
                neighborsArray[n] = _field[i - 1, j - 1];
            }
            //----------------------------------------------

            return neighborsArray;
        }
    }
}
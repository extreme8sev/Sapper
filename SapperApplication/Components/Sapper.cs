#region Usings

using System;
using System.Drawing;

#endregion

namespace SapperApplication.Components
{
    public class Sapper
    {
        #region Public Members

        public int NumberOfBombLeft;
        public const int FIELD_SQ_X = 18; // Размер поля в ячейках
        public const int FIELD_SQ_Y = 12;
        public const int SQUARE_F = 25; //Размер ячейки

        #endregion

        #region Private Members

        private readonly int _numberOfBomb;

        private readonly Cell[,] _field = new Cell[FIELD_SQ_X, FIELD_SQ_Y];

        private readonly Graphics _gameFieldGraph;

        private readonly Pen _userBlack = new Pen(Color.Black,
                                                  2);

        private readonly Brush _userDarkGreyBrush = Brushes.DarkGray;

        private readonly Font _userFont = new Font("Times New Roman",
                                                   15);

        private readonly Brush _userLightGreyBrush = Brushes.LightGray;

        private bool _isFirstClick;

        private int Difficult;

        #endregion

        #region  .ctor

        public Sapper(Graphics grf):this(grf, 1)
        {
        }

        public Sapper(Graphics grf, int difficult)
        {
            _gameFieldGraph = grf;
            for (var i = 0; i < FIELD_SQ_X; i++)
            {
                for (var j = 0; j < FIELD_SQ_Y; j++)
                {
                    _field[i,
                           j] = new Cell();
                }
            }
            Difficult = difficult;
            _numberOfBomb = 30 + difficult * 10;
        }
        #endregion

        #region  Public Methods

        public void DrawGameFieldLines() //Рисует СЕТКУ ПОЛЯ
        {
            for (var i = 0; i < FIELD_SQ_X + 1; i++)
            {
                _gameFieldGraph.DrawLine(_userBlack,
                                         i * SQUARE_F + 5,
                                         5,
                                         i * SQUARE_F + 5,
                                         SQUARE_F * FIELD_SQ_Y + 5);
            }

            for (var i = 0; i < FIELD_SQ_Y + 1; i++)
            {
                _gameFieldGraph.DrawLine(_userBlack,
                                         5,
                                         i * SQUARE_F + 5,
                                         SQUARE_F * FIELD_SQ_X + 5,
                                         i * SQUARE_F + 5);
            }
        }

        public delegate void EndingGame (int difficult);
        public event EndingGame EndingGame_Lose;
        public event EndingGame EndingGame_Win;

        public void ClickThisPoint(Point point)
        {
            int x = (point.X - 5) / SQUARE_F;
            int y = (point.Y - 5) / SQUARE_F;
            if (x >= 0 && y >= 0 && x < FIELD_SQ_X && y < FIELD_SQ_Y)
            {
                _field[x,y].Open();
                if (_isFirstClick && _field[x, y].Value != 0)
                {
                    RandomizeBomb();
                    ClickThisPoint(point);
                }
                DrawOneCell(x, y);
                if (_field[x, y].Value == 0)
                {
                    ExpandZeroes();
                    DrawAllCells();
                }
                else if (_field[x, y].Value == 13)
                {
                    DrawOneCell(x, y);
                    EndingGame_Lose(Difficult);
                }
                if (IsItTheEndOfTheGame())
                {
                    EndingGame_Win(Difficult);
                }
                _isFirstClick = false;
            }
        }

        public int OpenAllNeighbours(Point thisPoint)
        {
            var x = (thisPoint.X - 5) / SQUARE_F;
            var y = (thisPoint.Y - 5) / SQUARE_F;
            if (x >= 0 && y >= 0 && x < FIELD_SQ_X && y < FIELD_SQ_Y && _field[x, y].IsOpened)
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


        public int ThisPointIsSelected(Point thisPoint)
        {
            int x = (thisPoint.X - 5) / SQUARE_F;
            int y = (thisPoint.Y - 5) / SQUARE_F;
            if (x >= 0
             && y >= 0
             && x < FIELD_SQ_X
             && y < FIELD_SQ_Y
             && !_field[x,y].IsOpened) 
            {
                _field[x, y].Select();
                DrawOneCell(x, y);

                if (!_field[x,y].IsSelected)
                {
                    NumberOfBombLeft++;
                }

                else
                {
                    NumberOfBombLeft--;
                    if (NumberOfBombLeft == 0 && IsItTheEndOfTheGame())
                    {
                        EndingGame_Win(Difficult);
                    }
                }
            }

            return NumberOfBombLeft;
        }

        /// <summary>
        /// Метод расстановки бомб
        /// </summary>
        public void RandomizeBomb()
        {
            ClearGameField();

            //Обнуляем счетчик первого клика
            _isFirstClick = true;

            //Обнуляем количество оставшихся бомб
            NumberOfBombLeft = _numberOfBomb;
            //Расставляем бомбы
            var rnd = new Random();
            for (var i = 0; i < _numberOfBomb;)
            {
                int x = rnd.Next(0,
                                 FIELD_SQ_X);
                int y = rnd.Next(0,
                                 FIELD_SQ_Y);
                if (_field[x,
                           y]
                       .Value
                 == 0)
                {
                    _field[x,
                           y]
                       .Value = 13;
                    i++;
                }
            }

            //Расставляем циферки
            for (var i = 0; i < FIELD_SQ_X; i++)
            {
                for (var j = 0; j < FIELD_SQ_Y; j++)
                {
                    if (_field[i,
                               j]
                           .Value
                     != 13)
                    {
                        var numberOfBomb = 0;
                        Cell[] neighborsArray = GetNeighbors(i,
                                                             j);
                        for (var v = 0; v < 8; v++)
                        {
                            if (neighborsArray[v]?.Value == 13)
                            {
                                numberOfBomb++;
                            }
                        }

                        _field[i,
                               j]
                           .Value = (byte) numberOfBomb;
                    }
                }
            }
        }

        public void DrawAllCells()
        {
            for (var i = 0; i < FIELD_SQ_X; i++)
            {
                for (var j = 0; j < FIELD_SQ_Y; j++)
                {
                    DrawOneCell(i,
                                j);
                }
            }
        }

        #endregion

        #region  Private Methods

        private void ExpandZeroes()
        {
            var counter = 0;
            //Раскрываем нули цепной реакцией
            for (var i = 0; i < FIELD_SQ_X; i++)
            {
                for (var j = 0; j < FIELD_SQ_Y; j++)
                {
                    if (_field[i,
                               j]
                           .Value
                     == 0
                     && _field[i,
                               j]
                           .IsOpened)
                    {
                        Cell[] neighborsArray = GetNeighbors(i,
                                                             j);
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

        private void DrawOneCell(int x,
                                 int y)
        {
            _gameFieldGraph.FillRectangle(_userLightGreyBrush,
                                          7 + x * SQUARE_F,
                                          7 + y * SQUARE_F,
                                          SQUARE_F - 4,
                                          SQUARE_F - 4);

            if (_field[x,
                       y]
               .IsSelected)
            {
                _gameFieldGraph.FillRectangle(Brushes.Orange,
                                              7 + x * SQUARE_F,
                                              7 + y * SQUARE_F,
                                              SQUARE_F - 4,
                                              SQUARE_F - 4);
                _gameFieldGraph.DrawString("!",
                                           _userFont,
                                           Brushes.Black,
                                           7 + x * SQUARE_F,
                                           7 + y * SQUARE_F);
            }
            else if (!_field[x,
                             y]
                        .IsOpened)
            {
                _gameFieldGraph.FillRectangle(_userDarkGreyBrush,
                                              7 + x * SQUARE_F,
                                              7 + y * SQUARE_F,
                                              SQUARE_F - 4,
                                              SQUARE_F - 4);
            }
            else
            {
                switch (_field[x,
                               y]
                   .Value)
                {
                    case 13:
                        _gameFieldGraph.FillRectangle(Brushes.DarkRed,
                                                      7 + x * SQUARE_F,
                                                      7 + y * SQUARE_F,
                                                      SQUARE_F - 4,
                                                      SQUARE_F - 4);
                        break;

                    case 0:
                        break;

                    case 1:
                        _gameFieldGraph.DrawString("1",
                                                   _userFont,
                                                   Brushes.Blue,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;

                    case 2:
                        _gameFieldGraph.DrawString("2",
                                                   _userFont,
                                                   Brushes.Azure,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;

                    case 3:
                        _gameFieldGraph.DrawString("3",
                                                   _userFont,
                                                   Brushes.Green,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;

                    case 4:
                        _gameFieldGraph.DrawString("4",
                                                   _userFont,
                                                   Brushes.GreenYellow,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;

                    case 5:
                        _gameFieldGraph.DrawString("5",
                                                   _userFont,
                                                   Brushes.Yellow,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;

                    case 6:
                        _gameFieldGraph.DrawString("6",
                                                   _userFont,
                                                   Brushes.Orange,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;

                    case 7:
                        _gameFieldGraph.DrawString("7",
                                                   _userFont,
                                                   Brushes.OrangeRed,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;

                    case 8:
                        _gameFieldGraph.DrawString("8",
                                                   _userFont,
                                                   Brushes.Red,
                                                   7 + x * SQUARE_F,
                                                   7 + y * SQUARE_F);
                        break;
                }
            }
        }

        /// <summary>
        /// Метод для снятия бомб и цифр с поля
        /// </summary>
        private void ClearGameField()
        {
            for (var i = 0; i < FIELD_SQ_X; i++)
            {
                for (var j = 0; j < FIELD_SQ_Y; j++)
                {
                    _field[i,
                           j]
                       .SetToZero();
                }
            }

            DrawAllCells();
        }

        private bool IsItTheEndOfTheGame()
        {
            var numberOfClosedCells = 0;
            var numberOfSelectedCells = 0;
            for (var i = 0; i < FIELD_SQ_X; i++)
            {
                for (var j = 0; j < FIELD_SQ_Y; j++)
                {
                    if (!_field[i, j].IsOpened)
                    {
                        numberOfClosedCells++;
                    }
                    if(_field[i, j].IsSelected)
                    {
                        numberOfSelectedCells++;
                    }
                }
            }
            if (numberOfClosedCells == _numberOfBomb && _numberOfBomb == numberOfSelectedCells)
            {
                return true;
            }
            return false;
        }

        private Cell[] GetNeighbors(int i,
                                    int j)
            //Возвращает массив всех соседних клеток для заданной координатами i,j.
            //Если клетка вышла за границу - ее место в массиве занимает null
        {
            var neighborsArray = new Cell[8];

            //----------------------------------------------
            //Find all neighborhoods cells for _field[i,j]'s cell
            var n = 0;

            if (j < FIELD_SQ_Y - 1)
            {
                neighborsArray[n] = _field[i,
                                           j + 1];
            }

            n++;

            if (j > 0)
            {
                neighborsArray[n] = _field[i,
                                           j - 1];
            }

            n++;

            if (i < FIELD_SQ_X - 1)
            {
                neighborsArray[n] = _field[i + 1,
                                           j];
            }

            n++;

            if (i > 0
             && !_field[i - 1,
                        j]
                   .IsOpened)
            {
                neighborsArray[n] = _field[i - 1,
                                           j];
            }

            n++;


            if (i < FIELD_SQ_X - 1 && j < FIELD_SQ_Y - 1)
            {
                neighborsArray[n] = _field[i + 1,
                                           j + 1];
            }

            n++;


            if (i < FIELD_SQ_X - 1 && j > 0)
            {
                neighborsArray[n] = _field[i + 1,
                                           j - 1];
            }

            n++;

            if (i > 0 && j < FIELD_SQ_Y - 1)
            {
                neighborsArray[n] = _field[i - 1,
                                           j + 1];
            }

            n++;

            if (i > 0 && j > 0)
            {
                neighborsArray[n] = _field[i - 1,
                                           j - 1];
            }
            //----------------------------------------------

            return neighborsArray;
        }

        #endregion
    }
}
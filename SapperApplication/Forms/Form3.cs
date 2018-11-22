#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;
using SapperApplication.Components;

#endregion

namespace SapperApplication.Forms
{
    public partial class Form3 : Form
    {
        #region Private Members

        private const int FIELD_LEFT = 15; //верхний правый угол поля
        private const int FIELD_TOP = 35;
        private const string LEFT_TO_DETERMINE_TEXT = "Осталось обнаружить: ";
        private readonly Form1 _mainForm;
        private Sapper _game1;
        private Graphics _gameFieldGraph;

        #endregion

        #region  .ctor

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        #endregion

        #region  Public Methods

        public void SetLabel1Text(string str)
        {
            label1.Text = str;
        }

        #endregion

        #region  Private Methods

        private void Form3_Load(object sender,
                                EventArgs e)
        {
            var game1 = new Sapper(_gameFieldGraph);
            //Задание размеров элементов и инициализация объекта GameFieldGraph;
            pictureBoxGameField.Height = Sapper.FIELD_SQ_Y * Sapper.SQUARE_F + 10;
            Height = pictureBoxGameField.Height + 80;
            // = Height;
            pictureBoxGameField.Width = Sapper.FIELD_SQ_X * Sapper.SQUARE_F + 10;
            Width = pictureBoxGameField.Width + 40;
            pictureBoxGameField.Top = FIELD_TOP;
            pictureBoxGameField.Left = FIELD_LEFT;
            pictureBoxGameField.BackColor = Color.LightGray;
            _gameFieldGraph = Graphics.FromHwnd(pictureBoxGameField.Handle);
            label1.Text = LEFT_TO_DETERMINE_TEXT + game1.NumberOfBombLeft;
        }

        private void pictureBoxGameField_Click(object sender,
                                               EventArgs e)
        {
        }

        private void pictureBoxGameField_MouseDown(object sender,
                                                   MouseEventArgs e)
        {
            if (_game1 != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    var cursorCoordinate = new Point(Cursor.Position.X - pictureBoxGameField.Location.X - Left - 8,
                                                     Cursor.Position.Y - pictureBoxGameField.Location.Y - Top - 30);
                    label1.Text = LEFT_TO_DETERMINE_TEXT + _game1.ThisPointIsSelected(cursorCoordinate);
                }

                if (e.Button == MouseButtons.Left)
                {
                    var cursorCoordination = new Point(Cursor.Position.X - pictureBoxGameField.Location.X - Left - 8,
                                                       Cursor.Position.Y - pictureBoxGameField.Location.Y - Top - 30);
                    _game1.ClickThisPoint(cursorCoordination);
                }
            }
        }

        private void pictureBoxGameField_DoubleClick(object sender,
                                                     EventArgs e)
        {
            var cursorCoordination = new Point(Cursor.Position.X - pictureBoxGameField.Location.X - Left - 8,
                                               Cursor.Position.Y - pictureBoxGameField.Location.Y - Top - 30);
            _game1.OpenAllNeighbours(cursorCoordination);
        }

        private void button1_Click(object sender,
                                   EventArgs e)
        {
            if (_game1 == null)
            {
                _game1 = new Sapper(_gameFieldGraph);
                _mainForm.SubscribeByCurrentSapperGameEvent(_game1);
                _game1.EndingGameLose += CloseThisForm;
                _game1.EndingGameWin += CloseThisForm;
            }

            _game1.RandomizeBomb();
            _game1.DrawGameFieldLines();
            _game1.DrawAllCells();
        }

        private void CloseThisForm(int i)
        {
            Close();
        }

        #endregion
    }
}
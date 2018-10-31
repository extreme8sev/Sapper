#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        private const int FieldLeft = 15; //верхний правый угол поля
        private const int FieldTop = 35;
        private Sapper _game1;
        private Graphics _gameFieldGraph;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var game1 = new Sapper(_gameFieldGraph);
            //Задание размеров элементов и инициализация объекта GameFieldGraph;
            pictureBoxGameField.Height = Sapper.FieldSqY * Sapper.SquareF + 10;
            Height = pictureBoxGameField.Height + 80;
            pictureBoxGameField.Width = Sapper.FieldSqX * Sapper.SquareF + 10;
            Width = pictureBoxGameField.Width + 40;
            pictureBoxGameField.Top = FieldTop;
            pictureBoxGameField.Left = FieldLeft;
            pictureBoxGameField.BackColor = Color.LightGray;
            _gameFieldGraph = Graphics.FromHwnd(pictureBoxGameField.Handle);
            label1.Text = "Осталось обнаружить: " + game1.NumberOfBombLeft;
        }

        public void label1_text(string str)
        {
            label1.Text = str;
        }

        private void pictureBoxGameField_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxGameField_MouseDown(object sender, MouseEventArgs e)
        {
            if (_game1 != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    var cursorCoordinate = new Point(Cursor.Position.X - pictureBoxGameField.Location.X - Left - 8,
                        Cursor.Position.Y - pictureBoxGameField.Location.Y - Top - 30);
                    label1.Text = "Осталось обнаружить: " + _game1.thisPoinIsChoosed(cursorCoordinate);
                }

                if (e.Button == MouseButtons.Left)
                {
                    var cursorCoordination = new Point(Cursor.Position.X - pictureBoxGameField.Location.X - Left - 8,
                        Cursor.Position.Y - pictureBoxGameField.Location.Y - Top - 30);
                    _game1.ClickThisPoint(cursorCoordination);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_game1 == null) _game1 = new Sapper(_gameFieldGraph);
            _game1.RandomizeBomb();
            _game1.DrawGameFieldLines();
            _game1.DrawAllCells();
        }

    }
}
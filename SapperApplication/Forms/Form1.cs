#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;
using SapperApplication.Components;

#endregion

namespace SapperApplication.Forms
{
    public partial class Form1 : Form
    {
        #region Private Members

        private Bryozoa[] _bryozoaList;
        private Graphics _gameFieldGraph;
        private int _startX = -10;
        private int _startY = -10;

        #endregion

        #region Public Members
        public ZooLogic CurrentZooLogic;
        public ZooGIU CurrentZooGUI;
        public SapperGameUIManager CurrentSapperGameUIManager;
        #endregion
        #region  .ctor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region  Private Methods

        private void Form1_Load(object sender,
                                EventArgs e)
        {
            GameField.Height = 650;
            GameField.Width = 1120;
            cursorSelector.Left = 1150;
            cursorSelector.Top = 50;
            cursorType.SelectedItem = cursorType.Items[0];
            _gameFieldGraph = Graphics.FromHwnd(GameField.Handle);
            CurrentZooLogic = new ZooLogic(GameField.Width, GameField.Height);
            CurrentZooGUI = new ZooGIU(_gameFieldGraph, CurrentZooLogic, GameField.Width, GameField.Height);
            CurrentSapperGameUIManager = new SapperGameUIManager(this, CurrentZooLogic);
            CurrentSapperGameUIManager.WriteNumberOfSapperPoint();
        }

        private void button1_Click(object sender,
                                   EventArgs e)
        {
            var userBlack = new Pen(Color.Black,
                                    2);
            _gameFieldGraph.DrawRectangle(userBlack,
                                          _startX,
                                          _startY,
                                          50,
                                          50);
            _startX += 50;
            _startY += 50;
        }

        private void GameField_Click(object sender,
                                     EventArgs e)
        {
            var cursorCoordination = new Point(Cursor.Position.X - GameField.Location.X - Left - 8,
                                               Cursor.Position.Y - GameField.Location.Y - Top - 30);
            button1.Text = Left.ToString();

            if (cursorType.SelectedItem == cursorType.Items[1])
            {
                if (_bryozoaList == null) //Create first object of this class
                {
                    button2.Text = "null";
                    _bryozoaList = new Bryozoa[1];
                    _bryozoaList[0] = new Bryozoa(cursorCoordination);
                }
                else //Create another (not first) object
                {
                    var tempArray = new Bryozoa[_bryozoaList.Length + 1];
                    for (var i = 0; i < _bryozoaList.Length; i++)
                    {
                        tempArray[i] = _bryozoaList[i];
                    }

                    tempArray[tempArray.Length - 1] = new Bryozoa(cursorCoordination);
                    _bryozoaList = tempArray;
                }

                _bryozoaList[_bryozoaList.Length - 1].DrawMyself(_gameFieldGraph);
                button2.Text = _bryozoaList.Length.ToString();
            }
        }

        private void button2_Click(object sender,
                                   EventArgs e)
        {
            //_gameFieldGraph.FillEllipse(Brushes.DarkOliveGreen, 150, 150, 50, 50);
            CurrentZooLogic.Make10Plants();
            CurrentZooGUI.DrawAllPlants();

            /* Осталось со времен Briazoa
            if (_bryozoaList == null)
            {
                return;
            }

            foreach (var i in _bryozoaList)
            {
                i.DrawMyself(_gameFieldGraph);
                i.Activate(_gameFieldGraph);
            }
            */
        }

        private void button3_Click(object sender,
                                   EventArgs e)
        {
            var newDiffForm3 = new Form3(this);
            newDiffForm3.Show();
            CurrentSapperGameUIManager.WriteNumberOfSapperPoint();
        }

        private void GameField_DoubleClick(object sender, EventArgs e)
        {

        }

        #endregion

        #region Public Methods
        public void SetSapperScoreLabelText(String setString)
        {
            SapperScoreLabel.Text = setString;
        }

        public void SubscribeByCurrentSapperGameEvent(Sapper currentSapperGame)
        {
            CurrentSapperGameUIManager.SubscribeByCurrentSapperGameEvent(currentSapperGame);
        }

        #endregion
    }
}
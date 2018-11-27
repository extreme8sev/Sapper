#region Usings

using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SapperApplication.Components;
using SapperApplication.Components.DrawableObjects.Bryozoa;
using SapperApplication.Components.ObjectDrawers;
using SapperApplication.Interfaces;

#endregion

namespace SapperApplication.Forms
{
    public partial class MainForm : Form
    {
        #region Private Members

        private const string TITLE_TEXT = "The Game Application";

        private const string NULL_TEXT = "null";

        private Bryozoa[] _bryozoaList;
        private Graphics _gameFieldGraph;
        private int _startX = -10;
        private int _startY = -10;

        #endregion

        #region  .ctor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region  Properties

        public ZooLogic CurrentZooLogic { get; set; }
        public ZooGIU CurrentZooGUI { get; set; }
        public SapperGameUIManager CurrentSapperGameUIManager { get; set; }

        #endregion

        #region  Public Methods

        public void SetSapperScoreLabelText(string setString)
        {
            SapperScoreLabel.Text = setString;
        }

        public void SubscribeByCurrentSapperGameEvent(Sapper currentSapperGame)
        {
            CurrentSapperGameUIManager.SubscribeByCurrentSapperGameEvent(currentSapperGame);
        }

        #endregion

        #region  Private Methods

        private void MainForm_Load(object sender,
                                   EventArgs e)
        {
            cursorType.SelectedItem = cursorType.Items[0];
            _gameFieldGraph = Graphics.FromHwnd(gameFieldPictureBox.Handle);
            CurrentZooLogic = new ZooLogic(gameFieldPictureBox.Width,
                                           gameFieldPictureBox.Height);
            CurrentZooGUI = new ZooGIU(_gameFieldGraph,
                                       CurrentZooLogic,
                                       gameFieldPictureBox.Width,
                                       gameFieldPictureBox.Height);
            CurrentSapperGameUIManager = new SapperGameUIManager(this,
                                                                 CurrentZooLogic);
            CurrentSapperGameUIManager.WriteNumberOfSapperPoint();

            SetWindowTitle();
        }

        private void SetWindowTitle()
        {
            var appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Text = $"{TITLE_TEXT} ({appVersion})";
        }

        private void testButton_Click(object sender,
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

        private void gameFieldPictureBox_Click(object sender,
                                               EventArgs e)
        {
            var cursorCoordination = new Point(Cursor.Position.X - gameFieldPictureBox.Location.X - Left - 8,
                                               Cursor.Position.Y - gameFieldPictureBox.Location.Y - Top - 30);
            testButton.Text = Left.ToString();

            if (cursorType.SelectedItem == cursorType.Items[1])
            {
                if (_bryozoaList == null) //Create first object of this class
                {
                    addPlantsButton.Text = NULL_TEXT;
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

                var bryozoa = _bryozoaList[_bryozoaList.Length - 1];

                IDrawer drawer = DrawerFactory.Instance.GetDrawer(bryozoa);
                drawer.Draw(_gameFieldGraph,
                            bryozoa,
                            0);

                addPlantsButton.Text = _bryozoaList.Length.ToString();
            }
        }

        private void startTheGameButton_Click(object sender,
                                              EventArgs e)
        {
            var newDiffForm3 = new SapperForm(this);
            newDiffForm3.Show();
            CurrentSapperGameUIManager.WriteNumberOfSapperPoint();
        }

        private void gameFieldPictureBox_DoubleClick(object sender,
                                                     EventArgs e)
        {
        }

        private void addPlantsButton_Click(object sender,
                                           EventArgs e)
        {
            CurrentZooLogic.MakePlantAndBush(2);
            CurrentZooGUI.DrawAllPlants();
        }

        #endregion
    }
}
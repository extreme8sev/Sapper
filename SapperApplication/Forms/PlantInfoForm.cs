using SapperApplication.Components;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Components.ObjectDrawers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SapperApplication.Forms
{
    public partial class PlantInfoForm : Form
    {
        private int _currentPlantNumber;
        private const int ZOOM = 3;
        private LinkedListNode<PlantBase> _currentPlant;
        private readonly Graphics _gameFieldGraph;
        private readonly ZooLogic _currentZooLogic;
        private readonly DrawableObjectDrawer _drawer;
        private readonly int _graphixX;
        private readonly int _graphixY;


        public PlantInfoForm(ZooLogic currentZooLogic)
        {
            InitializeComponent();
            _currentZooLogic = currentZooLogic;
            _gameFieldGraph = Graphics.FromHwnd(plantPictureBox.Handle);
            _graphixX = plantPictureBox.Height/2;
            _graphixY = plantPictureBox.Width/2;
            _drawer = new DrawableObjectDrawer();
        }

        private void PlantInfoForm_Load(object sender, EventArgs e)
        {
            goToFirstPlant();
        }

        private void goToFirstPlant()
        {
            _currentPlantNumber = 0;
            _currentPlant = _currentZooLogic.Plants.First;
            setInfo();
        }

        private void setInfo()
        {
            plantGroupBox.Text = "Plant " + (_currentPlantNumber + 1).ToString() +
                     "/" + _currentZooLogic.Plants.Count.ToString();
            PlantTypeLabel.Text = _currentPlant.Value.GetType().ToString();
            CoordinateLabel.Text = "Coordinate: x:" + _currentPlant.Value.Location.X +
                                    "; y:" + _currentPlant.Value.Location.Y;
            HealthLabel.Text = "Health: " + _currentPlant.Value.Health; 
            _drawer.DrawOnCoorinate(_gameFieldGraph, _currentPlant.Value, ZOOM, _graphixX, _graphixY);
        }

        private void goToTheFirstPlant_Click(object sender, EventArgs e)
        {
            goToFirstPlant();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (_currentPlant != _currentZooLogic.Plants.First)
            {
                _currentPlant = _currentPlant.Previous;
                _currentPlantNumber--;
                setInfo();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_currentPlantNumber != _currentZooLogic.Plants.Count && 
                _currentPlant.Next != null)
            {
                _currentPlant = _currentPlant.Next;
                _currentPlantNumber++;
                setInfo();
            }
        }
    }
}

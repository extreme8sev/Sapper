#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SapperApplication.Components;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Components.ObjectDrawers;

#endregion

namespace SapperApplication.Forms
{
    public partial class PlantInfoForm : Form
    {
        private const int ZOOM = 3;
        private readonly ZooLogic _currentZooLogic;
        private readonly DrawableObjectDrawer _drawer;
        private readonly Graphics _gameFieldGraph;
        private readonly int _graphixX;
        private readonly int _graphixY;
        private LinkedListNode<PlantBase> _currentPlant;


        public PlantInfoForm(ZooLogic currentZooLogic)
        {
            InitializeComponent();
            _currentZooLogic = currentZooLogic;
            _gameFieldGraph = Graphics.FromHwnd(plantPictureBox.Handle);
            _graphixY = plantPictureBox.Height - 5;
            _graphixX = plantPictureBox.Width / 2;
            _drawer = new DrawableObjectDrawer();
        }

        private void PlantInfoForm_Load(object sender,
                                        EventArgs e)
        {
            goToFirstPlant();
        }

        private void goToFirstPlant()
        {
            _currentPlant = _currentZooLogic.Plants.First;
            setInfo();
        }

        private void setInfo()
        {
            plantGroupBox.Text = "Plant " + (GetPlantNumber() + 1) + "/" + _currentZooLogic.Plants.Count;
            PlantTypeLabel.Text = _currentPlant.Value.GetType().ToString();
            CoordinateLabel.Text = "Coordinate: x:" + _currentPlant.Value.Location.X + "; y:" + _currentPlant.Value.Location.Y;
            HealthLabel.Text = "Health: " + _currentPlant.Value.Health;
            _gameFieldGraph.Clear(plantPictureBox.BackColor);
            _drawer.DrawOnCoorinate(_gameFieldGraph, _currentPlant.Value, ZOOM, _graphixX, _graphixY);
        }

        private void goToTheFirstPlant_Click(object sender,
                                             EventArgs e)
        {
            goToFirstPlant();
        }

        private void buttonPrev_Click(object sender,
                                      EventArgs e)
        {
            if (_currentPlant.Previous != null)
            {
                _currentPlant = _currentPlant.Previous;
                setInfo();
            }
        }

        private void buttonNext_Click(object sender,
                                      EventArgs e)
        {
            if (_currentPlant.Next != null)
            {
                _currentPlant = _currentPlant.Next;
                setInfo();
            }
        }

        private int GetPlantNumber()
        {
            var plantNumber = 0;
            for (LinkedListNode<PlantBase> plant = _currentZooLogic.Plants.First;
                 plant != _currentPlant;
                 plant = plant.Next)
            {
                plantNumber++;
            }

            return plantNumber;
        }

        private void PlantInfoForm_Leave(object sender,
                                         EventArgs e)
        {
            Close();
        }
    }
}
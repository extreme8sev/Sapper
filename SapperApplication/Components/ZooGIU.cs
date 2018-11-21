using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.Components
{
    public class ZooGIU
    {
        private Graphics _grField;
        private ZooLogic _currentZooLogic;
        private int _gameFieldHeight { get; set; }
        private int _gameFieldWidth { get; set; }
        private int _zoom = 3;

        public ZooGIU(Graphics grField, ZooLogic currentZooLogic, int gameFieldWidth, int gameFieldHeight)
        {
            _grField = grField;
            _currentZooLogic = currentZooLogic;
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
        }

        private void ClearScreen()
        {
            _grField.FillRectangle(Brushes.Goldenrod, 0, 0, _gameFieldWidth, _gameFieldHeight);
        }

        public void DrawAllPlants()
        {
            ClearScreen();
            /*
            for (int i = 0;
                i < _currentZooLogic.PlantArray.Length;
                i++)
            {
                DrawPlant(_currentZooLogic.PlantArray[i]);
            }
            */
            var CurrentPlantItem = _currentZooLogic.CurrentPlantList.FirstPlant;
            for (;;)
            {
                if (CurrentPlantItem == null)
                {
                    break;
                }
                DrawPlant(CurrentPlantItem.Plant);
                CurrentPlantItem = CurrentPlantItem.Next;
            }

        }


        private void DrawPlant(PlantBase plant)
        {
            switch (plant.GetType().ToString())
            {
                case "SapperApplication.Components.PlantBush":
                    DrawPlantBush(plant as PlantBush);
                    break;
                case "SapperApplication.Components.PlantTree":
                    DrawPlantTree(plant as PlantTree);
                    break;
            }
        }

        private void DrawPlantBush(PlantBush plant)
        {
            var zoom = _zoom * plant.Health / PlantBush.MaxHealth;
            var _leafBrush = Brushes.DarkOliveGreen;
            var _LeafConturPen = new Pen(Color.Black, 2);
            int _radiusSmall = 5 * _zoom;
            int _radiusBig = 7 * _zoom;
            int _lengh = 10 * _zoom;

            //Левая часть
            _grField.FillEllipse(_leafBrush,
                                plant.MyCoordinate.X - (int)(_radiusSmall*2.5),
                                plant.MyCoordinate.Y - _radiusSmall * 2,
                                2 * _radiusSmall,
                                2 * _radiusSmall);
            _grField.DrawEllipse(_LeafConturPen,
                                plant.MyCoordinate.X - (int)(_radiusSmall * 2.5),
                                plant.MyCoordinate.Y - _radiusSmall * 2,
                                2 * _radiusSmall,
                                2 * _radiusSmall);
            //Правая часть
            _grField.FillEllipse(_leafBrush,
                                 plant.MyCoordinate.X + (int)(_radiusSmall * 0.5),
                                 plant.MyCoordinate.Y - _radiusSmall * 2,
                                 2 * _radiusSmall,
                                 2 * _radiusSmall);
            _grField.DrawEllipse(_LeafConturPen,
                                plant.MyCoordinate.X + (int)(_radiusSmall * 0.5),
                                plant.MyCoordinate.Y - _radiusSmall * 2,
                                2 * _radiusSmall,
                                2 * _radiusSmall);
            //Центральный круг
            _grField.FillEllipse(_leafBrush,
                                plant.MyCoordinate.X - _radiusBig - _zoom,
                                plant.MyCoordinate.Y - (int)(_radiusBig * 2.2),
                                2 * _radiusBig,
                                2 * _radiusBig);
            _grField.DrawEllipse(_LeafConturPen,
                                plant.MyCoordinate.X - _radiusBig - _zoom,
                                plant.MyCoordinate.Y - (int)(_radiusBig * 2.2),
                                2 * _radiusBig,
                                2 * _radiusBig);
            //Центральный прямоугольник
            _grField.FillRectangle(_leafBrush,
                                plant.MyCoordinate.X - (int)(_radiusSmall * 1.8),
                                plant.MyCoordinate.Y - _radiusSmall,
                                _radiusSmall * 3,
                                _radiusSmall);
            _grField.DrawLine(_LeafConturPen,
                                plant.MyCoordinate.X - (int)(_radiusSmall * 1.6),
                                plant.MyCoordinate.Y,
                                plant.MyCoordinate.X + (int)(_radiusSmall * 1.6),
                                plant.MyCoordinate.Y);

        }

        private void DrawPlantTree(PlantTree plant)
        {
            var zoom = _zoom * plant.Health / PlantTree.MaxHealth;
            var _leafBrush = Brushes.YellowGreen;
            var _LeafConturPen = new Pen(Color.Black, 2);
            var _woodPen = new Pen(Color.Maroon, 4);
            int _radiusSmall = 4 * _zoom;
            int _radiusMedium = 6 * _zoom;
            int _radiusBig = 10 * _zoom;
            int _lengh = 30 * _zoom;

            //Ствол
            _grField.DrawLine(_woodPen,
                                plant.MyCoordinate.X,
                                plant.MyCoordinate.Y,
                                plant.MyCoordinate.X,
                                plant.MyCoordinate.Y - _lengh);

            _grField.DrawLine(_woodPen,
                            plant.MyCoordinate.X,
                            plant.MyCoordinate.Y - (int)(_lengh / 3),
                            plant.MyCoordinate.X + (int)(_lengh / 3),
                            plant.MyCoordinate.Y - (int)(_lengh *2 / 3));

            _grField.DrawLine(_woodPen,
                            plant.MyCoordinate.X,
                            plant.MyCoordinate.Y - (int)(_lengh *2 / 3),
                            plant.MyCoordinate.X + (int)(_lengh / 3),
                            plant.MyCoordinate.Y - _lengh);

            _grField.DrawLine(_woodPen,
                            plant.MyCoordinate.X,
                            plant.MyCoordinate.Y - (int)(_lengh * 2 / 3),
                            plant.MyCoordinate.X - (int)(_lengh / 3),
                            plant.MyCoordinate.Y - _lengh);
            //Листва
            //Большой
            _grField.FillEllipse(_leafBrush,
                                plant.MyCoordinate.X - (int)(_radiusBig *2.5),
                                plant.MyCoordinate.Y - _lengh - _radiusBig*2,
                                5 * _radiusBig,
                                2 * _radiusBig);
            _grField.DrawEllipse(_LeafConturPen,
                                plant.MyCoordinate.X - (int)(_radiusBig * 2.5),
                                plant.MyCoordinate.Y - _lengh - _radiusBig * 2,
                                5 * _radiusBig,
                                2 * _radiusBig);
            //Правый
            
            _grField.FillEllipse(_leafBrush,
                                plant.MyCoordinate.X + (int)(_lengh / 3) - (int)(_radiusSmall * 2),
                                plant.MyCoordinate.Y - (int)(_lengh * 2 / 3) - _radiusSmall,
                                4 * _radiusSmall,
                                2 * _radiusSmall);
            _grField.DrawEllipse(_LeafConturPen,
                                plant.MyCoordinate.X + (int)(_lengh / 3) - (int)(_radiusSmall * 2),
                                plant.MyCoordinate.Y - (int)(_lengh * 2 / 3) - _radiusSmall,
                                4 * _radiusSmall,
                                2 * _radiusSmall);
            //Правый 2
            _grField.FillEllipse(_leafBrush,
                                plant.MyCoordinate.X + (int)(_lengh / 3) - (int)(_radiusMedium * 2),
                                plant.MyCoordinate.Y - _lengh - _radiusMedium,
                                4 * _radiusMedium,
                                2 * _radiusMedium);
            _grField.DrawEllipse(_LeafConturPen,
                                plant.MyCoordinate.X + (int)(_lengh / 3) - (int)(_radiusMedium * 2),
                                plant.MyCoordinate.Y - _lengh - _radiusMedium,
                                4 * _radiusMedium,
                                2 * _radiusMedium);
            //Левый
            _grField.FillEllipse(_leafBrush,
                                plant.MyCoordinate.X - (int)(_lengh / 3) - (int)(_radiusSmall * 2),
                                plant.MyCoordinate.Y - _lengh - _radiusSmall,
                                4 * _radiusSmall,
                                2 * _radiusSmall);
            _grField.DrawEllipse(_LeafConturPen,
                                plant.MyCoordinate.X - (int)(_lengh / 3) - (int)(_radiusSmall * 2),
                                plant.MyCoordinate.Y - _lengh - _radiusSmall,
                                4 * _radiusSmall,
                                2 * _radiusSmall);
                                
        }
    }
}

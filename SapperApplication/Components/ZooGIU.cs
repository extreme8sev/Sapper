#region Usings

using System.Drawing;

#endregion

namespace SapperApplication.Components
{
    public class ZooGIU
    {
        #region Private Members

        private const int ZOOM = 3;
        private readonly ZooLogic _currentZooLogic;
        private readonly int _gameFieldHeight;
        private readonly int _gameFieldWidth;
        private readonly Graphics _grField;

        #endregion

        #region  .ctor

        public ZooGIU(Graphics grField,
                      ZooLogic currentZooLogic,
                      int gameFieldWidth,
                      int gameFieldHeight)
        {
            _grField = grField;
            _currentZooLogic = currentZooLogic;
            _gameFieldHeight = gameFieldHeight;
            _gameFieldWidth = gameFieldWidth;
        }

        #endregion

        #region  Public Methods

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
            PlantListItem currentPlantItem = _currentZooLogic.CurrentPlantList.FirstPlant;
            while (true)
            {
                if (currentPlantItem == null)
                {
                    break;
                }

                DrawPlant(currentPlantItem.Plant);
                currentPlantItem = currentPlantItem.Next;
            }
        }

        #endregion

        #region  Private Methods

        private void ClearScreen()
        {
            _grField.FillRectangle(Brushes.Goldenrod,
                                   0,
                                   0,
                                   _gameFieldWidth,
                                   _gameFieldHeight);
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
            Brush leafBrush = Brushes.DarkOliveGreen;
            var leafConturPen = new Pen(Color.Black,
                                        2);
            const int radiusSmall = 5 * ZOOM;
            const int radiusBig = 7 * ZOOM;

            //Левая часть
            _grField.FillEllipse(leafBrush,
                                 plant.MyCoordinate.X - (int) (radiusSmall * 2.5),
                                 plant.MyCoordinate.Y - radiusSmall * 2,
                                 2 * radiusSmall,
                                 2 * radiusSmall);
            _grField.DrawEllipse(leafConturPen,
                                 plant.MyCoordinate.X - (int) (radiusSmall * 2.5),
                                 plant.MyCoordinate.Y - radiusSmall * 2,
                                 2 * radiusSmall,
                                 2 * radiusSmall);
            //Правая часть
            _grField.FillEllipse(leafBrush,
                                 plant.MyCoordinate.X + (int) (radiusSmall * 0.5),
                                 plant.MyCoordinate.Y - radiusSmall * 2,
                                 2 * radiusSmall,
                                 2 * radiusSmall);
            _grField.DrawEllipse(leafConturPen,
                                 plant.MyCoordinate.X + (int) (radiusSmall * 0.5),
                                 plant.MyCoordinate.Y - radiusSmall * 2,
                                 2 * radiusSmall,
                                 2 * radiusSmall);
            //Центральный круг
            _grField.FillEllipse(leafBrush,
                                 plant.MyCoordinate.X - radiusBig - ZOOM,
                                 plant.MyCoordinate.Y - (int) (radiusBig * 2.2),
                                 2 * radiusBig,
                                 2 * radiusBig);
            _grField.DrawEllipse(leafConturPen,
                                 plant.MyCoordinate.X - radiusBig - ZOOM,
                                 plant.MyCoordinate.Y - (int) (radiusBig * 2.2),
                                 2 * radiusBig,
                                 2 * radiusBig);
            //Центральный прямоугольник
            _grField.FillRectangle(leafBrush,
                                   plant.MyCoordinate.X - (int) (radiusSmall * 1.8),
                                   plant.MyCoordinate.Y - radiusSmall,
                                   radiusSmall * 3,
                                   radiusSmall);
            _grField.DrawLine(leafConturPen,
                              plant.MyCoordinate.X - (int) (radiusSmall * 1.6),
                              plant.MyCoordinate.Y,
                              plant.MyCoordinate.X + (int) (radiusSmall * 1.6),
                              plant.MyCoordinate.Y);
        }

        private void DrawPlantTree(PlantTree plant)
        {
            Brush leafBrush = Brushes.YellowGreen;
            var leafConturPen = new Pen(Color.Black,
                                        2);
            var woodPen = new Pen(Color.Maroon,
                                  4);
            const int radiusSmall = 4 * ZOOM;
            const int radiusMedium = 6 * ZOOM;
            const int radiusBig = 10 * ZOOM;
            const int lengh = 30 * ZOOM;

            //Ствол
            _grField.DrawLine(woodPen,
                              plant.MyCoordinate.X,
                              plant.MyCoordinate.Y,
                              plant.MyCoordinate.X,
                              plant.MyCoordinate.Y - lengh);

            _grField.DrawLine(woodPen,
                              plant.MyCoordinate.X,
                              plant.MyCoordinate.Y - lengh / 3,
                              plant.MyCoordinate.X + lengh / 3,
                              plant.MyCoordinate.Y - lengh * 2 / 3);

            _grField.DrawLine(woodPen,
                              plant.MyCoordinate.X,
                              plant.MyCoordinate.Y - lengh * 2 / 3,
                              plant.MyCoordinate.X + lengh / 3,
                              plant.MyCoordinate.Y - lengh);

            _grField.DrawLine(woodPen,
                              plant.MyCoordinate.X,
                              plant.MyCoordinate.Y - lengh * 2 / 3,
                              plant.MyCoordinate.X - lengh / 3,
                              plant.MyCoordinate.Y - lengh);
            //Листва
            //Большой
            _grField.FillEllipse(leafBrush,
                                 plant.MyCoordinate.X - (int) (radiusBig * 2.5),
                                 plant.MyCoordinate.Y - lengh - radiusBig * 2,
                                 5 * radiusBig,
                                 2 * radiusBig);
            _grField.DrawEllipse(leafConturPen,
                                 plant.MyCoordinate.X - (int) (radiusBig * 2.5),
                                 plant.MyCoordinate.Y - lengh - radiusBig * 2,
                                 5 * radiusBig,
                                 2 * radiusBig);
            //Правый
            _grField.FillEllipse(leafBrush,
                                 plant.MyCoordinate.X + lengh / 3 - radiusSmall * 2,
                                 plant.MyCoordinate.Y - lengh * 2 / 3 - radiusSmall,
                                 4 * radiusSmall,
                                 2 * radiusSmall);
            _grField.DrawEllipse(leafConturPen,
                                 plant.MyCoordinate.X + lengh / 3 - radiusSmall * 2,
                                 plant.MyCoordinate.Y - lengh * 2 / 3 - radiusSmall,
                                 4 * radiusSmall,
                                 2 * radiusSmall);
            //Правый 2
            _grField.FillEllipse(leafBrush,
                                 plant.MyCoordinate.X + lengh / 3 - radiusMedium * 2,
                                 plant.MyCoordinate.Y - lengh - radiusMedium,
                                 4 * radiusMedium,
                                 2 * radiusMedium);
            _grField.DrawEllipse(leafConturPen,
                                 plant.MyCoordinate.X + lengh / 3 - radiusMedium * 2,
                                 plant.MyCoordinate.Y - lengh - radiusMedium,
                                 4 * radiusMedium,
                                 2 * radiusMedium);
            //Левый
            _grField.FillEllipse(leafBrush,
                                 plant.MyCoordinate.X - lengh / 3 - radiusSmall * 2,
                                 plant.MyCoordinate.Y - lengh - radiusSmall,
                                 4 * radiusSmall,
                                 2 * radiusSmall);
            _grField.DrawEllipse(leafConturPen,
                                 plant.MyCoordinate.X - lengh / 3 - radiusSmall * 2,
                                 plant.MyCoordinate.Y - lengh - radiusSmall,
                                 4 * radiusSmall,
                                 2 * radiusSmall);
        }

        #endregion
    }
}
#region Usings

using System.Drawing;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Interfaces;

#endregion

namespace SapperApplication.Components.ObjectDrawers
{
    public class PlantTreeDrawer : IDrawer
    {
        #region Interface Implementation

        public void Draw(Graphics drawField,
                         DrawableObject objectToDraw,
                         int zoom)
        {
            Brush leafBrush = Brushes.YellowGreen;
            var leafConturPen = new Pen(Color.Black,
                                        2);
            var woodPen = new Pen(Color.Maroon,
                                  4);
            var radiusSmall = 4 * zoom;
            var radiusMedium = 6 * zoom;
            var radiusBig = 10 * zoom;
            var lengh = 30 * zoom;

            //Ствол
            drawField.DrawLine(woodPen,
                               objectToDraw.Location.X,
                               objectToDraw.Location.Y,
                               objectToDraw.Location.X,
                               objectToDraw.Location.Y - lengh);

            drawField.DrawLine(woodPen,
                               objectToDraw.Location.X,
                               objectToDraw.Location.Y - lengh / 3,
                               objectToDraw.Location.X + lengh / 3,
                               objectToDraw.Location.Y - lengh * 2 / 3);

            drawField.DrawLine(woodPen,
                               objectToDraw.Location.X,
                               objectToDraw.Location.Y - lengh * 2 / 3,
                               objectToDraw.Location.X + lengh / 3,
                               objectToDraw.Location.Y - lengh);

            drawField.DrawLine(woodPen,
                               objectToDraw.Location.X,
                               objectToDraw.Location.Y - lengh * 2 / 3,
                               objectToDraw.Location.X - lengh / 3,
                               objectToDraw.Location.Y - lengh);
            //Листва
            //Большой
            drawField.FillEllipse(leafBrush,
                                  objectToDraw.Location.X - (int) (radiusBig * 2.5),
                                  objectToDraw.Location.Y - lengh - radiusBig * 2,
                                  5 * radiusBig,
                                  2 * radiusBig);
            drawField.DrawEllipse(leafConturPen,
                                  objectToDraw.Location.X - (int) (radiusBig * 2.5),
                                  objectToDraw.Location.Y - lengh - radiusBig * 2,
                                  5 * radiusBig,
                                  2 * radiusBig);
            //Правый
            drawField.FillEllipse(leafBrush,
                                  objectToDraw.Location.X + lengh / 3 - radiusSmall * 2,
                                  objectToDraw.Location.Y - lengh * 2 / 3 - radiusSmall,
                                  4 * radiusSmall,
                                  2 * radiusSmall);
            drawField.DrawEllipse(leafConturPen,
                                  objectToDraw.Location.X + lengh / 3 - radiusSmall * 2,
                                  objectToDraw.Location.Y - lengh * 2 / 3 - radiusSmall,
                                  4 * radiusSmall,
                                  2 * radiusSmall);
            //Правый 2
            drawField.FillEllipse(leafBrush,
                                  objectToDraw.Location.X + lengh / 3 - radiusMedium * 2,
                                  objectToDraw.Location.Y - lengh - radiusMedium,
                                  4 * radiusMedium,
                                  2 * radiusMedium);
            drawField.DrawEllipse(leafConturPen,
                                  objectToDraw.Location.X + lengh / 3 - radiusMedium * 2,
                                  objectToDraw.Location.Y - lengh - radiusMedium,
                                  4 * radiusMedium,
                                  2 * radiusMedium);
            //Левый
            drawField.FillEllipse(leafBrush,
                                  objectToDraw.Location.X - lengh / 3 - radiusSmall * 2,
                                  objectToDraw.Location.Y - lengh - radiusSmall,
                                  4 * radiusSmall,
                                  2 * radiusSmall);
            drawField.DrawEllipse(leafConturPen,
                                  objectToDraw.Location.X - lengh / 3 - radiusSmall * 2,
                                  objectToDraw.Location.Y - lengh - radiusSmall,
                                  4 * radiusSmall,
                                  2 * radiusSmall);
        }

        #endregion
    }
}
#region Usings

using System.Drawing;
using SapperApplication.Components.DrawableObjects;
using SapperApplication.Interfaces;

#endregion

namespace SapperApplication.Components.ObjectDrawers
{
    public class PlantBushDrawer : IDrawer
    {
        #region Interface Implementation

        public void Draw(Graphics drawField,
                         DrawableObject objectToDraw,
                         int zoom)
        {
            #region Manual draw
            /* Вариант "ручной" прорисовкой
            Brush leafBrush = Brushes.DarkOliveGreen;
            var leafConturPen = new Pen(Color.Black,
                                        2);
            var radiusSmall = 5 * zoom;
            var radiusBig = 7 * zoom;

            //Левая часть
            drawField.FillEllipse(leafBrush,
                                  objectToDraw.Location.X - (int) (radiusSmall * 2.5),
                                  objectToDraw.Location.Y - radiusSmall * 2,
                                  2 * radiusSmall,
                                  2 * radiusSmall);
            drawField.DrawEllipse(leafConturPen,
                                  objectToDraw.Location.X - (int) (radiusSmall * 2.5),
                                  objectToDraw.Location.Y - radiusSmall * 2,
                                  2 * radiusSmall,
                                  2 * radiusSmall);
            //Правая часть
            drawField.FillEllipse(leafBrush,
                                  objectToDraw.Location.X + (int) (radiusSmall * 0.5),
                                  objectToDraw.Location.Y - radiusSmall * 2,
                                  2 * radiusSmall,
                                  2 * radiusSmall);
            drawField.DrawEllipse(leafConturPen,
                                  objectToDraw.Location.X + (int) (radiusSmall * 0.5),
                                  objectToDraw.Location.Y - radiusSmall * 2,
                                  2 * radiusSmall,
                                  2 * radiusSmall);
            //Центральный круг
            drawField.FillEllipse(leafBrush,
                                  objectToDraw.Location.X - radiusBig - zoom,
                                  objectToDraw.Location.Y - (int) (radiusBig * 2.2),
                                  2 * radiusBig,
                                  2 * radiusBig);
            drawField.DrawEllipse(leafConturPen,
                                  objectToDraw.Location.X - radiusBig - zoom,
                                  objectToDraw.Location.Y - (int) (radiusBig * 2.2),
                                  2 * radiusBig,
                                  2 * radiusBig);
            //Центральный прямоугольник
            drawField.FillRectangle(leafBrush,
                                    objectToDraw.Location.X - (int) (radiusSmall * 1.8),
                                    objectToDraw.Location.Y - radiusSmall,
                                    radiusSmall * 3,
                                    radiusSmall);
            drawField.DrawLine(leafConturPen,
                               objectToDraw.Location.X - (int) (radiusSmall * 1.6),
                               objectToDraw.Location.Y,
                               objectToDraw.Location.X + (int) (radiusSmall * 1.6),
                               objectToDraw.Location.Y);
                               */
            #endregion

            #region Imagine draw
            Image plantImage = Image.FromFile("Bush1.gif");
            Rectangle plantRectangle = new Rectangle(objectToDraw.Location.X, objectToDraw.Location.Y, 90, 60);
            drawField.DrawImage(plantImage, plantRectangle);
            #endregion

        }

        #endregion

    }
}
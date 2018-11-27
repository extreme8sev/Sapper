using SapperApplication.Components.DrawableObjects;
using SapperApplication.Components.DrawableObjects.Plants;
using SapperApplication.Interfaces;
using SapperApplication.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.Components.ObjectDrawers
{
    public class DrawableObjectDrawer : IDrawer
    {

        public void Draw(Graphics drawField,
                 DrawableObject objectToDraw,
                 int zoom)
        {

            #region Imagine draw
            float innerZoom;
            Image objectImage;

            SetImage(objectToDraw, out innerZoom, out objectImage);

            var imageHeight = (int)(objectImage.Height * innerZoom * (float)zoom);
            var halfImageWidth = (int)(objectImage.Width * innerZoom * (float)zoom / 2);

            Rectangle plantRectangle = new Rectangle(objectToDraw.Location.X - halfImageWidth,
                                                    objectToDraw.Location.Y - imageHeight,
                                                    halfImageWidth * 2,
                                                    imageHeight);
            drawField.DrawImage(objectImage, plantRectangle);
            //DrawCoordinate(drawField, objectToDraw);
            #endregion

        }

        /// <summary>
        /// Рисует точку, соответствующую собственным координатам объекта
        /// </summary>
        /// <param name="drawField"></param>
        /// <param name="objectToDraw"></param>
        /// <param name="zoom"></param>
        public void DrawCoordinate(Graphics drawField,
         DrawableObject objectToDraw)
        {
             Brush coordinateBrush = Brushes.Red;
                        drawField.FillEllipse(coordinateBrush,   
                       objectToDraw.Location.X,
                       objectToDraw.Location.Y,
                       5,
                       5);
        }

        private void SetImage (DrawableObject objectToDetect,
                                out float innerZoom,
                                out Image imageToSet)
        {
            switch (objectToDetect)
            {
                case PlantBush _:
                    {
                        innerZoom = 0.12F;
                        imageToSet = Resources.BushImage;
                        break;
                    }
                case PlantTree _:
                    {
                        innerZoom = 0.25F;
                        imageToSet = Resources.TreeImage;
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException("This type is not supported yet!");
                    }
            }
        }
    }
}


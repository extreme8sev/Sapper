using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapperApplication.Components
{
    public class ZooLogic
    {

        public int SapperPoint { get; set; }
        public PlantList CurrentPlantList;

        private int GameFieldHeight { get; set; }
        private int GameFieldWidth { get; set; }


        public ZooLogic(int gameFieldWidth, int gameFieldHeight)
        {
            SapperPoint = 1000;
            GameFieldHeight = gameFieldHeight;
            GameFieldWidth = gameFieldWidth;
            CurrentPlantList = new PlantList();
        }

        public void Make10Plants() //Временно
        {
            Point PlantPoint = new Point();
            Random rnd = new Random();
            PlantBase plant;

                PlantPoint.X = rnd.Next(20, GameFieldWidth-20);
                PlantPoint.Y = rnd.Next(20, GameFieldHeight-2);
                plant = new PlantBush(true, PlantPoint);
                CurrentPlantList.AddNewPlant(plant);
                PlantPoint.X = rnd.Next(20, GameFieldWidth - 20);
                PlantPoint.Y = rnd.Next(20, GameFieldHeight - 2);
                plant = new PlantTree(true, PlantPoint);
                CurrentPlantList.AddNewPlant(plant);
        }
        
    }
}

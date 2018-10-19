using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public abstract class Ship: IHittable
    {
        private int hitPoints;
        public int Size { get; private set; }
        public int Width { get; private set; }

        public int HitPoints { get { return hitPoints; } }
        public int[] FirstCoordinate { get; private set; }
        public int[] LastCoordinate { get; private set; }

        public Ship(int size, int width, int[] firstCoordinate, orientation orient)
        {
            int[] lastCoordinate = new int[2];

            Size = size;
            Width = width;
            hitPoints = Size * Width;
            FirstCoordinate = firstCoordinate;
            switch (orient)
            {
                case orientation.horizontal:

                    lastCoordinate[0] = firstCoordinate[0] + size - 1;
                    lastCoordinate[1] = firstCoordinate[1] + width - 1;
                    break;

                case orientation.vertical:
                    lastCoordinate[0] = firstCoordinate[0] + width - 1;
                    lastCoordinate[1] = firstCoordinate[1] + size - 1;
                    break;

                default:
                    throw new System.ArgumentOutOfRangeException("orient", "A ship must have an orientation.");
            }
            
            if (lastCoordinate[0] < 10 || lastCoordinate[1] < 10)
            {
                LastCoordinate = lastCoordinate;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("lastCoordinate", "Ship cannot be placed outside of the arena.");
            }
        }

        public bool HitCheck(int[] hitCoordinate)
        {
            if (hitCoordinate[0] >= FirstCoordinate[0] && hitCoordinate[0] <= LastCoordinate[0])
            {
                if (hitCoordinate[1] >= FirstCoordinate[1] && hitCoordinate[1] <= LastCoordinate[1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}

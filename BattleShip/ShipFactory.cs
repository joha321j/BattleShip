using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum Orientation
    {
        Horizontal,
        Vertical,
    }
    enum ShipType
    {
        Carrier,
        Battleship,
        Cruiser,
        Submarine,
        Destroyer
    }
    class ShipFactory
    {
        public static IHittable CreateShip(ShipType ship, int[] firstCoordinate, Orientation orient)
        {
            switch (ship)
            {
                case ShipType.Carrier:
                    return new Carrier(firstCoordinate, orient);
                case ShipType.Battleship:
                    return new BattleShip(firstCoordinate, orient);
                case ShipType.Cruiser:
                    return new Cruiser(firstCoordinate, orient);
                case ShipType.Submarine:
                    return new Submarine(firstCoordinate, orient);
                case ShipType.Destroyer:
                    return new Destroyer(firstCoordinate, orient);
                default:
                    throw new System.ArgumentOutOfRangeException("ShipType", "The given ship type was not available.");
            }
        }
    }
}

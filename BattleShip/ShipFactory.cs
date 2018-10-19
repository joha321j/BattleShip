using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum orientation
    {
        horizontal,
        vertical,
    }
    enum shipType
    {
        Carrier,
        Battleship,
        Cruiser,
        Submarine,
        Destroyer
    }
    class ShipFactory
    {
        public static IHittable CreateShip(shipType ship, int[] firstCoordinate, orientation orient)
        {
            switch (ship)
            {
                case shipType.Carrier:
                    return new Carrier(firstCoordinate, orient);
                case shipType.Battleship:
                    return new BattleShip(firstCoordinate, orient);
                case shipType.Cruiser:
                    return new Cruiser(firstCoordinate, orient);
                case shipType.Submarine:
                    return new Submarine(firstCoordinate, orient);
                case shipType.Destroyer:
                    return new Destroyer(firstCoordinate, orient);
                default:
                    throw new System.ArgumentOutOfRangeException("shipType", "The given shiptype was not available.");
            }
        }
    }
}

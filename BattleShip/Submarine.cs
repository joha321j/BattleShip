using System;

namespace BattleShip
{
    internal class Submarine: Ship,IHittable
    {
        public Submarine(int[] firstCoordinate, orientation orient) : base(ShipSize.SubmarineSize.size, ShipSize.SubmarineSize.width, firstCoordinate, orient) { }
    }
}
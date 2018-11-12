using System;

namespace BattleShip
{
    internal class Submarine: Ship,IHittable
    {
        public Submarine(int[] firstCoordinate, Orientation orient) : base(ShipSize.SubmarineSize.size, ShipSize.SubmarineSize.width, firstCoordinate, orient) { }
    }
}
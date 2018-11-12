using System;

namespace BattleShip
{
    internal class Cruiser: Ship,IHittable
    {
        public Cruiser(int[] firstCoordinate, Orientation orient) : base(ShipSize.CruiserSize.size, ShipSize.CruiserSize.width, firstCoordinate, orient) { }
    }
}
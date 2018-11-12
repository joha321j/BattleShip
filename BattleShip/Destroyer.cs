using System;

namespace BattleShip
{
    internal class Destroyer: Ship,IHittable
    {
        public Destroyer(int[] firstCoordinate, Orientation orient) : base(ShipSize.DestroyerSize.size, ShipSize.DestroyerSize.width, firstCoordinate, orient) { }
    }
}
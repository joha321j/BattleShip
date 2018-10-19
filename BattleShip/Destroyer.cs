using System;

namespace BattleShip
{
    internal class Destroyer: Ship,IHittable
    {
        public Destroyer(int[] firstCoordinate, orientation orient) : base(ShipSize.DestroyerSize.size, ShipSize.DestroyerSize.width, firstCoordinate, orient) { }
    }
}
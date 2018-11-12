namespace BattleShip
{
    internal class Carrier : Ship, IHittable
    {
        public Carrier(int[] firstCoordinate, Orientation orient) : base(ShipSize.CarrierSize.size, ShipSize.CarrierSize.width, firstCoordinate, orient){ }
    }
}
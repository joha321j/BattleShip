namespace BattleShip
{
    internal class Carrier : Ship, IHittable
    {
        public Carrier(int[] firstCoordinate, orientation orient) : base(ShipSize.CarrierSize.size, ShipSize.CarrierSize.width, firstCoordinate, orient){ }
    }
}
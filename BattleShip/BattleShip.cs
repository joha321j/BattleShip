using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class BattleShip: Ship,IHittable
    {
        public BattleShip(int[] firstCoordinate, Orientation orient) : base(ShipSize.BattleShipSize.size, ShipSize.BattleShipSize.width, firstCoordinate, orient) { }
    }
}

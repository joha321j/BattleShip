using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal static class ComputerEnemy
    {
        public static void ComputerPlaceShips(Arena computerArena)
        {
            foreach(ShipType ship in (ShipType[])Enum.GetValues(typeof(ShipType)))
            {
                PlaceShip(ship, computerArena);
            }
        }

        private static void PlaceShip(ShipType ship, Arena computerArena)
        {
            Random random = new Random();

            IHittable shipCreated = null;

            bool shipPlaced = false;
            while (!shipPlaced)
            {
                var orientValues = Enum.GetValues(typeof(Orientation));
                Orientation orient = (Orientation) orientValues.GetValue(random.Next(orientValues.Length));
                int[] inputCoordinates = { random.Next(1, 10), random.Next(1, 10) };

                try
                {
                    shipCreated = ShipFactory.CreateShip(ship, inputCoordinates, orient);
                    shipPlaced = true;
                    bool availableCoordinates = computerArena.SpaceAvailable(shipCreated);

                    if (!availableCoordinates)
                    {
                        shipPlaced = false;
                    }
                }
                catch (System.Exception)
                {
                    shipPlaced = false;
                }
            }

            computerArena.AddHittable(shipCreated);
        }

        public static int[] GetAttack(Arena computerArena)
        {
            List<int[]> attackList = new List<int[]>();
            int[] attack = new int[2];
            Random random = new Random();
            bool hasAttacked = false;

            while (!hasAttacked)
            {
                attack[0] = random.Next(1, 10);
                attack[1] = random.Next(1, 10);
                hasAttacked = true;

                foreach (int[] previousAttack in attackList)
                {
                    if (previousAttack[0] == attack[0] && previousAttack[1] == attack[1])
                    {
                        hasAttacked = false;
                    }
                }
            }

            attackList.Add(attack);

            return attack;
        }
    }
}
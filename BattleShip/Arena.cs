using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Arena
    {

        private char[,] _yourMap = new char[9, 9];
        private char[,] _enemyMap = new char[9, 9];
        private int _arenaHealth = 0;
        private List<IHittable> _hittables = new List<IHittable>();

        internal void SaveAttack(int[] coordinate, bool hit)
        {
            if (hit)
            {
                _enemyMap[coordinate[0] - 1, coordinate[1] - 1] = 'H';
            }
            else
            {
                _enemyMap[coordinate[0] - 1, coordinate[1] - 1] = 'M';
            }
        }

        public int HitPoints { get { return _arenaHealth; } }

        public string ArenaName { get; set; }

        public Arena(string name)
        {
            ArenaName = name;

            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    _yourMap[i, k] = '.';
                    _enemyMap[i, k] = ',';
                }
            }
        }
        public void AddHittable(IHittable hittable)
        {
            _hittables.Add(hittable);
            _arenaHealth += hittable.HitPoints;

            for (int i = 0; i <= hittable.LastCoordinate[0] - hittable.FirstCoordinate[0]; i++)
            {
                for (int k = 0; k <= hittable.LastCoordinate[1] - hittable.FirstCoordinate[1]; k++)
                {
                    _yourMap[hittable.FirstCoordinate[0] - 1 + i, hittable.FirstCoordinate[1] - 1 + k] = 'S';
                }

            }
        }

        public bool SpaceAvailable(IHittable hittable)
        {
            bool notAvailable = false;

            for (int i = 0; i <= hittable.LastCoordinate[0] - hittable.FirstCoordinate[0]; i++)
            {
                for (int k = 0; k <= hittable.LastCoordinate[1] - hittable.FirstCoordinate[1]; k++)
                {
                    if (_yourMap[hittable.FirstCoordinate[0] - 1 + i, hittable.FirstCoordinate[1] - 1 + k] == 'S')
                    {
                        return notAvailable;
                    }
                }

            }

            return !notAvailable;
        }

        public void PrintWholeArena()
        {
            PrintEnemyArena();
            Console.WriteLine("-----------------------------");
            PrintMyArena();
        }

        public bool HitCheck(int[] hitCoordinate)
        {
            bool didHit = false;

            foreach (IHittable hittable in _hittables)
            {
                didHit = hittable.HitCheck(hitCoordinate);
                if (didHit)
                {
                    this._arenaHealth--;
                    _yourMap[hitCoordinate[0] - 1, hitCoordinate[1] - 1] = 'D';

                    break;
                }
            }

            return didHit;
        }

        private void PrintEnemyArena()
        {
            PrintArena(_enemyMap);
        }
        internal void PrintMyArena()
        {
            PrintArena(_yourMap);
        }
        private void PrintArena(char[,] map)
        {
            int i = 0;
            int k = 0;
            for (i = 0; i < 10; i++)
            {
                if (k > 0)
                {
                    Console.Write("{0}. ", i);
                }
                for (k = 1; k < 10; k++)
                {
                    if (i == 0)
                    {
                        if (k == 1)
                        {
                            Console.Write("   ");
                        }
                        Console.Write("{0}. ", k);
                    }
                    else
                    {
                        Console.Write(map[k - 1, i - 1] + "  ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}

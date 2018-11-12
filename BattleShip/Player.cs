using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip
{
    internal static class Player
    {
        internal static string GetPlayerName(ref int playerAmount)
        {
            playerAmount += 1;
            Console.WriteLine("Player {0}, please enter your name!", playerAmount);
            string playerNameInput = Console.ReadLine();

            return playerNameInput;
        }

        internal static void PlayerPlaceShips(Arena arena)
        {
            int shipNumbers = 1;
            int shipsPlaced = 0;
            List<ShipType> shipTypesToPlace = new List<ShipType>();



            foreach (ShipType ship in (ShipType[])Enum.GetValues(typeof(ShipType)))
            {
                shipTypesToPlace.Add(ship);
            }

            int amountOfShips = shipTypesToPlace.Count();
            while (shipsPlaced < amountOfShips)
            {
                Console.Clear();
                Console.WriteLine("{0} must now place your ships on your arena!", arena.ArenaName);

                arena.PrintMyArena();

                Console.WriteLine("You need to place the following ships:");


                foreach (ShipType item in shipTypesToPlace)
                {
                    Console.WriteLine(shipNumbers + ". " + item);
                    shipNumbers++;
                }

                Console.WriteLine("Select the ship you wish to place using the number to the left of the ship type.");

                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > shipTypesToPlace.Count)
                {
                    Console.WriteLine("Please select a ship by entering the number to the left of the ship.");
                }
                PlaceShip(shipTypesToPlace[userInput - 1], arena);

                shipNumbers = 1;
                shipTypesToPlace.RemoveAt(userInput - 1);
                shipsPlaced++;
            }


        }

        private static void PlaceShip(ShipType ship, Arena arena)
        {
            int[] inputCoordinates = new int[2];
            int orient = 0;
            bool gotCoordinates = false;
            IHittable shipCreated = null;

            Console.WriteLine("Please select the orientation of your {0}.", ship);
            Console.WriteLine("For horizontal, enter 1.");
            Console.WriteLine("For vertical, enter 2.");

            while (!int.TryParse(Console.ReadLine(), out orient) || orient < 1 || orient > 2)
            {
                Console.WriteLine("Please select an orientation by entering 1 or 2.");
            }

            do
            {
                Console.WriteLine("You must now enter {0}'s start coordinate.", ship);
                Console.WriteLine("Enter the x and y coordinates and separate them with a ';' (x;y).");

                string[] inputArray = Console.ReadLine()?.Split(';');

                for (int i = 0; i < inputArray.Length; i++)
                {
                    gotCoordinates = int.TryParse(inputArray[i], out int coord);

                    if (!gotCoordinates)
                    {
                        Console.WriteLine("Please enter the x and y coordinates and separate them with a ';'.");
                        break;
                    }

                    inputCoordinates[i] = coord;
                }

                try
                {
                    shipCreated = ShipFactory.CreateShip(ship, inputCoordinates, (Orientation)orient - 1);
                    bool availableCoordinates = arena.SpaceAvailable(shipCreated);

                    if (!availableCoordinates)
                    {
                        gotCoordinates = false;
                        Console.WriteLine("Another of your ships has already taken the space!");
                    }

                }
                catch (System.Exception)
                {
                    gotCoordinates = false;
                    Console.Clear();
                    arena.PrintMyArena();
                    Console.WriteLine("Your coordinates are outside the arena. Please ensure, that your entire ship is inside the arena.");
                }



            } while (!gotCoordinates);

            arena.AddHittable(shipCreated);
        }

        internal static int[] GetAttack(Arena arena)
        {
            int[] inputCoordinates = new int[2];
            bool gotCoordinates = false;
            do
            {
                Console.Clear();
                Console.WriteLine("It is now {0}'s turn to attack!", arena.ArenaName);
                Console.WriteLine("Enter the x and y coordinates you wish to attack and seperate them with a ';' (x;y).");

                arena.PrintWholeArena();
                string[] inputArray = Console.ReadLine()?.Split(';');

                if (inputArray != null)
                    for (int i = 0; i < inputArray.Length; i++)
                    {
                        gotCoordinates = int.TryParse(inputArray[i], out int coord);

                        if (!gotCoordinates || coord > 9 || coord < 1)
                        {
                            Console.WriteLine(
                                "Please enter the x and y coordinates and seperate them with a ';',\nand make sure the coordinates are within the arena.");
                            Console.WriteLine("Press any key to try again.");
                            Console.ReadKey();

                            gotCoordinates = false;

                            break;
                        }

                        inputCoordinates[i] = coord;
                    }
            } while (!gotCoordinates);

            return inputCoordinates;

        }
    }
}
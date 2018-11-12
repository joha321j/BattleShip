using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Game: IGame
    {
        //TODO: Game mode. Shorter games with fewer ships.
        //TODO: Players choose arena size.

        private static void Attack(int[] coordinate, Arena arena, Arena arenaTwo)
        {
            bool hit = arena.HitCheck(coordinate);
            arenaTwo.SaveAttack(coordinate, hit);
        }

        private static bool DidLose(int hitPoints)
        {
            return hitPoints < 1;
        }

        public void RunGame()
        {
            PrintIntro();
            int chosenPlayerAmount = ChoosePlayerAmount();

            switch (chosenPlayerAmount)
            {
                case 1:
                    RunSinglePlayerGame();
                    break;
                case 2:
                    RunTwoPlayerGame();
                    break;
            }

        }

        private void RunSinglePlayerGame()
        {
            bool gameOver = false;
            Arena playerArena = new Arena("Player");
            Arena computerArena = new Arena("Computer");

            Player.PlayerPlaceShips(playerArena);
            ComputerEnemy.ComputerPlaceShips(computerArena);

            while (!gameOver)
            {
                int[] attackCoordinates = Player.GetAttack(playerArena);
                Attack(attackCoordinates, computerArena, playerArena);
                Console.Clear();
                playerArena.PrintWholeArena();
                Console.ReadKey();
                Console.Clear();

                if (DidLose(computerArena.HitPoints))
                {
                    Winner(playerArena, out gameOver);
                }

                attackCoordinates = ComputerEnemy.GetAttack(computerArena);
                Attack(attackCoordinates, playerArena, computerArena);

                if (DidLose(playerArena.HitPoints))
                {
                    Winner(computerArena, out gameOver);
                }
            }
        }

        private void RunTwoPlayerGame()
        {
            int playerAmount = 0;
            bool gameOver = false;
            string playerOneName = Player.GetPlayerName(ref playerAmount);
            string playerTwoName = Player.GetPlayerName(ref playerAmount);
            Arena playerOneArena = new Arena(playerOneName);
            Arena playerTwoArena = new Arena(playerTwoName);

            Player.PlayerPlaceShips(playerOneArena);
            Player.PlayerPlaceShips(playerTwoArena);

            while (!gameOver)
            {
                int[] attackCoordinates = Player.GetAttack(playerOneArena);
                Attack(attackCoordinates, playerTwoArena, playerOneArena);
                Console.Clear();
                playerOneArena.PrintWholeArena();
                Console.ReadKey();
                Console.Clear();

                if (DidLose(playerTwoArena.HitPoints))
                {
                    Winner(playerOneArena, out gameOver);
                }

                attackCoordinates = Player.GetAttack(playerTwoArena);
                Attack(attackCoordinates, playerOneArena, playerTwoArena);
                Console.Clear();
                playerTwoArena.PrintWholeArena();
                Console.ReadKey();
                Console.Clear();

                if (DidLose(playerOneArena.HitPoints))
                {
                    Winner(playerTwoArena, out gameOver);
                }
            }
        }

        private void Winner(Arena playerArena, out bool gameOver)
        {
            gameOver = true;

            Console.WriteLine("{0} has won the game!", playerArena.ArenaName);
        }

        private static int ChoosePlayerAmount()
        {
            int playerChoice = 0;
            Console.WriteLine("Please select the amount of players:");
            Console.WriteLine("Press 1 for one human player.");
            Console.WriteLine("Press 2 for two human players.");

            while (int.TryParse(Console.ReadLine(), out playerChoice) && (playerChoice < 1 || playerChoice > 2))
            {
                Console.WriteLine("Please choose between option 1 and 2.");
            }

            return playerChoice;
        }

        private static void PrintIntro()
        {
            Console.WriteLine("Welcome to BattleShip");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}

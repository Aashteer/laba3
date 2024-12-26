using GameProject.Game;
using GameProject.Players;
using GameProject.Cards;
using System;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Игрок 1");
            Player player2 = new Player("Игрок 2");

            CardGame game = new CardGame(player1, player2);

            while (player1.Health > 0 && player2.Health > 0)
            {
                game.NextTurn();
            }

            if (player1.Health <= 0)
                Console.WriteLine("Игрок 2 победил!");
            else
                Console.WriteLine("Игрок 1 победил!");
        }
    }
}

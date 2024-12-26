using GameProject.Game;
using GameProject.Players;
using GameProject.Cards;
using System;
using System.Linq;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация игроков
            Player player1 = new Player("Игрок 1");
            Player player2 = new Player("Игрок 2");

            // Создание игры
            CardGame game = new CardGame(player1, player2);

            Console.WriteLine("Добро пожаловать в коллекционную карточную игру!");
            Console.WriteLine("У каждого игрока на руке всегда будет 3 карты: урон, хилл или защита.");
            Console.WriteLine();

            // Основной игровой цикл
            while (player1.Health > 0 && player2.Health > 0)
            {
                Console.Clear();
                Console.WriteLine($"Текущий ход: {game.CurrentPlayer.Name}");
                PrintPlayerState(game.CurrentPlayer);
                PrintPlayerState(game.Opponent);

                // Убедимся, что у игрока 3 карты на руке
                while (game.CurrentPlayer.Hand.Count < 3)
                {
                    game.CurrentPlayer.DrawCard(game.Deck);
                }

                // Показать карты в руке
                Console.WriteLine("Ваши карты:");
                for (int i = 0; i < game.CurrentPlayer.Hand.Count; i++)
                {
                    var card = game.CurrentPlayer.Hand[i];
                    Console.WriteLine($"{i + 1}. {card.Name} - {card.Description}");
                }

                // Выбор карты
                Console.WriteLine("Введите номер карты, которую хотите сыграть (или 0, чтобы пропустить ход):");
                int choice = -1;
                while (choice < 0 || choice > game.CurrentPlayer.Hand.Count)
                {
                    Console.Write("Ваш выбор: ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice <= game.CurrentPlayer.Hand.Count)
                        break;
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }

                if (choice > 0)
                {
                    // Игрок играет карту
                    var chosenCard = game.CurrentPlayer.Hand[choice - 1];
                    game.CurrentPlayer.PlayCard(chosenCard, game.Opponent);
                }
                else
                {
                    Console.WriteLine("Игрок пропустил ход.");
                }

                // Проверка на победу
                if (game.Opponent.Health <= 0)
                {
                    Console.WriteLine($"Игрок {game.CurrentPlayer.Name} победил!");
                    break;
                }

                // Переход к следующему ходу
                game.NextTurn();
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        // Метод для отображения состояния игрока
        static void PrintPlayerState(Player player)
        {
            Console.WriteLine($"Игрок: {player.Name}");
            Console.WriteLine($"  Здоровье: {player.Health}");
            Console.WriteLine($"  Защита: {player.Defense}");
            Console.WriteLine($"  Мана: {player.Mana}");
            Console.WriteLine();
        }
    }
}

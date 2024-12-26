using GameProject.Cards;
using GameProject.Players;
using System.Collections.Generic;
using System;

namespace GameProject.Game
{
    public class CardGame
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player Opponent { get; set; }
        public Random Dice { get; set; } = new Random();

        public List<Card> Deck { get; set; } = new List<Card>();
        public List<string> GameLog { get; set; } = new List<string>();

        public CardGame(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;

            // Инициализация колоды
            Deck.Add(new HealSpell("Малое исцеление", "Восстанавливает 5 здоровья", 5, 2));
            Deck.Add(new AttackSpell("Огненный шар", "Наносит 6 урона противнику", 6, 3));
            Deck.Add(new DefenseSpell("Стальной щит", "Увеличивает защиту на 4", 4, 2));
            Deck.Add(new HealSpell("Большое исцеление", "Восстанавливает 10 здоровья", 10, 4));
            Deck.Add(new AttackSpell("Молния", "Наносит 8 урона противнику", 8, 5));
            Deck.Add(new Creature("Гоблин", "Существо с атакой 3", 3, 10));
            Deck.Add(new Creature("Тролль", "Существо с атакой 5", 5, 15));
            Deck.Add(new DefenseSpell("Магический барьер", "Блокирует 6 урона", 6, 3));


            // Определение очередности ходов
            var diceRoll1 = Dice.Next(1, 7);
            var diceRoll2 = Dice.Next(1, 7);
            if (diceRoll1 >= diceRoll2)
            {
                CurrentPlayer = player1;
                Opponent = player2;
            }
            else
            {
                CurrentPlayer = player2;
                Opponent = player1;
            }

            GameLog.Add($"Кубик: Игрок {Player1.Name} - {diceRoll1}, Игрок {Player2.Name} - {diceRoll2}. Ходит {CurrentPlayer.Name}.");
        }

        public void NextTurn()
        {
            CurrentPlayer.DrawCard(Deck);
            GameLog.Add($"Игрок {CurrentPlayer.Name} тянет карту.");

            if (Opponent.Health <= 0)
            {
                GameLog.Add($"Игрок {CurrentPlayer.Name} победил!");
                return;
            }

            var temp = CurrentPlayer;
            CurrentPlayer = Opponent;
            Opponent = temp;

        }
    }

}

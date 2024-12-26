using GameProject.Cards;
using System.Collections.Generic;
using System;

namespace GameProject.Players
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Mana { get; set; }  // Мана игрока
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<string> Log { get; set; } = new List<string>();

        public Player(string name)
        {
            Name = name;
            Health = 30;
            Defense = 0;
            Mana = 10;  // Начальная мана
        }

        public void DrawCard(List<Card> deck)
        {
            // Убедимся, что у игрока на руке ровно 3 карты
            if (Hand.Count >= 3) return;

            if (deck.Count > 0)
            {
                Random rand = new Random();
                int index = rand.Next(deck.Count);
                Hand.Add(deck[index]);
                deck.RemoveAt(index);
            }
        }


        // Проверка на достаточность маны и использование карты
        public bool CanPlayCard(Card card)
        {
            if (card is Spell spell && Mana >= spell.ManaCost)
            {
                return true;
            }
            return false;
        }

        public void PlayCard(Card card, Player opponent)
        {
            if (CanPlayCard(card))
            {
                card.Play(this, opponent);
                Hand.Remove(card);
            }
            else
            {
                Log.Add($"Недостаточно маны для использования карты {card.Name}.");
            }
        }
    }
}

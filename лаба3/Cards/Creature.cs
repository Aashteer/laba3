using GameProject.Players;
using System;


namespace GameProject.Cards
{
    public class Creature : Card
    {
        public int Attack { get; set; }
        public int Health { get; set; }

        public Creature(string name, string description, int attack, int health)
        {
            Name = name;
            Description = description;
            Attack = attack;
            Health = health;
        }

        public override void Play(Player player, Player opponent)
        {
            // Проверка на защиту перед тем, как наносить урон
            int damage = Attack;
            if (opponent.Defense > 0)
            {
                int blocked = Math.Min(opponent.Defense, damage);
                damage -= blocked;
                opponent.Defense -= blocked;
                player.Log.Add($"Защита {opponent.Name} заблокировала {blocked} урона.");
            }

            opponent.Health -= damage;
            player.Log.Add($"Игрок {player.Name} вызывает существо {Name}, наносящее {damage} урона.");
        }
    }
}

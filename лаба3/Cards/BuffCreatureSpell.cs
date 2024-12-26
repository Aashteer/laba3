using GameProject.Players;


namespace GameProject.Cards
{
    public class BuffCreatureSpell : Spell
    {
        public BuffCreatureSpell(string name, string description, int power)
            : base(name, description, power, 2) { }

        public override void Play(Player player, Player opponent)
        {
            if (player.Mana >= ManaCost && player.Hand.Count > 0 && player.Hand[0] is Creature creature)
            {
                creature.Attack += Power;  // Усиливаем атаку существа
                player.Mana -= ManaCost;
                player.Log.Add($"Игрок {player.Name} усиливает существо {creature.Name}, увеличив атаку на {Power}.");
            }
            else
            {
                player.Log.Add($"Нет существа для применения усиления или недостаточно маны.");
            }
        }
    }
}

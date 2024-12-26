using GameProject.Players;


namespace GameProject.Cards
{
    public class DefenseSpell : Spell
    {
        public DefenseSpell(string name, string description, int power, int manaCost)
            : base(name, description, power, manaCost) { }

        public override void Play(Player player, Player opponent)
        {
            if (player.Mana >= ManaCost)
            {
                player.Defense += Power;
                player.Mana -= ManaCost;
                player.Log.Add($"Игрок {player.Name} активирует защиту, блокируя {Power} урона.");
            }
            else
            {
                player.Log.Add($"Недостаточно маны для использования {Name}.");
            }
        }
    }
}

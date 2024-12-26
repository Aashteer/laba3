using GameProject.Players;


namespace GameProject.Cards
{
    public class AttackSpell : Spell
    {
        public AttackSpell(string name, string description, int power, int manaCost)
            : base(name, description, power, manaCost) { }

        public override void Play(Player player, Player opponent)
        {
            if (player.Mana >= ManaCost)
            {
                opponent.Health -= Power;
                player.Mana -= ManaCost;
                player.Log.Add($"Игрок {player.Name} атакует противника, нанося {Power} урона.");
            }
            else
            {
                player.Log.Add($"Недостаточно маны для использования {Name}.");
            }
        }
    }
}

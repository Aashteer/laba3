using GameProject.Players;


namespace GameProject.Cards
{
    public class HealSpell : Spell
    {
        public HealSpell(string name, string description, int power, int manaCost)
            : base(name, description, power, manaCost) { }

        public override void Play(Player player, Player opponent)
        {
            if (player.Mana >= ManaCost)
            {
                player.Health += Power;
                player.Mana -= ManaCost;
                player.Log.Add($"Игрок {player.Name} лечит себя на {Power} очков.");
            }
            else
            {
                player.Log.Add($"Недостаточно маны для использования {Name}.");
            }
        }
    }
}

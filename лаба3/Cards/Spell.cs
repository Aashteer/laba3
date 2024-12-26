using GameProject.Players;


namespace GameProject.Cards
{
    public abstract class Spell : Card
    {
        public int Power { get; set; }  // Сила заклинания (может быть использована как стоимость)
        public int ManaCost { get; set; }  // Мана-стоимость заклинания

        public Spell(string name, string description, int power, int manaCost)
        {
            Name = name;
            Description = description;
            Power = power;
            ManaCost = manaCost;
        }

        public override abstract void Play(Player player, Player opponent);
    }
}


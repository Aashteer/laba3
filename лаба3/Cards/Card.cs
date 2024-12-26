using GameProject.Players;

namespace GameProject.Cards
{
    public abstract class Card
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract void Play(Player player, Player opponent);
    }
}

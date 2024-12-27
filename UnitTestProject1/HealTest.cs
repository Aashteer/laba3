using GameProject.Cards;
using GameProject.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class HealCardTests
    {
        private class TestPlayer : Player
        {
            public TestPlayer(string name) : base(name) { }

            public void Heal(int amount)
            {
                Health += amount;
            }
        }

        [TestMethod]
        public void HealCard_Play_ShouldIncreasePlayerHealth()
        {
            // Arrange
            var player = new TestPlayer("Player");
            player.Health = 20; // Set initial health for player

            var healCard = new HealCard(1, "Healing Potion", 10, "Heal 10 health points", "link_to_image");

            // Act
            healCard.Play(player, null); // The opponent is not used in this case

            // Assert
            Assert.AreEqual(30, player.Health, "Player's health should be increased by the card's healing amount.");
        }

        
    }
}

using GameProject.Cards;
using GameProject.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DamageCardTests
    {
        private class TestPlayer : Player
        {
            public TestPlayer(string name) : base(name) { }

            public void TakeDamage(int damage)
            {
                Health -= damage;
            }
        }

        [TestMethod]
        public void DamageCard_Play_ShouldReduceOpponentHealth()
        {
            // Arrange
            var attacker = new TestPlayer("Attacker");
            var defender = new TestPlayer("Defender");
            defender.Health = 20; // Set initial health for defender

            var damageCard = new DamageCard(1, "Fireball", 5, "Deal 5 damage to an opponent", "link_to_image");

            // Act
            damageCard.Play(attacker, defender);

            // Assert
            Assert.AreEqual(15, defender.Health, "Defender's health should be reduced by the card's damage amount.");
        }

        [TestMethod]
        public void DamageCard_Play_ShouldNotReduceHealthBelowZero()
        {
            // Arrange
            var attacker = new TestPlayer("Attacker");
            var defender = new TestPlayer("Defender");
            defender.Health = 3; // Set initial health for defender

            var damageCard = new DamageCard(1, "Fireball", 5, "Deal 5 damage to an opponent", "link_to_image");

            // Act
            damageCard.Play(attacker, defender);

            // Assert
            Assert.AreEqual(0, defender.Health, "Defender's health should not go below zero.");
        }
    }
}

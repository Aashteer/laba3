using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameProject.Cards; // Ensure you have a reference to your Card class
using GameProject.Players;
using System.Collections.Generic;
using лаба3.Cards;

namespace UnitTestProject1
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;
        private Player opponent;
        private List<Card> deck;

        [TestInitialize]
        public void Setup()
        {
            player = new Player("Hero");
            opponent = new Player("Villain");
            deck = new List<Card>
            {
                new ImproveCard(1, "Strength Potion", 5, "Increase defense by 5", "link_to_image"),
                new ImproveCard(2, "Health Potion", 10, "Heal for 10", "link_to_image"),
                new ImproveCard(3, "Shield", 3, "Increase defense by 3", "link_to_image")
            };

            // Initialize player's hand with random cards
            player.InitializeRandomHand(deck);
        }

        [TestMethod]
        public void Player_InitializeRandomHand_ShouldHaveThreeCards()
        {
            Assert.AreEqual(3, player.Hand.Count, "Player should have 3 cards in hand after initialization.");
        }

       
        [TestMethod]
        public void Player_DrawCard_ShouldNotExceedThreeCards()
        {
            // Arrange
            player.Hand.Clear(); // Clear hand to test drawing
            player.Hand.Add(new ImproveCard(1, "Card1", 1, "Description", "link"));
            player.Hand.Add(new ImproveCard(2, "Card2", 1, "Description", "link"));
            player.Hand.Add(new ImproveCard(3, "Card3", 1, "Description", "link"));

            // Act
            player.DrawCard(deck);

            // Assert
            Assert.AreEqual(3, player.Hand.Count, "Player should not be able to draw more than 3 cards.");
        }

        [TestMethod]
        public void Player_PlayCard_ShouldRemoveCardFromHand()
        {
            // Arrange
            var cardToPlay = player.Hand[0];

            // Act
            player.PlayCard(cardToPlay, opponent);

            // Assert
            Assert.IsFalse(player.Hand.Contains(cardToPlay), "Card should be removed from hand after playing.");
        }

        [TestMethod]
        public void Player_Heal_ShouldIncreaseHealth()
        {
            // Arrange
            int initialHealth = player.Health;

            // Act
            player.Heal(10);

            // Assert
            Assert.AreEqual(initialHealth + 10, player.Health, "Player's health should increase by the amount healed.");
        }

        [TestMethod]
        public void Player_Improve_ShouldIncreaseDefense()
        {
            // Arrange
            int initialDefense = player.Defense;

            // Act
            player.Improve(5);

            // Assert
            Assert.AreEqual(initialDefense + 5, player.Defense, "Player's defense should increase by the amount improved.");
        }

        [TestMethod]
        public void Player_TakeDamage_ShouldDecreaseHealth()
        {
            // Arrange
            player.Defense = 2; // Set some defense
            int initialHealth = player.Health;

            // Act
            player.TakeDamage(10);

            // Assert
            Assert.AreEqual(initialHealth - 8, player.Health, "Player's health should decrease by the actual damage taken.");
        }

        
    }
}

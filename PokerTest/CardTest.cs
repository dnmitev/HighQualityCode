namespace PokerTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void AceClubsTest()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string expected = "A♣";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void KingHeartsTest()
        {
            Card card = new Card(CardFace.King, CardSuit.Hearts);
            string expected = "K♥";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void QueenSpadesTest()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Spades);
            string expected = "Q♠";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void JackSpadesTest()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Spades);
            string expected = "J♠";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void TwoDiamondsTest()
        {
            Card card = new Card(CardFace.Two, CardSuit.Diamonds);
            string expected = "2♦";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void ThreeDiamondsTest()
        {
            Card card = new Card(CardFace.Three, CardSuit.Diamonds);
            string expected = "3♦";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void FourDiamondsTest()
        {
            Card card = new Card(CardFace.Four, CardSuit.Diamonds);
            string expected = "4♦";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void FiveHeartsTest()
        {
            Card card = new Card(CardFace.Five, CardSuit.Hearts);
            string expected = "5♥";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void SixHeartsTest()
        {
            Card card = new Card(CardFace.Six, CardSuit.Hearts);
            string expected = "6♥";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void SevenSpadesTest()
        {
            Card card = new Card(CardFace.Seven, CardSuit.Spades);
            string expected = "7♠";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void EightSpadesTest()
        {
            Card card = new Card(CardFace.Eight, CardSuit.Spades);
            string expected = "8♠";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void NineClubsTest()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Clubs);
            string expected = "9♣";

            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void TenClubsTest()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Clubs);
            string expected = "10♣";

            Assert.AreEqual(expected, card.ToString());
        }
    }
}
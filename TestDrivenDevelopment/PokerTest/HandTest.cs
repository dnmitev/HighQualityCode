namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void KentFlushRoyalHandToStringTest()
        {
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            string expected = "10♣ J♣ Q♣ K♣ A♣";

            Assert.AreEqual(expected, hand.ToString());
        }

        [TestMethod]
        public void HandToStringTest()
        {
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            string expected = "10♣ 2♥ 5♦ K♠ A♣";

            Assert.AreEqual(expected, hand.ToString());
        }
    }
}
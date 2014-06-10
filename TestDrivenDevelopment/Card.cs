using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string cardFace = ((int)this.Face).ToString();
            switch (cardFace)
            {
                case "11":
                    cardFace = "J";
                    break;
                case "12":
                    cardFace = "Q";
                    break;
                case "13":
                    cardFace = "K";
                    break;
                case "14":
                    cardFace = "A";
                    break;
            }

            string cardSuit = ((int)this.Suit).ToString();
            switch (cardSuit)
            {
                case "1":
                    cardSuit = "♣";
                    break;
                case "2":
                    cardSuit = "♦";
                    break;
                case "3":
                    cardSuit = "♥";
                    break;
                case "4":
                    cardSuit = "♠";
                    break;
            }

            return cardFace + cardSuit;
        }
    }
}

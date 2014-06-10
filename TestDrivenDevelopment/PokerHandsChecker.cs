namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int count = GetCountOfSameCards(hand);

            if (count == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            bool pair = checker.IsOnePair(hand);
            bool threeOfAKind = checker.IsThreeOfAKind(hand);

            if (pair && threeOfAKind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            CardSuit suit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (suit != hand.Cards[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            int count = GetCountOfSameCards(hand);

            if (count == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            int pairCount = GetPairCount(hand);

            if (pairCount == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            int pairCount = GetPairCount(hand);

            if (pairCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private int GetCountOfSameCards(IHand hand)
        {
            int bestCount = 0;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                int currentCount = 1;

                for (int j = 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        currentCount++;
                    }
                }

                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                }
            }

            return bestCount;
        }

        private int GetPairCount(IHand hand)
        {
            int pairCount = 0;

            var cards = new Dictionary<CardFace, int>();

            cards.Add(hand.Cards[0].Face, 1);

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (cards.ContainsKey(hand.Cards[i].Face))
                {
                    cards[hand.Cards[i].Face]++;
                }
                else
                {
                    cards.Add(hand.Cards[i].Face, 1);
                }
            }

            foreach (var card in cards)
            {
                if (card.Value == 2)
                {
                    pairCount++;
                }
            }

            return pairCount;
        }
    }
}
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
            var checker = new PokerHandsChecker();

            bool straight = checker.IsStraight(hand);
            bool flush = checker.IsFlush(hand);

            if (straight && flush)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            // check for an ace
            bool hasAce = false;
            var cards = new List<int>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Face == CardFace.Ace)
                {
                    hasAce = true;
                }
                else
                {
                    cards.Add((int)hand.Cards[i].Face);
                }
            }

            cards.Sort();

            if (cards[0] == 10 && hasAce)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (cards[i] != i + 10)
                    {
                        return false;
                    }
                }
            }
            else if (cards[0] == 2 && hasAce)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (cards[i] != i + 2)
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 1; i < 5; i++)
                {
                    if (cards[i] - cards[i - 1] != 1)
                    {
                        return false;
                    }
                }
            }

            return true;
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
            if (this.IsFlush(hand) || this.IsFourOfAKind(hand) ||
                this.IsFullHouse(hand) || this.IsOnePair(hand) ||
                this.IsStraight(hand) || this.IsStraightFlush(hand) ||
                this.IsThreeOfAKind(hand) || this.IsTwoPair(hand))
            {
                return false;
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            // Sorry, but I have to do also a JS teamwork 
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
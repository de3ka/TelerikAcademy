using NUnit.Framework;
using Santase.Logic;
using Santase.Logic.Cards;
using System.Collections.Generic;

namespace DeckTest
{
    [TestFixture]
    public class DeckTest
    {
        [Test]
        public void Deck_Should_Have_24_Cards()
        {
            var deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void TrumpCard_Should_Not_Be_Null()
        {
            var deck = new Deck();

            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        public void ChangeTrumpCard_Should_Succeed_When_Provided_Valid_Data()
        {
            var deck = new Deck()
; var card = new Card(CardSuit.Heart, CardType.Queen);
            deck.ChangeTrumpCard(card);
            Assert.AreSame(card, deck.TrumpCard);
        }

        [Test]
        public void GetNextCard_Should_Throw_InternalGameException_When_Cards_Over()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(20)]
        public void GetNextCard_Should_Not_Return_Null(int numberOfTests)
        {
            var deck = new Deck();
            for (int i = 0; i < numberOfTests; i++)
            {
                Assert.IsNotNull(deck.GetNextCard());
            }
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(20)]
        public void GetNextCard_Sould_Return_Different_Cards_Every_Time(int nextCardTries)
        {
            var deck = new Deck();
            var returnedCards = new List<Card>();

            for (int i = 0; i < nextCardTries; i++)
            {
                returnedCards.Add(deck.GetNextCard());
            }

            for (int i = 0; i < returnedCards.Count - 1; i++)
            {
                var firstCard = returnedCards[i];
                for (int j = i + 1; j < returnedCards.Count; j++)
                {
                    if (firstCard.Equals(returnedCards[j]))
                    {
                        Assert.Fail("Deck.GetNextCard() returned the same cards instead of removing the card when returninig it.");
                    }
                }
            }
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(20)]
        public void CardsLeft_Should_Decrease_Its_Count_When_Getting_Next_Card(int timesCall)
        {
            var deck = new Deck();

            for (int i = 0; i < timesCall; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(24 - timesCall, deck.CardsLeft);
        }

        [Test]
        [TestCase(4)]
        [TestCase(8)]
        public void Decks_Should_Shuffle(int numberOfTimesChecked)
        {
            bool IsSameDeck = true;


            for (int times = 0; times < numberOfTimesChecked; times++)
            {
                var deck1 = new Deck();
                var deck2 = new Deck();

                for (int i = 0; i < 24; i++)
                {
                    var card1 = deck1.GetNextCard();
                    var card2 = deck2.GetNextCard();
                    if (card1.Suit != card2.Suit || card1.Type != card2.Type)
                    {
                        IsSameDeck = false;
                    }
                }
            }

            Assert.IsFalse(IsSameDeck);
        }
    }
}
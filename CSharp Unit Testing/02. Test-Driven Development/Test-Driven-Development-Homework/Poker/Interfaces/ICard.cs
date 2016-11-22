using Poker.Enums;

namespace Poker.Interfaces
{
    public interface ICard
    {
        CardFace Face { get; }

        CardSuit Suit { get; }

        string ToString();
    }
}

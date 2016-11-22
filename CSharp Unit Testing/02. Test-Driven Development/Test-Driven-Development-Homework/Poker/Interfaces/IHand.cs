using System.Collections.Generic;

namespace Poker.Interfaces
{
    public interface IHand
    {
        IList<ICard> Cards { get; }

        string ToString();
    }
}

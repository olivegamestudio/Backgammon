using System.Diagnostics;

namespace Backgammon;

[DebuggerDisplay("Point={Point} Color={Color} Count={Count}")]
public class BackgammonPoint
{
    public int Point { get; set; }

    public int Count { get; set; }

    public PieceColor Color { get; set; }
}

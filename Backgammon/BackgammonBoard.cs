namespace Backgammon;

public class BackgammonBoard
{
    readonly List<BackgammonPoint> _points = new();

    bool Exists(int point) => _points.Any(it => it.Point == point);
    
    public Task AddPiece(PieceColor pieceColor, int point)
    {
        BackgammonPoint p = GetPoint(point);
        p.Color = pieceColor;
        p.Count++;
        return Task.CompletedTask;
    }

    Task RemovePiece(BackgammonPoint point)
    {
        point.Count--;

        if (point.Count == 0)
        {
            point.Color = PieceColor.None;
        }

        return Task.CompletedTask;
    }

    public async Task MovePiece(int point)
    {
        BackgammonPoint p = GetPoint(point);
        switch (p.Color)
        {
            case PieceColor.White:
            {
                await RemovePiece(p);
                await AddPiece(PieceColor.White, point - 1);
                break;
            }
            case PieceColor.Black:
            {
                await RemovePiece(p);
                await AddPiece(PieceColor.Black, point + 1);
                break;
            }
        }
    }

    public BackgammonPoint GetPoint(int point)
    {
        if (Exists(point))
        {
            return _points.First(it => it.Point == point);
        }

        BackgammonPoint p = new BackgammonPoint { Point = point, Count = 0, Color = PieceColor.None };
        _points.Add(p);
        return p;
    }
}

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

    public async Task<bool> MovePiece(int point, int numPoints)
    {
        BackgammonPoint p = GetPoint(point);
        switch (p.Color)
        {
            case PieceColor.White:
            {
                if (GetPoint(point - numPoints).Color == PieceColor.Black &&
                    GetPoint(point - numPoints).Count >= 2)
                {
                    return false;
                }

                await RemovePiece(p);
                await AddPiece(PieceColor.White, point - numPoints);
                return true;
            }

            case PieceColor.Black:
            {
                if (GetPoint(point + numPoints).Color == PieceColor.White &&
                    GetPoint(point + numPoints).Count >= 2)
                {
                    return false;
                }

                await RemovePiece(p);
                await AddPiece(PieceColor.Black, point + numPoints);
                return true;
            }
        }

        return false;
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

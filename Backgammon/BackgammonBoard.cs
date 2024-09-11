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

    bool CanMove(PieceColor color, int point)
    {
        switch (color)
        {
            case PieceColor.White:
            {
                if (GetPoint(point).Color == PieceColor.Black && GetPoint(point).Count >= 2)
                {
                    return false;
                }

                break;

            }
            case PieceColor.Black:
            {
                if (GetPoint(point).Color == PieceColor.White && GetPoint(point).Count >= 2)
                {
                    return false;
                }

                break;
            }
        }

        return true;
    }

    public async Task<bool> MovePiece(int point, int numPoints)
    {
        BackgammonPoint p = GetPoint(point);
        switch (p.Color)
        {
            case PieceColor.White:
            {
                if (!CanMove(PieceColor.White, point - numPoints))
                {
                    return false;
                }

                await RemovePiece(p);

                if(GetPoint(point - numPoints).Color == PieceColor.Black &&
                   GetPoint(point - numPoints).Count == 1)
                {
                    await RemovePiece(GetPoint(point - numPoints));
                    await AddPiece(PieceColor.Black, 0);
                }

                await AddPiece(PieceColor.White, point - numPoints);
                return true;
            }

            case PieceColor.Black:
            {
                if (!CanMove(PieceColor.Black, point + numPoints))
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

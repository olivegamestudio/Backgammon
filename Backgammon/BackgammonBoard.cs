namespace Backgammon;

public class BackgammonBoard
{
    readonly List<BackgammonPoint> _points = new();

    public PieceColor Winner
    {
        get
        {
            bool whitePlaying = false;
            bool blackPlaying = false;

            foreach (BackgammonPoint point in _points)
            {
                if (point.Color == PieceColor.White)
                {
                    whitePlaying = true;
                }
                if (point.Color == PieceColor.Black)
                {
                    blackPlaying = true;
                }
            }

            if (whitePlaying && !blackPlaying)
                return PieceColor.Black;

            if (!whitePlaying && blackPlaying)
                return PieceColor.White;

            return PieceColor.None;
        }
    }

    public async Task CreateGameBoard()
    {
        await AddPiece(PieceColor.White, 24, 2);
        await AddPiece(PieceColor.Black, 19, 5);
        await AddPiece(PieceColor.Black, 17, 3);
        await AddPiece(PieceColor.White, 13, 5);
        await AddPiece(PieceColor.Black, 12, 5);
        await AddPiece(PieceColor.White, 8, 3);
        await AddPiece(PieceColor.White, 6, 5);
        await AddPiece(PieceColor.Black, 1, 2);
    }

    public bool IsRunning => _points.Any(it => it.Color == PieceColor.White) && _points.Any(it => it.Color == PieceColor.Black);

    bool Exists(int point) => _points.Any(it => it.Point == point);

    bool ArePiecesInHome(PieceColor pieceColor)
    {
        foreach (BackgammonPoint point in _points)
        {
            switch (pieceColor)
            {
                case PieceColor.White when point.Color == pieceColor && point.Point < 19:
                case PieceColor.Black when point.Color == pieceColor && point.Point > 6:
                    return false;
            }
        }

        return true;
    }

    public Task AddPiece(PieceColor pieceColor, int point, int numPieces = 1)
    {
        if (pieceColor == PieceColor.White && point < 1)
        {
            // piece removed from board.
            return Task.CompletedTask;
        }

        if (pieceColor == PieceColor.Black && point > 24)
        {
            // piece removed from board.
            return Task.CompletedTask;
        }

        BackgammonPoint p = GetPoint(point);
        p.Color = pieceColor;
        p.Count+=numPieces;
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

    public bool CanMove(PieceColor color, int point)
    {
        switch (color)
        {
            case PieceColor.White:
            {
                if (point < 1 && ArePiecesInHome(PieceColor.White))
                {
                    return true;
                }

                if (GetPoint(point).Color == PieceColor.Black && GetPoint(point).Count >= 2)
                {
                    return false;
                }

                break;

            }
            case PieceColor.Black:
            {
                if (point > 24 && ArePiecesInHome(PieceColor.Black))
                {
                    return true;
                }

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

                if (GetPoint(point + numPoints).Color == PieceColor.White &&
                    GetPoint(point + numPoints).Count == 1)
                {
                    await RemovePiece(GetPoint(point + numPoints));
                    await AddPiece(PieceColor.White, 25);
                }

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

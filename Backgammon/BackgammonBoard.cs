﻿namespace Backgammon;

public class BackgammonBoard
{
    readonly List<BackgammonPoint> _points = new();

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
    
    public Task AddPiece(PieceColor pieceColor, int point, int numPieces = 1)
    {
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

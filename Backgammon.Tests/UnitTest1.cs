namespace Backgammon.Tests;

public class Tests
{
    [Test]
    public async Task Move_White_Piece_One_Point()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.White, 24);
        bool result = await board.MovePiece(24, 1);

        Assert.IsTrue(result);

        Assert.IsTrue(board.GetPoint(24).Count == 0);
        Assert.IsTrue(board.GetPoint(24).Color == PieceColor.None);

        Assert.IsTrue(board.GetPoint(23).Count == 1);
        Assert.IsTrue(board.GetPoint(23).Color == PieceColor.White);
    }

    [Test]
    public async Task Move_Back_Piece_One_Point()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.Black, 1);
        bool result = await board.MovePiece(1, 1);

        Assert.IsTrue(result);

        Assert.IsTrue(board.GetPoint(1).Count == 0);
        Assert.IsTrue(board.GetPoint(1).Color == PieceColor.None);

        Assert.IsTrue(board.GetPoint(2).Count == 1);
        Assert.IsTrue(board.GetPoint(2).Color == PieceColor.Black);
    }

    [Test]
    public async Task Move_White_Piece_One_Point_But_Blocked()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.White, 24);
        await board.AddPiece(PieceColor.Black, 23);
        await board.AddPiece(PieceColor.Black, 23);
        bool result = await board.MovePiece(24, 1);

        Assert.IsFalse(result);

        Assert.IsTrue(board.GetPoint(24).Count == 1);
        Assert.IsTrue(board.GetPoint(24).Color == PieceColor.White);

        Assert.IsTrue(board.GetPoint(23).Count == 2);
        Assert.IsTrue(board.GetPoint(23).Color == PieceColor.Black);
    }

    [Test]
    public async Task Move_Black_Piece_One_Point_But_Blocked()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.Black, 1);
        await board.AddPiece(PieceColor.White, 2);
        await board.AddPiece(PieceColor.White, 2);
        bool result = await board.MovePiece(1, 1);

        Assert.IsFalse(result);

        Assert.IsTrue(board.GetPoint(1).Count == 1);
        Assert.IsTrue(board.GetPoint(1).Color == PieceColor.Black);

        Assert.IsTrue(board.GetPoint(2).Count == 2);
        Assert.IsTrue(board.GetPoint(2).Color == PieceColor.White);
    }
}

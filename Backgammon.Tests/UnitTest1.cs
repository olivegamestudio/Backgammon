namespace Backgammon.Tests;

public class Tests
{
    [Test]
    public async Task Move_White_Piece_One_Point()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.White, 24);
        await board.MovePiece(24);

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
        await board.MovePiece(1);

        Assert.IsTrue(board.GetPoint(1).Count == 0);
        Assert.IsTrue(board.GetPoint(1).Color == PieceColor.None);

        Assert.IsTrue(board.GetPoint(2).Count == 1);
        Assert.IsTrue(board.GetPoint(2).Color == PieceColor.Black);
    }
}

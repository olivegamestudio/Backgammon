namespace Backgammon.Tests;

public class Tests
{
    [Test]
    public async Task Move_White_Piece_One_Point()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.White, 24);
        bool result = await board.MovePiece(24, 1);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(24).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(24).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(23).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(23).Color, Is.EqualTo(PieceColor.White));
    }

    [Test]
    public async Task Move_Back_Piece_One_Point()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.Black, 1);
        bool result = await board.MovePiece(1, 1);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(1).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(1).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(2).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(2).Color, Is.EqualTo(PieceColor.Black));
    }

    [Test]
    public async Task Move_White_Piece_One_Point_But_Blocked()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.White, 24);
        await board.AddPiece(PieceColor.Black, 23);
        await board.AddPiece(PieceColor.Black, 23);
        bool result = await board.MovePiece(24, 1);

        Assert.That(result, Is.EqualTo(false));

        Assert.That(board.GetPoint(24).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(24).Color, Is.EqualTo(PieceColor.White));

        Assert.That(board.GetPoint(23).Count, Is.EqualTo(2));
        Assert.That(board.GetPoint(23).Color, Is.EqualTo(PieceColor.Black));
    }

    [Test]
    public async Task Move_Black_Piece_One_Point_But_Blocked()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.Black, 1);
        await board.AddPiece(PieceColor.White, 2);
        await board.AddPiece(PieceColor.White, 2);
        bool result = await board.MovePiece(1, 1);

        Assert.That(result, Is.EqualTo(false));

        Assert.That(board.GetPoint(1).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(1).Color, Is.EqualTo(PieceColor.Black));

        Assert.That(board.GetPoint(2).Count, Is.EqualTo(2));
        Assert.That(board.GetPoint(2).Color, Is.EqualTo(PieceColor.White));
    }

    [Test]
    public async Task Move_White_Piece_One_Point_Takes_Black_Piece()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.White, 24);
        await board.AddPiece(PieceColor.Black, 23);
        bool result = await board.MovePiece(24, 1);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(24).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(24).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(23).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(23).Color, Is.EqualTo(PieceColor.White));

        Assert.That(board.GetPoint(0).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(0).Color, Is.EqualTo(PieceColor.Black));
    }

    [Test]
    public async Task Move_Black_Piece_One_Point_Takes_White_Piece()
    {
        BackgammonBoard board = new();

        await board.AddPiece(PieceColor.Black, 1);
        await board.AddPiece(PieceColor.White, 2);
        bool result = await board.MovePiece(1, 1);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(1).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(1).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(2).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(2).Color, Is.EqualTo(PieceColor.Black));

        Assert.That(board.GetPoint(25).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(25).Color, Is.EqualTo(PieceColor.White));
    }
}

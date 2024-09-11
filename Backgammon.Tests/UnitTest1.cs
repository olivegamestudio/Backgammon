namespace Backgammon.Tests;

public class Tests
{
    [Test]
    [TestCase(24, 1)]
    [TestCase(23, 1)]
    [TestCase(22, 1)]
    [TestCase(21, 1)]
    [TestCase(20, 1)]
    [TestCase(19, 1)]
    [TestCase(18, 1)]
    [TestCase(17, 1)]
    [TestCase(16, 1)]
    [TestCase(15, 1)]
    [TestCase(14, 1)]
    [TestCase(13, 1)]
    [TestCase(12, 1)]
    [TestCase(11, 1)]
    [TestCase(10, 1)]
    [TestCase(9, 1)]
    [TestCase(8, 1)]
    [TestCase(7, 1)]
    [TestCase(6, 1)]
    [TestCase(5, 1)]
    [TestCase(4, 1)]
    [TestCase(3, 1)]
    [TestCase(2, 1)]
    public async Task Move_White_Piece(int point, int movePoints)
    {
        BackgammonBoard board = new();
        
        int destinationPoint = point - movePoints;

        await board.AddPiece(PieceColor.White, point);
        bool result = await board.MovePiece(point, movePoints);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(point).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(point).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(destinationPoint).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(destinationPoint).Color, Is.EqualTo(PieceColor.White));
    }

    [Test]
    [TestCase(23, 1)]
    [TestCase(22, 1)]
    [TestCase(21, 1)]
    [TestCase(20, 1)]
    [TestCase(19, 1)]
    [TestCase(18, 1)]
    [TestCase(17, 1)]
    [TestCase(16, 1)]
    [TestCase(15, 1)]
    [TestCase(14, 1)]
    [TestCase(13, 1)]
    [TestCase(12, 1)]
    [TestCase(11, 1)]
    [TestCase(10, 1)]
    [TestCase(9, 1)]
    [TestCase(8, 1)]
    [TestCase(7, 1)]
    [TestCase(6, 1)]
    [TestCase(5, 1)]
    [TestCase(4, 1)]
    [TestCase(3, 1)]
    [TestCase(2, 1)]
    [TestCase(1, 1)]
    public async Task Move_Black_Piece(int point, int movePoints)
    {
        BackgammonBoard board = new();
        
        int destinationPoint = point + movePoints;

        await board.AddPiece(PieceColor.Black, point);
        bool result = await board.MovePiece(point, movePoints);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(point).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(point).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(destinationPoint).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(destinationPoint).Color, Is.EqualTo(PieceColor.Black));
    }

    [Test]
    [TestCase(24, 1)]
    [TestCase(23, 1)]
    [TestCase(22, 1)]
    [TestCase(21, 1)]
    [TestCase(20, 1)]
    [TestCase(19, 1)]
    [TestCase(18, 1)]
    [TestCase(17, 1)]
    [TestCase(16, 1)]
    [TestCase(15, 1)]
    [TestCase(14, 1)]
    [TestCase(13, 1)]
    [TestCase(12, 1)]
    [TestCase(11, 1)]
    [TestCase(10, 1)]
    [TestCase(9, 1)]
    [TestCase(8, 1)]
    [TestCase(7, 1)]
    [TestCase(6, 1)]
    [TestCase(5, 1)]
    [TestCase(4, 1)]
    [TestCase(3, 1)]
    [TestCase(2, 1)]
    public async Task Move_White_Piece_But_Blocked(int point, int movePoints)
    {
        BackgammonBoard board = new();

        int destinationPoint = point - movePoints;

        await board.AddPiece(PieceColor.White, point);
        await board.AddPiece(PieceColor.Black, destinationPoint);
        await board.AddPiece(PieceColor.Black, destinationPoint);
        bool result = await board.MovePiece(point, 1);

        Assert.That(result, Is.EqualTo(false));

        Assert.That(board.GetPoint(point).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(point).Color, Is.EqualTo(PieceColor.White));

        Assert.That(board.GetPoint(destinationPoint).Count, Is.EqualTo(2));
        Assert.That(board.GetPoint(destinationPoint).Color, Is.EqualTo(PieceColor.Black));
    }

    [Test]
    [TestCase(23, 1)]
    [TestCase(22, 1)]
    [TestCase(21, 1)]
    [TestCase(20, 1)]
    [TestCase(19, 1)]
    [TestCase(18, 1)]
    [TestCase(17, 1)]
    [TestCase(16, 1)]
    [TestCase(15, 1)]
    [TestCase(14, 1)]
    [TestCase(13, 1)]
    [TestCase(12, 1)]
    [TestCase(11, 1)]
    [TestCase(10, 1)]
    [TestCase(9, 1)]
    [TestCase(8, 1)]
    [TestCase(7, 1)]
    [TestCase(6, 1)]
    [TestCase(5, 1)]
    [TestCase(4, 1)]
    [TestCase(3, 1)]
    [TestCase(2, 1)]
    [TestCase(1, 1)]
    public async Task Move_Black_Piece_But_Blocked(int point, int movePoints)
    {
        BackgammonBoard board = new();

        int destinationPoint = point + movePoints;

        await board.AddPiece(PieceColor.Black, point);
        await board.AddPiece(PieceColor.White, destinationPoint);
        await board.AddPiece(PieceColor.White, destinationPoint);

        bool result = await board.MovePiece(point, movePoints);

        Assert.That(result, Is.EqualTo(false));

        Assert.That(board.GetPoint(point).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(point).Color, Is.EqualTo(PieceColor.Black));

        Assert.That(board.GetPoint(destinationPoint).Count, Is.EqualTo(2));
        Assert.That(board.GetPoint(destinationPoint).Color, Is.EqualTo(PieceColor.White));
    }

    [Test]
    [TestCase(24, 1)]
    [TestCase(23, 1)]
    [TestCase(22, 1)]
    [TestCase(21, 1)]
    [TestCase(20, 1)]
    [TestCase(19, 1)]
    [TestCase(18, 1)]
    [TestCase(17, 1)]
    [TestCase(16, 1)]
    [TestCase(15, 1)]
    [TestCase(14, 1)]
    [TestCase(13, 1)]
    [TestCase(12, 1)]
    [TestCase(11, 1)]
    [TestCase(10, 1)]
    [TestCase(9, 1)]
    [TestCase(8, 1)]
    [TestCase(7, 1)]
    [TestCase(6, 1)]
    [TestCase(5, 1)]
    [TestCase(4, 1)]
    [TestCase(3, 1)]
    [TestCase(2, 1)]
    public async Task Move_White_Piece_Takes_Black_Piece(int point, int movePoints)
    {
        BackgammonBoard board = new();

        int destinationPoint = point - movePoints;

        await board.AddPiece(PieceColor.White, point);
        await board.AddPiece(PieceColor.Black, destinationPoint);

        bool result = await board.MovePiece(point, movePoints);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(point).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(point).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(destinationPoint).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(destinationPoint).Color, Is.EqualTo(PieceColor.White));

        Assert.That(board.GetPoint(0).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(0).Color, Is.EqualTo(PieceColor.Black));
    }

    [Test]
    [TestCase(23, 1)]
    [TestCase(22, 1)]
    [TestCase(21, 1)]
    [TestCase(20, 1)]
    [TestCase(19, 1)]
    [TestCase(18, 1)]
    [TestCase(17, 1)]
    [TestCase(16, 1)]
    [TestCase(15, 1)]
    [TestCase(14, 1)]
    [TestCase(13, 1)]
    [TestCase(12, 1)]
    [TestCase(11, 1)]
    [TestCase(10, 1)]
    [TestCase(9, 1)]
    [TestCase(8, 1)]
    [TestCase(7, 1)]
    [TestCase(6, 1)]
    [TestCase(5, 1)]
    [TestCase(4, 1)]
    [TestCase(3, 1)]
    [TestCase(2, 1)]
    [TestCase(1, 1)]
    public async Task Move_Black_Piece_Takes_White_Piece(int point, int movePoints)
    {
        BackgammonBoard board = new();

        int destinationPoint = point + movePoints;

        await board.AddPiece(PieceColor.Black, point);
        await board.AddPiece(PieceColor.White, destinationPoint);
        bool result = await board.MovePiece(point, movePoints);

        Assert.That(result, Is.EqualTo(true));

        Assert.That(board.GetPoint(point).Count, Is.EqualTo(0));
        Assert.That(board.GetPoint(point).Color, Is.EqualTo(PieceColor.None));

        Assert.That(board.GetPoint(destinationPoint).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(destinationPoint).Color, Is.EqualTo(PieceColor.Black));

        Assert.That(board.GetPoint(25).Count, Is.EqualTo(1));
        Assert.That(board.GetPoint(25).Color, Is.EqualTo(PieceColor.White));
    }
}

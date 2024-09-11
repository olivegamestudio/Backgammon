namespace Backgammon.Tests;

public class GameTests
{
    [Test]
    public async Task Run_Game_To_End()
    {
        BackgammonBoard board = new();
        await board.CreateGameBoard();

        Random dice = new();
        PieceColor color = PieceColor.White;

        while (board.IsRunning)
        {
            int die = dice.Next(1, 7);

            if (color == PieceColor.White)
            {
                for (int i = 24; i > 0; i--)
                {
                    if (board.GetPoint(i).Color == PieceColor.White)
                    {
                        if (board.CanMove(color, i))
                        {
                            await board.MovePiece(i, die);
                            break;
                        }
                    }
                }

                color = PieceColor.Black;
            }
            else
            {
                for (int i = 1; i < 25; i++)
                {
                    if (board.GetPoint(i).Color == PieceColor.Black)
                    {
                        if (board.CanMove(color, i))
                        {
                            await board.MovePiece(i, die);
                            break;
                        }
                    }
                }

                color = PieceColor.White;
            }
        }
    }
}

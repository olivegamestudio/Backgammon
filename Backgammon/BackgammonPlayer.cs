namespace Backgammon;

public class BackgammonPlayer
{
    public PieceColor Color { get; set; }

    public async Task TakeTurn(BackgammonBoard board, int die)
    {
        if(Color == PieceColor.White)
        {
            if (board.GetPoint(BackgammonBoard.WhiteBar).Color == PieceColor.White &&
                board.GetPoint(BackgammonBoard.WhiteBar).Count > 0)
            {
                if (board.CanMove(PieceColor.White, 25))
                {
                    await board.MovePiece(25, die);
                    return;
                }
            }

            for (int i = 24; i > 0; i--)
            {
                if (board.GetPoint(i).Color == PieceColor.White)
                {
                    if (board.CanMove(Color, i))
                    {
                        await board.MovePiece(i, die);
                        return;
                    }
                }
            }

            return;
        }

        if (board.GetPoint(BackgammonBoard.BlackBar).Color == PieceColor.Black &&
            board.GetPoint(BackgammonBoard.BlackBar).Count > 0)
        {
            if (board.CanMove(PieceColor.White, -1))
            {
                await board.MovePiece(-1, die);
                return;
            }
        }

        for (int i = 1; i < 25; i++)
        {
            if (board.GetPoint(i).Color == PieceColor.Black)
            {
                if (board.CanMove(Color, i))
                {
                    await board.MovePiece(i, die);
                    return;
                }
            }
        }
    }
}

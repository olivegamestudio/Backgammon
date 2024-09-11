namespace Backgammon.Tests;

public class GameTests
{
    [Test]
    public async Task Run_Game_To_End()
    {
        BackgammonBoard board = new();
        await board.CreateGameBoard();

        BackgammonPlayer whitePlayer = new() { Color = PieceColor.White };
        BackgammonPlayer blackPlayer = new() { Color = PieceColor.Black };

        Dice dice = new();
        PieceColor color = PieceColor.White;

        while (board.IsRunning)
        {
            List<int> d = dice.GetDice(2, true);
            foreach (int die in d)
            {
                await whitePlayer.TakeTurn(board, die);
            }

            d = dice.GetDice(2, true);
            foreach(int die in d)
            {
                await blackPlayer.TakeTurn(board, die);
            } 
        }

        Console.WriteLine("The winner is: " + board.Winner);
    }
}

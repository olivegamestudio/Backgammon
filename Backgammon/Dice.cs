namespace Backgammon;

public class Dice
{
    Random r = new();

    public List<int> GetDice(int numDice, bool doubles)
    {
        List<int> dice = new();

        for(int n=0;n<numDice;n++)
        {
            dice.Add(r.Next(1, 7));
        }

        if(doubles && numDice == 2)
        {
            if (dice[0] == dice[1])
            {
                dice.Add(dice[0]);
                dice.Add(dice[1]);
            }
        }

        return dice;
    }
}

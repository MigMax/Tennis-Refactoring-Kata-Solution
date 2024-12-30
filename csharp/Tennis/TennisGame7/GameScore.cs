namespace Tennis;

public class GameScore
{
    public int Player1;
    public int Player2;

    public void Player1Won()
    {
        Player1++;
    }
    
    public void Player2Won()
    {
        Player2++;
    }
    
    public bool IsTie => Player1 == Player2;
    
    public bool IsEndGame => Player1 >= 4 || Player2 >= 4;
}
namespace Tennis;

public class TennisGame7(string player1Name, string player2Name) : ITennisGame
{
    private readonly GameScore _score = new();

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
        {
            _score.Player1Won();
        }
        else
        {
            _score.Player2Won();
        }
    }

    public string GetScore() => $"Current score: {_score.GetScoreByContext(player1Name, player2Name)}, enjoy your game!";
}
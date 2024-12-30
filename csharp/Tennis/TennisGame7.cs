namespace Tennis;

public class TennisGame7(string player1Name, string player2Name) : ITennisGame
{
    private int _player1Score;
    private int _player2Score;

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
        {
            _player1Score++;
        }
        else
        {
            _player2Score++;
        }
    }

    public string GetScore() => $"Current score: {GetScoreByContext()}, enjoy your game!";

    private string GetScoreByContext()
    {
        if (_player1Score == _player2Score)
        {
            return GetTieScore();
        }

        if (_player1Score >= 4 || _player2Score >= 4)
        {
            return GetEndGameScore();
        }

        return GetRegularScore();
    }
    
    private string GetTieScore() => _player1Score switch
    {
        0 => "Love-All",
        1 => "Fifteen-All",
        2 => "Thirty-All",
        _ => "Deuce"
    };

    private string GetEndGameScore() => (_player1Score - _player2Score) switch
    {
        1 => $"Advantage {player1Name}",
        -1 => $"Advantage {player2Name}",
        >= 2 => $"Win for {player1Name}",
        _ => $"Win for {player2Name}"
    };

    private string GetRegularScore() => $"{GetScoreLabel(_player1Score)}-{GetScoreLabel(_player2Score)}";

    private static string GetScoreLabel(int score) => score switch 
    {
        0 => "Love",
        1 => "Fifteen",
        2 => "Thirty",
        _ => "Forty"
    };
}
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

    public string GetScore() => $"Current score: {GetScoreByContext()}, enjoy your game!";

    private string GetScoreByContext()
    {
        if (IsTie)
        {
            return GetTieScore();
        }

        if (IsEndGame)
        {
            return GetEndGameScore();
        }

        return GetRegularScore();
    }

    private bool IsTie => _score.Player1 == _score.Player2;
    private bool IsEndGame => _score.Player1 >= 4 || _score.Player2 >= 4;
    
    private string GetTieScore() => _score.Player1 switch
    {
        0 => "Love-All",
        1 => "Fifteen-All",
        2 => "Thirty-All",
        _ => "Deuce"
    };

    private string GetEndGameScore() => (_score.Player1 - _score.Player2) switch
    {
        1 => AdvantageFor(player1Name),
        -1 => AdvantageFor(player2Name),
        >= 2 => WinFor(player1Name),
        _ => WinFor(player2Name)
    };
    
    private static string AdvantageFor(string player) => $"Advantage {player}";
    private static string WinFor(string player) => $"Win for {player}";
    
    private static string GetScoreLabel(int score) => score switch 
    {
        0 => "Love",
        1 => "Fifteen",
        2 => "Thirty",
        _ => "Forty"
    };
    
    private string GetRegularScore() => $"{GetScoreLabel(_score.Player1)}-{GetScoreLabel(_score.Player2)}";
}
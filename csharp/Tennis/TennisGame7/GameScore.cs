namespace Tennis;

public class GameScore
{
    private int _player1;
    private int _player2;

    public void Player1Won()
    {
        _player1++;
    }
    
    public void Player2Won()
    {
        _player2++;
    }
    
    public string GetScoreByContext(string player1Name, string player2Name)
    {
        if (IsTie)
        {
            return GetTieScore();
        }

        if (IsEndGame)
        {
            return GetEndGameScore(player1Name, player2Name);
        }

        return GetRegularScore();
    }

    private bool IsTie => _player1 == _player2;
    private bool IsEndGame => _player1 >= 4 || _player2 >= 4;
    private string GetTieScore() => _player1 switch
    {
        0 => "Love-All",
        1 => "Fifteen-All",
        2 => "Thirty-All",
        _ => "Deuce"
    };

    private string GetEndGameScore(string player1Name, string player2Name) => (_player1 - _player2) switch
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
    
    private string GetRegularScore() => $"{GetScoreLabel(_player1)}-{GetScoreLabel(_player2)}";
}
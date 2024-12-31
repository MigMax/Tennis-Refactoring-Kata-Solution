namespace Tennis.TennisGame3;

public class TennisGame3(string player1Name, string player2Name) : ITennisGame
{
    private int _player2Score;
    private int _player1Score;

    public string GetScore()
    {
        if (_player1Score < 4 && _player2Score < 4 && _player1Score + _player2Score < 6)
        {
            string[] p = ["Love", "Fifteen", "Thirty", "Forty"];
            
            var s1 = p[_player1Score];
            
            return _player1Score == _player2Score ? s1 + "-All" : s1 + "-" + p[_player2Score];
        }

        if (_player1Score == _player2Score)
        {
            return "Deuce";
        }

        var s2 = _player1Score > _player2Score ? player1Name : player2Name;
        
        return (_player1Score - _player2Score) * (_player1Score - _player2Score) == 1 ? "Advantage " + s2 : "Win for " + s2;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
        {
            _player1Score += 1;
        }
        else
        {
            _player2Score += 1;
        }
    }

}
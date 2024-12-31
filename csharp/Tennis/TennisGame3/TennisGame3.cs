namespace Tennis.TennisGame3;

public class TennisGame3(string player1Name, string player2Name) : ITennisGame
{
    private int _player2Score;
    private int _player1Score;

    public string GetScore()
    {
        string s;
        
        if (_player1Score < 4 && _player2Score < 4 && _player1Score + _player2Score < 6)
        {
            string[] p = ["Love", "Fifteen", "Thirty", "Forty"];
            
            s = p[_player1Score];
            
            return _player1Score == _player2Score ? s + "-All" : s + "-" + p[_player2Score];
        }

        if (_player1Score == _player2Score)
        {
            return "Deuce";
        }

        s = _player1Score > _player2Score ? player1Name : player2Name;
        
        return (_player1Score - _player2Score) * (_player1Score - _player2Score) == 1 ? "Advantage " + s : "Win for " + s;
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
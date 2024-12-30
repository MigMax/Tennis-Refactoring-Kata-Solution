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

    public string GetScore()
    {
        string result = "Current score: ";

        if (_player1Score == _player2Score)
        {
            // tie score
            switch (_player1Score)
            {
                case 0:
                    result += "Love-All";
                    break;
                case 1:
                    result += "Fifteen-All";
                    break;
                case 2:
                    result += "Thirty-All";
                    break;
                default:
                    result += "Deuce";
                    break;
            }
        }
        else if (_player1Score >= 4 || _player2Score >= 4)
        {
            // end-game score
            switch (_player1Score - _player2Score)
            {
                case 1:
                    result += $"Advantage {player1Name}";
                    break;
                case -1:
                    result += $"Advantage {player2Name}";
                    break;
                case >= 2:
                    result += $"Win for {player1Name}";
                    break;
                default:
                    result += $"Win for {player2Name}";
                    break;
            }
        }
        else
        {
            // regular score
            result += _player1Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            result += "-";

            result += _player2Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };
        }

        return result + ", enjoy your game!";
    }
}
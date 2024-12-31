namespace Tennis.TennisGame3;

public class TennisGame3(string player1Name, string player2Name) : ITennisGame
{
    private int p2;
    private int p1;

    public string GetScore()
    {
        string s;
        
        if (p1 < 4 && p2 < 4 && p1 + p2 < 6)
        {
            string[] p = ["Love", "Fifteen", "Thirty", "Forty"];
            
            s = p[p1];
            
            return p1 == p2 ? s + "-All" : s + "-" + p[p2];
        }

        if (p1 == p2)
        {
            return "Deuce";
        }

        s = p1 > p2 ? player1Name : player2Name;
        
        return (p1 - p2) * (p1 - p2) == 1 ? "Advantage " + s : "Win for " + s;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
        {
            p1 += 1;
        }
        else
        {
            p2 += 1;
        }
    }

}
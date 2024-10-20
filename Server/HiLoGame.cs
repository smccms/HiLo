/// <summary>
/// Class <c>HiLoGame</c> - encapsulates the logic of the HiLoGame 
/// </summary>
public class HiLoGame
{
    //min and max can be in a appsettings
    private const int MAX = 20;
    private const int MIN = 1;
    ///<value name="mysteryNumber">the mysteryNumber</value>
    private int mysteryNumber;

    ///<value name="players">List of current players</value>
    private List<HiLoPlayer> players = new List<HiLoPlayer>();

    public HiLoGame()
    {
        mysteryNumber = new Random().Next(MIN, MAX);
    }

    public string AddPlayer(string playerId)
    {
        players.Add(new HiLoPlayer(playerId));
        return $"Welcome to Hi-Lo player {playerId}! \r\nTry to guess the mysterious number that is between {MIN} and {MAX}.\r\nInsert your guess or 'exit' to quit the game:";
    }

    public void RemovePlayer(string playerId)
    {
        var p = players.FirstOrDefault(player => player.id == playerId);
        if (p != null)
        {
            players.Remove(p);
        }
    }

    public void GenerateNewNumber()
    {
        mysteryNumber = new Random().Next(MIN, MAX);
    }

    public void SubmitPlayerGuess(string playerId, int guess)
    {
        var p = players.FirstOrDefault(player => player.id == playerId);
        if (p != null)
        {
            p.guess = guess;
            p.hint = GetHintMessage(guess);
            p.hasGuessed = mysteryNumber == guess;
            p.numberOfGuesses++;
        }
    }

    public bool IsWaitingForPlayers()
    {
        return players.Count(p => p.hint != null) != players.Count();
    }

    public bool HasGuessed()
    {
        return players.Any(p => p.hasGuessed);
    }

    public string GetHasGuessedMessage()
    {
        var msg = "Game terminated.\r\n";
        players.ForEach(p =>
        {
            if (p.hasGuessed)
            {
                string info = $"Player {p.id} guessed the number in {p.numberOfGuesses} tries.\r\n";
                msg += info;
            }
        });
        msg += "New number generated. Insert new guess or exit to leave:";
        return msg;
    }

    public string GetPlayersScores()
    {
        var msg = "Hints:\r\n";
        players.ForEach(p =>
        {
            string info = $"Player {p.id} : {p.hint}.\r\n";
            msg += info;
            p.hint = null;
        });
        msg += "\r\nInsert your guess:";
        return msg;
    }

    public string GetWaitingMessage()
    {
        return "Waiting for other players...";
    }

    private string GetHintMessage(int guess)
    {
        if (mysteryNumber == guess)
        {
            return "You guess the number";
        }
        if (guess < mysteryNumber)
        {
            return "LO";
        }
        else
        {
            return "HI";
        }
    }
}

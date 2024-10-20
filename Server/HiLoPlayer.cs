/// <summary>
/// Class <c>HiLoPlayer</c> - defines the information of the HiLo player
/// </summary>

public class HiLoPlayer{

    ///<value name="id">Unique identifies the player</value>
    public string id;

    ///<value name="guess">Current guess of the user</value>
    public int? guess;

    ///<value name="hint">Current hint on the guess</value>
    public string? hint;

    ///<value name="hasGuessed"></value>
    public bool hasGuessed;

    ///<value name="hasGuessed"></value>
    public int numberOfGuesses;

    public HiLoPlayer(string guid){
        id = guid;
    }
}

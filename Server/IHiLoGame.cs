public interface IHiLoGame
{
    string AddPlayer(string connectionId);
    void RemovePlayer(string connectionId);
    void SubmitPlayerGuess(string connectionId, int guess);
    bool IsWaitingForPlayers();
    bool HasGuessed();
    void GenerateNewNumber();
    string GetWaitingMessage();
    string GetHasGuessedMessage();
    string GetPlayersScores();
}
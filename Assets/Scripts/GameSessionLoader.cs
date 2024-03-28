using UnityEngine;

public class GameSessionLoader : MonoBehaviour
{
    // state
    private GameConfig _gameConfig;
    private GameSession _gameSession;

    /**
     * Before first frame.
     */
    void Start()
    {
        this._gameSession = GameSession.Instance;
        this._gameConfig = GameConfig.Instance;
        // StartGameSession();
    }

    /**
     * Starts a game session from scratch (based only on the game mode options). In the future,
     * this method can be used to start a game session from a saved game file.
     */
    public void StartGameSession2(int live, float speed, int level)
    {
        var gameModeConfig = this._gameConfig.GetGameModeConfig();

        this._gameSession.PlayerLives = live;
        this._gameSession.GameSpeed = speed;
        this._gameSession.GameLevel = level;
        this._gameSession.PlayerScore = (int)gameModeConfig["playerScore"];
    }
}

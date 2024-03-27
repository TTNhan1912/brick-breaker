using UnityEngine;

public class LevelController : MonoBehaviour
{
    private readonly string GAME_OVER_SCENE_NAME = "Scenes/GameOver";
    private readonly int NUMBER_OF_GAME_LEVELS = 40;

    public LoadDataLevel loadDataLevel;
    public Ball ball;

    // UI elements
    [SerializeField] int blocksCounter;

    // state
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();

    }

    public void IncrementBlocksCounter()
    {
        blocksCounter++;
    }

    public void DecrementBlocksCounter()
    {
        loadDataLevel.blockLevel--;
        if (loadDataLevel.blockLevel <= 0)
        {
            var gameSession = GameSession.Instance;

            // check for game over
            if (gameSession.GameLevel >= NUMBER_OF_GAME_LEVELS)
            {
                _sceneLoader.LoadSceneByName(GAME_OVER_SCENE_NAME);
            }

            // int level = PlayerPrefs.GetInt("level");
            // level++;

            loadDataLevel.levelScene++;
            PlayerPrefs.SetInt("Level-Scene", loadDataLevel.levelScene);
            loadDataLevel.CheckData();
            ball.FixBallOnTopOfPaddle(new Vector2(8.7f, 0.6f), new Vector2(-0.1f, 0.9f));
            ball.InitialBallSpeed = new Vector2(0, 0);
            Debug.Log(ball.InitialBallSpeed);
        }


    }



}

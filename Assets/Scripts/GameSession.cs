using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // config
    [SerializeField] public TextMeshProUGUI playerScoreText;
    [SerializeField] public TextMeshProUGUI gameLevelText;
    [SerializeField] public TextMeshProUGUI playerLivesText;

    [SerializeField] private Button back;
    [SerializeField] private LoadDataLevel loadDataLevel;
    public Paddle paddle;
    private float timeScale;
    private float timeSlowSpeed;

    public float speed;
    private int stackSlow;

    private bool isLowSpeed;
    private bool isLowSpeed5s;
    private bool isEndScale;
    // state
    private static GameSession _instance;
    public static GameSession Instance => _instance;

    [field: SerializeField]
    public int GameLevel { get; set; }
    public int PlayerScore { get; set; }
    public int PlayerLives { get; set; }
    public int PointsPerBlock { get; set; }
    public float GameSpeed { get; set; }

    /**
     * Singleton implementation.
     */
    private void Awake()
    {
        // this is not the first instance so destroy it!
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // first instance should be kept and do NOT destroy it on load
        _instance = this;
        // DontDestroyOnLoad(this.gameObject);

        isLowSpeed = true;
        isLowSpeed5s = true;
        isEndScale = true;

    }

    /**
     * Before first frame.
     */
    void Start()
    {
        playerScoreText.text = this.PlayerScore.ToString();
        gameLevelText.text = this.GameLevel.ToString();
        //  playerLivesText.text = this.PlayerLives.ToString();
        loadDataLevel.LoadDataLiveAndSpeed();
        back.onClick.AddListener(BackSceneStart);
        loadDataLevel.CheckData();
    }

    /**
     * Update per-frame.
     */
    void Update()
    {
        Time.timeScale = this.GameSpeed;

        if (!isEndScale)
        {
            if (Time.time >= timeScale)
            {
                EndScale();
                isEndScale = true;
            }
        }

        if (!isLowSpeed5s)
        {
            if (Time.time >= timeSlowSpeed - 5)
            {
                isLowSpeed = true;
            }
        }
        if (Time.time >= timeSlowSpeed)
        {
            this.GameSpeed = 0.7f;
        }

        // UI updates
        playerScoreText.text = this.PlayerScore.ToString();
        gameLevelText.text = this.GameLevel.ToString();
        playerLivesText.text = this.PlayerLives.ToString();
    }

    /**
     * Updates player score with given points and also updates the UI score. The total points that are
     * calculated is based on the basis value (this.PointsPerBlock).
     */
    public void AddToPlayerScore(int blockMaxHits)
    {
        this.PlayerScore += blockMaxHits * 100;
        playerScoreText.text = this.PlayerScore.ToString();
    }


    public void ScalePaddle()
    {
        paddle.transform.localScale = new Vector3(2, 1, 1);
        timeScale = Time.time + 10;
        paddle.maxRelativePosX = 14;
        paddle.minRelativePosX = 2;
        isEndScale = false;
    }

    private void EndScale()
    {
        paddle.transform.localScale = new Vector3(1, 1, 1);
        paddle.maxRelativePosX = 15;
        paddle.minRelativePosX = 1;
    }

    public void SlowSpeed()
    {
        Speed();
    }

    private void Speed()
    {
        if (!isLowSpeed) return;
        float slowSpeed;
        stackSlow++;
        timeSlowSpeed = Time.time + 10;
        // stackSlow = stackSlow > 5 ? 5 : stackSlow;
        if (stackSlow >= 5)
        {
            stackSlow = 5;
        }
        if (stackSlow > 5) return;
        speed = this.GameSpeed;
        slowSpeed = speed * (stackSlow / 10f);
        this.GameSpeed -= slowSpeed;
        isLowSpeed = false;
        isLowSpeed5s = false;
    }

    public void Cancel()
    {
        EndScale();
        this.GameSpeed = 0.7f;
    }

    public void BackSceneStart()
    {
        SceneManager.LoadScene(0);
    }

}

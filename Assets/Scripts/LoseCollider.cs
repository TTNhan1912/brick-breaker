using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private readonly string GAME_OVER_SCENE_NAME = "Scenes/GameOver";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ball triggered an event with the lose collider 
        if (other.name.ToLower() == "ball")
        {
            // when ball destroy
            var gameSession = GameSession.Instance;

            // checks for game over
            if (gameSession.PlayerLives <= 0)
            {
                SceneManager.LoadScene(GAME_OVER_SCENE_NAME);
                return;
            }

            // deduces a game life from the player
            gameSession.PlayerLives--;
            FixBallOnPaddleAfterLoss();
            Debug.Log("LoseCollider - Trigger Ball ");
        }

        //  if (other.gameObject.CompareTag("ItemDrop"))
        //  {

        //  }

    }

    private void FixBallOnPaddleAfterLoss()
    {
        var ball = FindObjectOfType<Ball>();
        ball.HasBallBeenShot = false;
    }
}

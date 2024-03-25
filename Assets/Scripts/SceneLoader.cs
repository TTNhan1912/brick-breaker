using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // loads next scene based on the scene ordering defined on Unity > build settings
    public int currentSceneIndex;


    public void LoadNextScene()
    {


        Debug.Log(" 1 " + (PlayerPrefs.GetInt("level")));
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.GetInt("level") < 40)
        {
            PlayerPrefs.SetInt("level", currentSceneIndex - 1);
            PlayerPrefs.Save();
        }
        else
        {
            SceneManager.LoadScene(0);
            return;
        }


        Debug.Log(" 2 " + (PlayerPrefs.GetInt("level")));

        SceneManager.LoadScene(currentSceneIndex + 1);



        //  levelController.AddStarAndUnlockScene();

        //        saveDataManager.SaveData();
    }

    // loads scene by its name
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName: sceneName);
    }

    // always the 0 indexed scene
    public void LoadStartScene()
    {
        // FindObjectOfType<GameState>().ResetState();
        int level = PlayerPrefs.GetInt("level");

        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    /**
     * Hides the mouse cursor.
     */
    public void Start()
    {
        Cursor.visible = false;

        //PlayerPrefs.SetInt("level", 1);

        Debug.Log(" Level : " + PlayerPrefs.GetInt("level"));

    }



}

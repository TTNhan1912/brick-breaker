using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // loads next scene based on the scene ordering defined on Unity > build settings
    public int currentSceneIndex;

    public LoadDataLevel loadDataLevel;

    public void LoadNextScene()
    {
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
        int level = PlayerPrefs.GetInt("Level-Scene");

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

    }



}

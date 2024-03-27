using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : VerticalMenuSelector
{
    // status
    private readonly string MENU_OPTION_START = "MenuOptionStart";
    private readonly string MENU_OPTION_INSTRUCTIONS = "MenuOptionInstructions";
    private readonly string MENU_OPTION_OPTIONS = "MenuOptionOptions";
    private readonly string LEVEL_OPTIONS = "LevelOptions";

    /**
     * Before first frame update. 
     */
    void Start()
    {
        transform.position = GetMenuSelectorPosition();

        Debug.Log("Level Current : " + PlayerPrefs.GetInt("Level-Scene"));

    }

    /**
     * Update per frame.
     */
    void Update()
    {
        // invokes base class up/down arrows handling
        this.HandleUpDownArrowPresses();

        // enter case handling
        if (Input.GetKeyDown(KeyCode.Return)) HandleReturn();
    }

    /**
     * Handles ENTER pressing that allows the user to choose an option.
     */
    private void HandleReturn()
    {
        var currentMenu = this.GetCurrentMenu();

        if (currentMenu.name == MENU_OPTION_START)
            SceneManager.LoadScene(3);

        else if (currentMenu.name == MENU_OPTION_INSTRUCTIONS)
            this.sceneLoader.LoadSceneByName("InstructionsMenu");

        else if (currentMenu.name == MENU_OPTION_OPTIONS)
            this.sceneLoader.LoadSceneByName("LevelOptions");

        else
            this.sceneLoader.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuSelector : VerticalMenuSelector
{
    private readonly string MENU_OPTION_GO_AGAIN = "MenuOptionGoAgain";

    [SerializeField] private LoadDataLevel loadDataLevel;

    /**
     *
     * Before first frame update. 
     */
    void Start()
    {
        transform.position = GetMenuSelectorPosition();
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
        GameObject currentMenu = this.GetCurrentMenu();

        if (currentMenu.name == this.MENU_OPTION_GO_AGAIN)
        {
            SceneManager.LoadScene(3);
        }
        else
            SceneManager.LoadScene(0);
    }
}

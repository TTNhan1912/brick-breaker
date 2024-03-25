using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPrefab : MonoBehaviour
{
    public TMP_Text textLevel;

    public Button level;

    // Start is called before the first frame update
    void Start()
    {
        //level.onClick.AddListener(LevelInput);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelInput()
    {
        SceneManager.LoadScene(3);
    }


}

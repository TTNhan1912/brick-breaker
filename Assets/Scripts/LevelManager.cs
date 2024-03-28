using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public List<LevelPrefab> listLevel;

    [SerializeField] private int _maxLevel;
    [SerializeField] private Transform content;
    [SerializeField] private TMP_Text text_Star;

    private int valueToAdd = 2;
    private int count = 5;
    private bool isIncreasing = true;
    public int levelCurrent = 0;

    public ScrollRect myScrollRect;

    public LevelPrefab levelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _maxLevel = 40;
        CreateLevel();
        AddLine();
        ScrollLevel();

        LoadDataStarAndLock();
        LoadTextStar();

    }


    public void CreateLevel()
    {
        for (int i = 0; i < _maxLevel; i++)
        {
            LevelPrefab level = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
            listLevel.Add(level);
            level.transform.SetParent(content);
            level.transform.localScale = Vector3.one;
            if (i == 0)
            {
                level.transform.GetChild(4).GetComponent<Image>().gameObject.SetActive(true);

                level.GetComponent<Button>().onClick.AddListener(() =>
                {
                    PlayerPrefs.SetInt("LevelData", 1);
                    SceneManager.LoadScene(3);
                });
            }
            else
            {
                level.transform.GetChild(3).GetComponent<TMP_Text>().text += valueToAdd;
                int levelNumber = valueToAdd;

                level.GetComponent<Button>().onClick.AddListener(() =>
                {


                    Debug.LogError("Click button Index  " + levelNumber);
                    var maxLevelUnlock = PlayerPrefs.GetInt("LevelCurrent");
                    var indexLevelClicked = levelNumber;
                    if (indexLevelClicked > maxLevelUnlock)
                    {
                        return;
                    }
                    PlayerPrefs.SetInt("LevelData", levelNumber);
                    SceneManager.LoadScene(3);

                });

                if (isIncreasing)
                {
                    valueToAdd++;
                    if (valueToAdd == count)
                    {
                        isIncreasing = false;
                        valueToAdd += 3;
                    }
                }
                else
                {
                    valueToAdd--;
                    if (valueToAdd == count - 1)
                    {
                        isIncreasing = true;
                        valueToAdd += 5;
                        count += 8;
                    }
                }
            }
        }
    }

    public void AddLine()
    {
        for (int i = 0; i < listLevel.Count; i++)
        {
            if (i % 8 == 7)
            {
                listLevel[36].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(false);
                listLevel[0].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false);
            }
            else if (i % 8 == 3)
            {
                listLevel[i].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(true);
            }
            else if (i % 8 == 4)
            {
                listLevel[i].transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);
                listLevel[i].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(true);
            }
            else
            {
                listLevel[i].transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);
            }
        }
    }

    public void LoadDataStarAndLock()
    {
        bool isLevel = true;
        int countThuHai = 4;

        for (int i = 0; i < PlayerPrefs.GetInt("LevelCurrent") - 1; i++)
        {
            listLevel[levelCurrent].transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(true);

            if (isLevel)
            {
                levelCurrent++;

                if (levelCurrent == countThuHai)
                {
                    isLevel = false;
                    levelCurrent += 3;
                    listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false);
                    continue;

                }
                listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false);

            }
            else
            {
                levelCurrent--;
                if (levelCurrent == countThuHai - 1)
                {
                    isLevel = true;
                    levelCurrent += 5;
                    countThuHai += 8;
                    listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false);
                    continue;
                }
                listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false);
            }
        }
    }

    private void LoadTextStar()
    {
        if ((PlayerPrefs.GetInt("LevelCurrent") - 1 > 0))
        {
            text_Star.text += ((PlayerPrefs.GetInt("LevelCurrent") - 1) * 3).ToString();
        }
    }

    private void ScrollLevel()
    {
        int level = PlayerPrefs.GetInt("LevelCurrent");
        float position = (level * 100) / _maxLevel;
        myScrollRect.verticalNormalizedPosition = (position / 100) - 0.1f;

    }


    public void BackHome()
    {
        SceneManager.LoadScene(0);
    }

}

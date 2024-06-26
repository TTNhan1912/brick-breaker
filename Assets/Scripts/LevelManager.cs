﻿using System.Collections.Generic;
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
    public int star;

    public ScrollRect myScrollRect;
    public Scrollbar newScrollBar;

    public LevelPrefab levelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _maxLevel = 40;
        CreateLevel();
        AddLine();
        ScrollLevel();

        Debug.Log(PlayerPrefs.GetInt("level"));
        LoadDataStarAndLock();
        LoadTextStar();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
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
                    SceneManager.LoadScene(3);
                });
            }
            else
            {
                level.transform.GetChild(3).GetComponent<TMP_Text>().text += valueToAdd; // 2 - 3 - 4 - 8 
                int levelNumber = valueToAdd;  // 2 - 3 - 4 - 8 

                level.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Debug.Log("Level : " + levelNumber);
                    if (PlayerPrefs.GetInt("level") >= levelNumber)
                    {
                        SceneManager.LoadScene(levelNumber + 2);

                    }
                });

                if (isIncreasing)
                {
                    valueToAdd++; // 3 - 4 - 5 
                    if (valueToAdd == count)  // 5 == 5
                    {
                        isIncreasing = false;
                        valueToAdd += 3; // 5-> 8
                    }
                }
                else
                {
                    valueToAdd--; // text 7 
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
            if (i % 8 == 7) // Nếu là mỗi phần tử thứ 8, bắt đầu từ 7, 15, ...
            {
                listLevel[36].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(false);
                listLevel[0].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false);
            }
            else if (i % 8 == 3) // Nếu là mỗi phần tử thứ 4, bắt đầu từ 3, 11, ...
            {
                // Thực hiện "line 2"
                listLevel[i].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(true);
            }
            else if (i % 8 == 4) // Nếu là mỗi phần tử thứ 5, bắt đầu từ 4, 12, ...
            {
                // Thực hiện "line 3"
                listLevel[i].transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);
                listLevel[i].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(true);
            }
            else // Các trường hợp còn lại
            {
                // Thực hiện "line 1"
                listLevel[i].transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);
            }
        }
    }

    public void LoadDataStarAndLock()
    {
        bool isLevel = true;
        int countThuHai = 4;

        for (int i = 0; i < PlayerPrefs.GetInt("level") - 1; i++)
        {
            listLevel[levelCurrent].transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(true); // sao

            if (isLevel)
            {
                levelCurrent++; // 3 - 4 - 5  

                if (levelCurrent == countThuHai)  // 5 == 5
                {
                    isLevel = false;
                    levelCurrent += 3; // 5-> 8
                    listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false); // end lock
                    continue;

                }
                listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false); // end lock

            }
            else
            {
                levelCurrent--; // text 7 
                if (levelCurrent == countThuHai - 1)
                {
                    isLevel = true;
                    levelCurrent += 5;
                    countThuHai += 8;
                    listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false); // end lock
                    continue;
                }
                listLevel[levelCurrent].transform.GetChild(5).GetComponent<Image>().gameObject.SetActive(false); // end lock
            }
        }
    }

    private void LoadTextStar()
    {
        text_Star.text += ((PlayerPrefs.GetInt("level") - 1) * 3).ToString();
    }

    private void ScrollLevel()
    {
        int level = PlayerPrefs.GetInt("level");
        float position = 0f;

        if (level > 36)
        {
            myScrollRect.verticalNormalizedPosition = 1f;
        }
        else
        {
            if (level >= 33)
            {
                position = 0.9f;
            }
            else if (level >= 29)
            {
                position = 0.8f;
            }
            else if (level >= 25)
            {
                position = 0.7f;
            }
            else if (level >= 21)
            {
                position = 0.6f;
            }
            else if (level >= 17)
            {
                position = 0.5f;
            }
            else if (level >= 13)
            {
                position = 0.4f;
            }
            else if (level >= 9)
            {
                position = 0.2f;
            }
            else if (level >= 5)
            {
                position = 0.1f;
            }

            myScrollRect.verticalNormalizedPosition = position;

        }
    }


    private void ResetLevel()
    {
        PlayerPrefs.SetInt("level", 1);
    }

    public void BackHome()
    {
        SceneManager.LoadScene(0);
    }

}

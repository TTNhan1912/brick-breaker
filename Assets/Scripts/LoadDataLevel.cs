using System.Globalization;
using System.Linq;
using UnityEngine;


public class LoadDataLevel : MonoBehaviour
{
    public GameSessionLoader gameSessionLoader;

    public GameSession gameSession;

    public int blockLevel;

    public int levelScene;

    void Start()
    {
        CheckLevel();
    }

    public void CheckLevel()
    {
        levelScene = PlayerPrefs.GetInt("LevelData");
        Debug.Log("Level Current : " + PlayerPrefs.GetInt("LevelCurrent"));
        CheckData();
    }

    public void CheckData()
    {
        LoadBlockLevel();
        LoadDataLiveAndSpeed();
    }


    public void LoadBlockLevel()
    {
        TextAsset dataLevel1 = Resources.Load<TextAsset>("level" + levelScene);

        string[] data = dataLevel1.text.Split(new char[] { '\n' });

        for (int i = 1; i <= 6; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            for (int j = 0; j <= 15; j++)
            {
                int blockType = int.Parse(row[j]);
                Vector2 position = new Vector2(j + 0.5f, i + 4.5f);
                switch (blockType)
                {
                    case -1:
                        GameObject newBlockBlack = ObjectPool.Instance.GetBlockBlack();
                        if (newBlockBlack != null)
                        {
                            newBlockBlack.transform.position = position;
                            newBlockBlack.SetActive(true);
                        }
                        break;
                    case 1:
                        GameObject newBlock1 = ObjectPool.Instance.GetBlock1();
                        if (newBlock1 != null)
                        {
                            newBlock1.transform.position = position;
                            newBlock1.GetComponent<SpriteRenderer>().sprite = newBlock1.gameObject.GetComponent<Block>().damageSprites[0];
                            newBlock1.SetActive(true);
                            blockLevel++;
                        }
                        break;
                    case 2:
                        GameObject newBlock2 = ObjectPool.Instance.GetBlock2();
                        if (newBlock2 != null)
                        {
                            newBlock2.transform.position = position;
                            newBlock2.GetComponent<SpriteRenderer>().sprite = newBlock2.gameObject.GetComponent<Block>().damageSprites[0];

                            newBlock2.SetActive(true);
                            blockLevel++;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (!gameObject.activeInHierarchy)
            {
                Destroy(gameObject);
            }

        }


    }

    public void LoadDataLiveAndSpeed()
    {
        TextAsset dataLevel1 = Resources.Load<TextAsset>("level" + levelScene);
        string[] data = dataLevel1.text.Split(new char[] { '\n' });

        int live = int.Parse(data[0].First().ToString());
        CultureInfo culture = CultureInfo.InvariantCulture;
        string[] data2 = data[0].Split(',');

        float speed = float.Parse(data2[1], culture);

        gameSessionLoader.StartGameSession2(live, speed, levelScene);

    }



}

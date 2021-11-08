using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//code Mathis
public class LevelChoice : MonoBehaviour
{
    public List<GameObject> Levels = new List<GameObject>();
    Levels data = new Levels();

    // Start is called before the first frame update
    void Awake()
    {
        Save.CreateSaveFile();
        data = Save.LoadLevelsFromJson();
    }
    private void Start()
    {
        int i = 0;
        foreach(var level in Levels)
        {
            if (data.list[i].isFinished)
            {
                GameObject button = level.transform.GetChild(0).gameObject;
                button.GetComponent<Image>().color = Color.green;
                GameObject time = level.transform.GetChild(1).gameObject;
                time.transform.GetChild(0).gameObject.GetComponent<Text>().text = data.list[i].time.ToString() + "s";
                time.SetActive(true);
                i++;
            }
        }
    }

    public void LevelButton(int level)
    {
        string levelName = "Level" + level.ToString();
        SceneManager.LoadScene(levelName);
    }
}

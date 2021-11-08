using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code de Mathis
public static class Save
{
    public static Levels levels = new Levels();

    public static void SaveIntoJson()
    {
        string levels1 = JsonUtility.ToJson(levels);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Levels.json", levels1);
    }
    public static Levels LoadLevelsFromJson()
    {
        string json;
        json = System.IO.File.ReadAllText(Application.persistentDataPath + "/Levels.json");
        levels = JsonUtility.FromJson<Levels>(json);
        return levels;
    }
    public static void CreateSaveFile()
    {
        if (!System.IO.File.Exists(Application.persistentDataPath + "/Levels.json"))
        {
            Levels levels = new Levels();
            levels.list.Add(new Level());
            levels.list.Add(new Level());
            levels.list.Add(new Level());
            Save.levels = levels;
            string levels1 = JsonUtility.ToJson(levels);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Levels.json", levels1);
        }
    }
}

[System.Serializable]
public class Level
{
    public int id;
    public bool isFinished = false;
    public string time = "00:00:000";
}

public class Levels
{
    public List<Level> list = new List<Level>();
}
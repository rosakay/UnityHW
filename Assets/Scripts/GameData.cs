using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData
{
    public string name;
    public float hp;
    public float mp;
    public int lv;

    public GameData()
    {
        DataUpdate();
    }

    public void DataUpdate()
    {
        name = PlayerData.name;
        hp = PlayerData.hp;
        mp = PlayerData.mp;
        lv = PlayerData.lv;
    }

    public override string ToString()
    {
        return $"{name}：血量{hp} 法力{mp} 等級{lv}";
    }
}
public static class PlayerData
{
    public static string name = "歐咩嘎";
    public static float hp = 100.0f;
    public static float mp = 20.0f;
    public static int lv = 15;
}

using System;
using System.Collections.Generic;
using System.Linq;
using ChuongCustom;
using UnityEngine;

public class PlayerData : BaseData
{
    public int _coin, _gem, _exp;
    public int heart;
    public bool _removeAds;
    public int highScore;
    public int choosingMap;
    public List<MapRecord> mapUnlocks;
    public List<int> carUnlocks;
    public int currentCar;

    public float time;
    public string timeRegister;

    public bool isRate;

    public bool IsRemoveAds => _removeAds;

    public int Coin
    {
        get => _coin;
        set
        {
            _coin = value;
            GameAction.OnChangeCoin?.Invoke(value);
        }
    }
    
    public int Heart
    {
        get => heart;
        set
        {
            heart = value;
            GameAction.OnChangeHeart?.Invoke(value);
        }
    }

    public int Gem
    {
        get => _gem;
        set
        {
            _gem = value;
            GameAction.OnChangeGem?.Invoke(value);
        }
    }

    public int HighScore
    {
        get => highScore;
        set
        {
            highScore = value;
            GameAction.OnHighScoreChange?.Invoke(value);
        }
    }

    public int Exp
    {
        get => _exp;
        set
        {
            _exp = value;
            GameAction.OnChangeExp?.Invoke(value);
        }
    }

    public void Rated()
    {
        isRate = true;
    }

    public bool IsRate => isRate;

    public void ResetTime()
    {
        time = 0;
        Save();
    }

    public override void ValidateData()
    {
        if (mapUnlocks == null || mapUnlocks.Count == 0)
        {
            mapUnlocks = new List<MapRecord>();
            mapUnlocks.Add(new MapRecord()
            {
                mapID = 0,
                time = 0
            });
        }
    }

    public override void Init()
    {
        prefString = Constant.DataKey_PlayerData;
        if (PlayerPrefs.GetString(prefString).Equals(""))
        {
            ResetData();
        }

        base.Init();
    }


    public override void ResetData()
    {
        timeRegister = DateTime.Now.ToBinary().ToString();
        time = 3 * 24 * 60 * 60;
    
        _coin = 0;
        _gem = 100000;
        _exp = 0;

        carUnlocks = Enumerable.Repeat(0, 5).ToList();
        carUnlocks[0] = 1;
        currentCar = 0;
        mapUnlocks = new List<MapRecord>();
        mapUnlocks.Add(new MapRecord()
        {
            mapID = 0,
            time = 0
        });

        Save();
    }

    public bool IsUnlockMap(int mapID)
    {
        var findMap = mapUnlocks.Find(record => record.mapID == mapID);

        return (findMap != null);
    }

    public void UnlockMap(int mapID)
    {
        if (!IsUnlockMap(mapID))
        {
            mapUnlocks.Add(new MapRecord()
            {
                mapID = mapID,
                time = 0
            });
            mapUnlocks = mapUnlocks.OrderBy(i => i.mapID).ToList();
        }
        
        Save();
    }

    public MapRecord GetMapWithID(int mapID)
    {
        var findMap = mapUnlocks.Find(record => record.mapID == mapID);

        return findMap;
    }

    public void SetMaxTime(long playTime, int chapter)
    {
        if (GetMapWithID(chapter).time > playTime)
            return;

        GetMapWithID(chapter).time = playTime;
    }

    public void RemoveAds()
    {
        _removeAds = true;
    }
}

[Serializable]
public class MapRecord
{
    public int mapID;
    public long time;
}
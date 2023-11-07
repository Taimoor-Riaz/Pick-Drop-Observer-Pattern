using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject<T> : MonoBehaviour where T : Subject<T>
{
    public static T Instance;
    List<IGameStatus> _gameStatusList;
    protected virtual void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this as T;
        _gameStatusList = new List<IGameStatus>();
    }


    public void Add(IGameStatus gameStatus)
    {
        _gameStatusList.Add(gameStatus);
    }

    public void Remove(IGameStatus gameStatus)
    {
        _gameStatusList.Remove(gameStatus);
    }

    public void OnNotify(CurrentState current)
    {
        foreach (IGameStatus status in _gameStatusList)
        {
            status.Notify(current);
        }
    }

}

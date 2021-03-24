using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Player Player { get; private set; }

    
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
        Application.targetFrameRate = 144;

        Player = GameObject.Find("Player").GetComponent<Player>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStatus
    {
        None = -1,
        Prologue = 0,
        Battle = 1,
        Dead = 2,
    }

    //public Dictionary<GameStatus, string> GameProgress = new Dictionary<GameStatus, string>();

    public GameStatus currentStatus = GameStatus.None;
    public bool nextStep = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (nextStep)
        {
            nextStep = false;
            Invoke(currentStatus.ToString(), 0);
        }
    }

    void Prologue()
    {
        AssetManager.MakePrefab("CutSceneManager");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab = null;

    //Library
    GameObject player;
    UI_Controller uic;
    ArenaHelper ah;
    LevelController lc;
    Vector2 playerStartLocation = Vector2.zero;

    //state
    bool isInGame = false;

    public Action OnGameStart;
    
    void Start()
    {
        uic = GetComponent<UI_Controller>();
        uic.SetCurrentContext(UI_Controller.UI_Context.StartMenu);
        ah = GetComponent<ArenaHelper>();
        lc = GetComponent<LevelController>();
        
    }

    #region Button Handlers

    public void HandleStartGame()
    {
        isInGame = true;
        player = Instantiate(playerPrefab, playerStartLocation, Quaternion.identity);
        uic.SetCurrentContext(UI_Controller.UI_Context.InGame);
        OnGameStart?.Invoke();

    }

    #endregion


    #region Public Methods

    static public GameController GetGameController()
    {
         return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public ArenaHelper GetArenaHelper()
    {
        return ah;
    }

    public UI_Controller GetUI_Controller()
    {
        return uic;
    }
    #endregion

}

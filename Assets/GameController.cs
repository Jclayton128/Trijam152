using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab = null;

    //Library
    GameObject player;
    UI_Controller uic;
    Vector2 playerStartLocation = Vector2.zero;

    //state
    bool isInGame = false;
    
    void Start()
    {
        uic = GetComponent<UI_Controller>();
        uic.SetCurrentContext(UI_Controller.UI_Context.StartMenu);
    }

    #region Button Handlers

    public void HandleStartGame()
    {
        isInGame = true;
        player = Instantiate(playerPrefab, playerStartLocation, Quaternion.identity);
        uic.SetCurrentContext(UI_Controller.UI_Context.InGame);

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

    #endregion

}

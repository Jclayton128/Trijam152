using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab = null;
    ArenaHelper ah;

    List<GameObject> enemyOnLevel = new List<GameObject>();

    //param

    //state
    [SerializeField] int currentLevel = 0;

    void Start()
    {
        GameController.GetGameController().OnGameStart += ReactToGameStart;
        ah = GameController.GetGameController().GetArenaHelper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ReactToGameStart()
    {
        currentLevel = 1;
        SpawnOneEnemy();
    }

    private void SpawnOneEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, ah.GetRandomReachablePoint(), Quaternion.identity);
        enemyOnLevel.Add(newEnemy);
    }

    private void AdvanceOneLevel()
    {
        currentLevel++;
        Debug.Log($"now on level {currentLevel}");
    }
}

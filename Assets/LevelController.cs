using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab = null;
    ArenaHelper ah;
    GameController gc;

    List<GameObject> enemyOnLevel = new List<GameObject>();

    //param

    //state
    float timeOnCurrentRun = 0;
    int currentLevel = 0;

    void Start()
    {
        gc = GameController.GetGameController();
        gc.OnGameStart += ReactToGameStart;
        ah = GameController.GetGameController().GetArenaHelper();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.isInGame == false) { return; }
        timeOnCurrentRun += Time.deltaTime;
        //Debug.Log($"{Time.time} vs {currentLevel * 10f}, {enemyOnLevel.Count} vs. {currentLevel}");
        if (timeOnCurrentRun > currentLevel * 10f )
        {
            currentLevel++;
            if (enemyOnLevel.Count < currentLevel)
            {
                SpawnOneEnemy();
            }

        }
    }
    private void ReactToGameStart()
    {
        timeOnCurrentRun = 0;
        currentLevel = 1;
        SpawnOneEnemy();
    }

    private void SpawnOneEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, ah.GetRandomReachablePoint(), Quaternion.identity);
        enemyOnLevel.Add(newEnemy);
    }


    public void DestroyAllEnemies()
    {
        for(int i = enemyOnLevel.Count -1; i == 0; i--)
        {
            Destroy(enemyOnLevel[i].gameObject);
        }
        enemyOnLevel.Clear();
    }

    public float GetRunTime()
    {
        return timeOnCurrentRun;
    }
}

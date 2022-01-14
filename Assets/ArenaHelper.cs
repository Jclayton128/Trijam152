using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaHelper : MonoBehaviour
{
    //param
    [SerializeField] int arenaLength;
    [SerializeField] int arenaHeight;
    int layerMask_obstacle = 1 << 10;
    

    public Vector2 GetRandomReachablePoint()
    {
        int attempt = 0;
        bool isUnreachable = false;
        Vector2 testPoint = Vector2.zero;
        do
        {
            int rand_x = UnityEngine.Random.Range(-arenaLength, arenaLength + 1);
            int rand_y = UnityEngine.Random.Range(-arenaHeight, arenaHeight + 1);
            testPoint.x = rand_x;
            testPoint.y = rand_y;
            isUnreachable = CheckIfReachable(testPoint);

            attempt++;
            if (attempt > 10)
            {
                break;
            }
        }
        while (isUnreachable);

        return testPoint;
    }

    private bool CheckIfReachable(Vector2 testPoint)
    {     
        Collider2D hit = Physics2D.OverlapCircle(testPoint, 0.1f, layerMask_obstacle);

        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    ArenaHelper ah;
    EnemyMovement em;

    //param
    public float detectionRange;
    private float closeEnough = 1.0f;

    //state
    Transform playerTransform;
    bool seesPlayer = false;
    bool metInitialDest = false;
    Vector2 destination = Vector2.zero;
    Vector2 dirToDest = Vector2.zero;
    float distToDest = 0;

    void Start()
    {
        ah = GameController.GetGameController().GetArenaHelper();
        em = GetComponent<EnemyMovement>();
        playerTransform = GameController.GetGameController().GetPlayer().transform;
        destination = ah.GetRandomReachablePoint();
    }

    // Update is called once per frame
    void Update()
    {

        destination = playerTransform.position;

        UpdateNavData();

        Debug.DrawLine(transform.position, destination, Color.green);

        
        ConvertDesiresToMovement();
    }

    private void UpdateNavData()
    {
        dirToDest = destination - (Vector2)transform.position;
        distToDest = dirToDest.magnitude;
    }

    private void ConvertDesiresToMovement()
    {
        em.SetInput(dirToDest.normalized);
    }
}

﻿using UnityEngine;

public class StraightAstroidSpawner: AstroidSpawner
{
    private float timeSample;

    public override void StartSpawn()
    {
        base.StartSpawn();
        timeSample = Time.deltaTime;

    }

    protected override bool Spawn()
    {
        if(!base.Spawn())return false;
        if (Time.time - timeSample > GetRandomDelayBetweenSecondsInRange())
        {
            var astroid =  GetReadyAstroid();
            astroid.Instance.transform.position = GetRandomPosInRange();
            astroid.Instance.SetActive(true);
            astroid.InitlialInitliaze( Vector3.left, GetRandomSpeedInRange()); //todo get random Direction

        }
        return true;
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.X))
            StartSpawn();
    }
}
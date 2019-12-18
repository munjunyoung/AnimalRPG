using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LevelManager_LV1 : LevelManager
{
    public override void EncounterBoss()
    {
        base.EncounterBoss();
    }

    public override void LoadBoss()
    {
        base.LoadBoss();
        boss.gameObject.SetActive(true);
    }

    public override void LoadEnemies()
    {
        base.LoadEnemies();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}


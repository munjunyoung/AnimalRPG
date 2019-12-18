using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonBehavior<LevelManager>
{
    public EnemyBehaviour boss;
    public List<EnemyBehaviour> enemies;

    public PlayerBehaviour player;

    public virtual void LoadEnemies()
    {

    }

    public virtual void LoadBoss()
    {

    }

    public virtual void EncounterBoss()
    {

    }

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }
}

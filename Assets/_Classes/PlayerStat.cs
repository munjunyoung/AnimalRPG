using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int Level;
    public int totalHp;
    public int totalMp;

    public int moveSpeed;

    public int AttackSpeed;
    public int AttackDamage;

    public int skillDamage;
    public float skillCoolTime;

    public PlayerStat()
    {
        totalHp = 100;
        totalMp = 100;
        moveSpeed = 5;
        AttackSpeed = 1;
        AttackDamage = 50;
        skillCoolTime = 2f;
        skillDamage = 200;
    }
}

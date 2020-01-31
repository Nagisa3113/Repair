using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected int damage;
    protected int hp;

    protected int repair;

    protected int hp_click;

    public abstract void OnFighting(Player player);


    public abstract void OnDefeated(Player player);



    public void OnRepair()
    {
        this.gameObject.SetActive(true);
    }


}

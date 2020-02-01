﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalObs : Obstacle
{
    
    public override void OnDefeated(Player player)
    {
        player.gold += 10;
    }

    public override void OnFighting(Player player)
    {
        player.hp -= damage;
    }


    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _particle = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        damage = 10;
        repair = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        hp_click--;
        if (hp_click <= 0)
        {
            StartCoroutine(ObsDestroy());
        }
    }




    IEnumerator ObsDestroy()
    {
        _particle.Play();
        yield return new WaitForSeconds(0.2f);
        _collider.enabled=false;

    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalObs : Obstacle
{
    Collider2D collider2D;

    ParticleSystem particleSystem;

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
        collider2D = GetComponent<Collider2D>();
        particleSystem = GetComponent<ParticleSystem>();
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
        particleSystem.Play();
        yield return new WaitForSeconds(0.2f);
        collider2D.enabled=false;

    }


}

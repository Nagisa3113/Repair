﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public ScriptablePlots scriptablePlots;

    Plot plot;

    public bool isDestroyed;
    public bool isRepaired;

    SpriteRenderer _sprite;
    Collider2D _collider;
    ParticleSystem _particle;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _particle = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.obstacleList.Add(this);
    }

    private void OnMouseEnter()
    {
        //UIManager.Instance.mousePointer.GetComponentInChildren<Text>().enabled = true;
    }

    private void OnMouseExit()
    {
        //UIManager.Instance.mousePointer.GetComponentInChildren<Text>().enabled = false;
    }


    private void OnMouseDown()
    {
        if (UIManager.Instance.mousePointer.MouseType == MouseType.Repair)
        {
            StartCoroutine(ObsRepair());
        }
    }


    public void DestroyObs()
    {
        StartCoroutine(ObsDestroy());
    }


    public void ObsFade()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        _sprite.enabled = true;
        Color color = _sprite.color;
        color.a = 1;
        _sprite.color = color;
        yield return new WaitForSeconds(0.3f);
        while (color.a >= 0.3f)
        {
            color.a -= 0.04f;
            _sprite.color = color;
            yield return 0;
        }
        _collider.enabled = false;
    }


    IEnumerator ObsDestroy()
    {
        _particle.Play();
        yield return new WaitForSeconds(0.3f);
        _particle.Pause();
        _sprite.enabled = false;
        _collider.enabled = false;
        this.isDestroyed = true;
    }

    IEnumerator ObsRepair()
    {
        Debug.Log("Repair");
        GetComponent<RewindParticleSystem>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        _sprite.enabled = true;
        Color color = _sprite.color;
        color.a = 0;
        _sprite.color = color;
        yield return new WaitForSeconds(0.3f);
        while (color.a <= 1)
        {
            color.a += 0.04f;
            _sprite.color = color;
            yield return 0;
        }
        _collider.enabled = true;
        this.isRepaired = true;
    }
















}

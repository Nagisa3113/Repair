﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public float fadeTime = 20;
    public float stayTime = 1.5f;

    public List<Text> texts;

    SpriteRenderer sR;

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
    

        Color c = sR.color;
        c.a = 0;
        sR.color = c;
        foreach(var t in texts)
        {
            t.color = c;
        }

        while (c.a <= 1)
        {
            c.a += 1 / fadeTime;
            sR.color = c;
            foreach (var t in texts)
            {
                t.color = c;
            }
            yield return 0;
        }

        yield return new WaitForSeconds(stayTime);

        while (c.a >= 0)
        {
            foreach (var t in texts)
            {
                t.color = c;
            }
            c.a -= 1 / fadeTime;
            sR.color = c;
            yield return 0;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    Image image;
    Text text;
    ScriptablePlots scriptablePlots;
    public ScriptablePlots ScriptablePlots
    {
        set
        {
            if (scriptablePlots == value) return;
            else
            {
                scriptablePlots = value;
                plot = scriptablePlots.plots[0];
                StartCoroutine(AutoText());
            }
        }
    }
    public Plot plot;

    int i;
    int index;
    [SerializeField]
    float textSpeed = 0.1f;

    [SerializeField]
    List<string> textList = new List<string>();

    public bool textFinished = true;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();

        text.text = "";
        index = 0;

    }

    private void OnEnable()
    {

    }

    private void Update()
    {
        if (GameManager.Instance.IsPause) return;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (textList.Count < 1) return;

        //    if (index == textList.Count)
        //    {
        //        //Destroy(currentobs.gameObject);
        //        //currentobs = null;
        //        textList.Clear();
        //        index = 0;
        //    }
        //    //text.text = textList[index];
        //    //index++;
        //    if (textFinished == true)
        //    {
        //        StartCoroutine(SetTextUI());
        //    }
        //    else
        //    {
        //        StopAllCoroutines();
        //        for (int j = i + 1; j < textList[index].Length; j++)
        //        {
        //            text.text += textList[index][j];
        //        }
        //        i = 0;
        //        index++;
        //        textFinished = true;
        //    }
        //}
    }

    IEnumerator AutoText()
    {
        textFinished = false;

        text.text = "";
        while (true)
        {
            for (int i = 0; i < plot.texts.Count; i++)
            {
                for (int j = 0; j < plot.texts[i].Length; j++)
                {
                    text.text += plot.texts[i][j];
                    yield return new WaitForSeconds(textSpeed);
                }
                yield return new WaitForSeconds(0.6f);
                text.text = "";
            }

            if (plot.nextPlotNum == -1)
            {
                //GameOver;
                UIManager.Instance.pausePanel.OnEnter();
                break;
            }
            else if (plot.nextPlotNum == -2)
            {
                GameManager.Instance.player.obstacle.ObsFade();
                break;
            }
            else
            {
                plot = scriptablePlots.plots[plot.nextPlotNum];
            }

        }

        textFinished = true;
    }



    public void Reset()
    {
        StopAllCoroutines();
        textList.Clear();
        index = 0;
        text.text = "";
    }


    public void OnImageEnter()
    {
        UIManager.Instance.mousePointer.MouseType = MouseType.Destroy;
    }

    public void OnImageClick()
    {
        if (plot.canInterrupt)
        {
            GameManager.Instance.player.obstacle.DestroyObs();

            StopAllCoroutines();
            plot = scriptablePlots.plots[plot.interruptPlotNum];
            StartCoroutine(AutoText());

        }
    }

    public void OnImageExit()
    {
        UIManager.Instance.mousePointer.MouseType = MouseType.Null;
    }





}

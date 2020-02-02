using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    public ScriptablePlots plot_good;
    public ScriptablePlots plot_bad;

    public Image image;
    Text text;

    public Plot plot;

    public int index;
    [SerializeField]
    float textSpeed = 0.1f;

    public bool textFinished = true;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
        text.text = "";
        index = 0;
        plot = plot_good.plots[index];
    }


    IEnumerator AutoText()
    {
        textFinished = false;

        text.text = "";

        AudioManager.Instance.PlayClip(AudioManager.Instance.type);

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

        AudioManager.Instance.audio.Stop();

        textFinished = true;

        if (plot.nextPlotNum == -1)
        {
            //GameOver;
            UIManager.Instance.pausePanel.OnEnter();
        }
        else if (plot.nextPlotNum == -2)
        {
        }
        else
        {
            GameManager.Instance.player.obstacle.ObsFade();
        }
    }


    public void NextMsg()
    {
        index = plot.nextPlotNum;
        plot = plot_good.plots[index];
        StartCoroutine(AutoText());
    }

    public void NextMsg(int index)
    {
        plot = plot_good.plots[index];
        index = plot.nextPlotNum;
        StartCoroutine(AutoText());
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
            plot = plot_bad.plots[plot.interruptPlotNum];
            StartCoroutine(AutoText());

        }
    }

    public void OnImageExit()
    {
        UIManager.Instance.mousePointer.MouseType = MouseType.Null;
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    [SerializeField]
    float textSpeed = 0.1f;

    public Text text;

    public TextAsset textAsset;

    public int index;

    [SerializeField]
    List<string> textList = new List<string>();

    bool textFinished = true;

    int i;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.text = "";
        GetTextFromFile(textAsset);
        index = 0;
    }

    private void OnEnable()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (index == textList.Count)
            {
                index = 0;
            }
            //text.text = textList[index];
            //index++;
            if (textFinished == true)
            {
                StartCoroutine(SetTextUI());
            }
            else
            {
                StopAllCoroutines();
                for (int j = i; j < textList[index].Length; j++)
                {
                    text.text += textList[index][j];
                }
                i = 0;
                index++;
                textFinished = true;
            }
        }
    }


    void GetTextFromFile(TextAsset textAsset)
    {
        textList.Clear();
        index = 0;
        var lineData = textAsset.text.Split('\n');

        foreach (var t in lineData)
        {
            textList.Add(t);
        }
    }


    IEnumerator SetTextUI()
    {
        textFinished = false;
        text.text = "";
        for (i = 0; i < textList[index].Length; i++)
        {
            text.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        index++;
        textFinished = true;
    }





}

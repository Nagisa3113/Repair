using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    float time;
    public Text timeText;
    float delta = 2;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPause) return;
        time += Time.deltaTime;
        timeText.text = (time / delta).ToString("f2");

    }
}

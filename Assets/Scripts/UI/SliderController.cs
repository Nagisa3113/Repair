using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    Player player;
    public float currentValue;
    float max;
    float min;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        max = GameManager.Instance.endPos.x - GameManager.Instance.startPos.x;
        min = GameManager.Instance.startPos.x;

        slider.onValueChanged.AddListener((value) =>
        {
            if (GameManager.Instance.IsPause)
            {
                if (value > currentValue) { slider.value = currentValue; }
                else { player.transform.position = new Vector3(value * max + min, player.transform.position.y, player.transform.position.z); }
            }

        });

    }

    void Update()
    {
        slider.value = (GameManager.Instance.player.transform.position.x - min) / max;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Image image;
    public Slider slider;
    public SliderController sc;
    public Text text;
    Button button;

    private void Awake()
    {

        button = GetComponentInChildren<Button>();
        slider = GetComponentInChildren<Slider>();
        sc = GetComponentInChildren<SliderController>();

        text.enabled = false;
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            OnExit();
        });

        button.gameObject.SetActive(false);
    }


    public void OnEnter()
    {

        text.enabled = true;
        UIManager.Instance.pausePanel.sc.currentValue = UIManager.Instance.pausePanel.slider.value;
        button.gameObject.SetActive(true);
        image.enabled = true;
        GameManager.Instance.IsPause = true;
        slider.interactable = true;
        sc.currentValue = slider.value;
        UIManager.Instance.mousePointer.MouseType = MouseType.Null;
    }


    public void OnExit()
    {
        text.enabled = false;

        button.gameObject.SetActive(false);
        image.enabled = false;
        GameManager.Instance.IsPause = false;
        slider.interactable = false;
        UIManager.Instance.mousePointer.MouseType = MouseType.Null;
    }
}

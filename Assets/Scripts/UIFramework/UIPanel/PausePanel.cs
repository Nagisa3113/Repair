using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    Image image;
    Button button;
    public Slider slider;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponentInChildren<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            image.enabled = !image.enabled;
            GameManager.Instance.isPause = !GameManager.Instance.isPause;
            slider.interactable = !slider.interactable;
            UIManager.Instance.sliderController.currentValue = UIManager.Instance.sliderController.slider.value;
            UIManager.Instance.mousePointer.MouseType = MouseType.Repair;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}

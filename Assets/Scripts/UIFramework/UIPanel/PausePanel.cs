using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    Image image;
    Button button;
    public Slider slider;

    [SerializeField]
    bool isOn ;
    bool IsOn
    {
        get { return isOn; }
        set
        {
            if (value == true) OnEnter();
            else OnExit();
            isOn = value;
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponentInChildren<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => { IsOn = !isOn; });
    }

    public void OnEnter()
    {
        image.enabled = true;
        GameManager.Instance.IsPause = true;
        slider.interactable = true;
        UIManager.Instance.sliderController.currentValue = UIManager.Instance.sliderController.slider.value;
        UIManager.Instance.mousePointer.MouseType = MouseType.Repair;
    }


    public void OnExit()
    {
        image.enabled = false;
        GameManager.Instance.IsPause = false;
        slider.interactable = false;
        UIManager.Instance.mousePointer.MouseType = MouseType.Destroy;

    }
}

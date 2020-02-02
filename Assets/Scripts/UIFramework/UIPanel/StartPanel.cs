using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    InputField inputField;
    Button button;

    public override void OnEnter()
    {
        inputField = GetComponentInChildren<InputField>();
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(() =>
        {
            UIManager.Instance.playerInfo.nameText.text = inputField.textComponent.text;
            UIManager.Instance.PopPanel();
        });
        base.OnEnter();
        Time.timeScale = 0;
    }

    public override void OnExit()
    {
        base.OnExit();
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

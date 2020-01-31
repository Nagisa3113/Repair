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
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
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

    private void Awake()
    {
        inputField = GetComponentInChildren<InputField>();
        button = GetComponentInChildren<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            GameManager.Instance.player.name = inputField.textComponent.text;
            UIManager.Instance.PopPanel();
        });
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}

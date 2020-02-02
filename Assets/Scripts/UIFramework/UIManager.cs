using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject goodend;

    public static UIManager Instance;

    public Image image_bg;

    public SliderController sliderController;
    public MousePointer mousePointer;
    public PlayerInfo playerInfo;
    public DialogPanel dialogPanel;
    public PausePanel pausePanel;



    [SerializeField]
    Transform canvasTransform;
    public Transform UICanvas
    {
        get { return canvasTransform; }
    }

    Dictionary<UIPanelType, string> panelPathDict;//存储所有面板Prefab的路径
    Dictionary<UIPanelType, BasePanel> panelDict;//保存所有实例化面板的游戏物体身上的BasePanel组件

    Stack<BasePanel> panelStack;
    public List<String> panels;

    public BasePanel CurrentPanel
    {
        get { return panelStack?.Peek(); }
    }


    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(Fade());
    }


    IEnumerator Fade()
    {
        Color c = image_bg.color;
        while (c.a > 0.02f)
        {
            c.a -= 0.005f;
            image_bg.color = c;
            yield return 0;
        }

        Destroy(image_bg.gameObject);
        UIManager.Instance.PushPanel(UIPanelType.StartPanel);

    }


    void Awake()
    {
        Instance = this;
        ParseUIPanelTypeJson();
    }

    public void ReSetPanel()
    {
        int n = this.gameObject.transform.childCount;
        for (int i = 0; i < n; i++)
        {
            Destroy(this.gameObject.transform.GetChild(i).transform.gameObject);
        }
        panelStack = null;
        panelDict = null;
    }


    /// <summary>
    /// 把某个页面入栈,把某个页面显示在界面上
    /// </summary>
    public void PushPanel(UIPanelType panelType, object args = null)
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        //判断一下栈里面是否有页面
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(panelType);

        panel.OnEnter();
        panelStack.Push(panel);
    }
    /// <summary>
    /// 出栈,把页面从界面上移除
    /// </summary>
    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;

        //关闭栈顶页面的显示
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }

    /// <summary>
    /// 根据面板类型得到实例化的面板
    /// </summary>
    /// <returns></returns>
    BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        //BasePanel panel;
        //panelDict.TryGetValue(panelType, out panel);//TODO

        BasePanel panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
            //string path;
            //panelPathDict.TryGetValue(panelType, out path);
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(canvasTransform, false);

            if (!panelDict.ContainsKey(panelType))
            {
                panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            }
            else
            {
                panelDict[panelType] = instPanel.GetComponent<BasePanel>();
            }
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }

    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }

    void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanel/UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            //Debug.Log(info.panelType);
            panelPathDict.Add(info.panelType, info.path);
        }
    }

    public void OnPushPanelButton(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIManager.Instance.PushPanel(panelType);
    }

    //public void Test()
    //{
    //    string path ;
    //    panelPathDict.TryGetValue(UIPanelType.MapPanel,out path);
    //    Debug.Log(path);
    //}
}

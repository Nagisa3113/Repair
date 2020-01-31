using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public Player player;

    public Vector3 startPos;
    public Vector3 endPos;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startPos = player.transform.position;
        endPos = startPos + new Vector3(25, 0, 0);

        //UIManager.Instance.PushPanel(UIPanelType.StartPanel);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

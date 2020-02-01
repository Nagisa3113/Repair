using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Obstacle> obstacleList = new List<Obstacle>();

    bool isPause;
    public bool IsPause
    {
        get { return isPause; }
        set
        {
            if (value) PauseGame();
            else ReGame();
            isPause = value;
        }
    }

    public static GameManager Instance;

    public Player player;

    public Vector3 startPos;
    public Vector3 endPos;

    private void Awake()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startPos = player.transform.position;
        endPos = startPos + new Vector3(25, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        //UIManager.Instance.PushPanel(UIPanelType.StartPanel);
    }

    void PauseGame()
    {
        foreach(var obs in obstacleList)
        {
            if (obs.isDestroyed)
            {
                obs.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                obs.isDestroyed = false;
            }
        }
        Time.timeScale = 0;

    }

    void ReGame()
    {
        foreach (var obs in obstacleList)
        {
            if (obs.isDestroyed)
            {
                obs.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        Time.timeScale = 1;
    }


}

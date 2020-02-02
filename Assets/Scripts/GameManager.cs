using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    public Transform lastObs;

    private void Awake()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startPos = player.transform.position;
        endPos = lastObs.position;
    }

    void PauseGame()
    {
        player.obstacle = null;
        player.animator.SetBool("idle", true);
        UIManager.Instance.dialogPanel.image.raycastTarget = false;
    }

    void ReGame()
    {
        player.animator.SetBool("idle", false);
        UIManager.Instance.dialogPanel.image.raycastTarget = true; ;

    }

}

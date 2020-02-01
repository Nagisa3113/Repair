using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOject : MonoBehaviour
{
    Player player;

    [SerializeField] Vector3 offset = new Vector3(-.5f, 1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        this.transform.SetParent(player.transform);

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Vector3.Lerp(this.transform.position, dis, Time.deltaTime);
        //this.transform.position = Vector3.MoveTowards(this.transform.position, dis, Time.deltaTime);
        Vector3 speed = Vector3.zero;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, player.transform.position + offset, ref speed, 0.1f);

    }
}

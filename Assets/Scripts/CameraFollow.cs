using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Player player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        offset = this.transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + offset, Time.deltaTime);

    }
}

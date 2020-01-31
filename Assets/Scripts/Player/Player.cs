using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name { get; set; }

    public  int hp;

    public int gold;

    public int anger;


    public int status;


    Rigidbody2D rg;

    public float moveSpeed = 3f;

    public bool canMove = true;


    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rg.velocity = new Vector2(1f * moveSpeed, rg.velocity.y);
        }

    }
}

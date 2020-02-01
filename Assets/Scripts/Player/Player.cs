using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask objectLayer;

    public string name { get; set; }
    public int hp;
    public int gold;
    public int anger;
    public int status;

    Rigidbody2D rg;
    public Animator animator;

    public float moveSpeed = 3f;
    public bool canMove;


    int anim_idle;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        anim_idle = Animator.StringToHash("idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPause) return;

        if (canMove)
        {
            rg.velocity = new Vector2(1f * moveSpeed, rg.velocity.y);
           // rg.MovePosition(transform.position + Vector3.right * .1f);
        }

        //Debug.DrawLine(this.transform.position, this.transform.position + Vector3.right * .5f);
    }

    RaycastHit2D colliderHit;

    private void FixedUpdate()
    {
        colliderHit = Physics2D.Raycast(this.transform.position, Vector2.right, .5f, objectLayer);

        if (colliderHit.collider != null)
        {
            canMove = false;
            animator.SetBool(anim_idle, true);
            //Debug.Log(colliderHit.collider.name);
        }
        else
        {
            canMove = true;
            animator.SetBool(anim_idle, false);
        }
    }



}

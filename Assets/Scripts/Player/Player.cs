using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask objectLayer;
    public string playerName { get; set; }
    public float age;
    Rigidbody2D rg;
    Animator animator;
    public float moveSpeed = 3f;
    public bool canMove;
    int anim_idle;

    public Obstacle obstacle;


    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        age = 0;
        anim_idle = Animator.StringToHash("idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPause) return;

        if (canMove)
        {
            age += Time.deltaTime;
            rg.velocity = new Vector2(1f * moveSpeed, rg.velocity.y);
            // rg.MovePosition(transform.position + Vector3.right * .1f);
        }
        //Debug.DrawLine(this.transform.position, this.transform.position + Vector3.right * .5f);
    }
    RaycastHit2D colliderHit;

    private void FixedUpdate()
    {
        colliderHit = Physics2D.Raycast(this.transform.position, Vector2.right, .5f, objectLayer);

        if (colliderHit)
        {
            canMove = false;
            animator.SetBool(anim_idle, true);
            if (colliderHit.collider.GetComponent<Obstacle>() != null)
            {
                
                Obstacle ob = colliderHit.collider.GetComponent<Obstacle>();
                obstacle = ob;
                UIManager.Instance.dialogPanel.ScriptablePlots = ob.scriptablePlots;
            }
        }
        else
        {
            canMove = true;
            animator.SetBool(anim_idle, false);
        }
    }



}

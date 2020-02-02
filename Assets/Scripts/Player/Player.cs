using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask objectLayer;
    public string playerName { get; set; }
    public float age;
    Rigidbody2D rg;
    public Animator animator;
    public float moveSpeed = 3f;
    public bool canMove = true;
    int anim_idle;


    public float ageSpeed;

    public Obstacle obstacle;

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

        if (GameManager.Instance.IsPause) return;

        if (canMove && UIManager.Instance.dialogPanel.textFinished)
        {
            animator.SetBool(anim_idle, false);
            age += Time.deltaTime * ageSpeed;
            rg.velocity = new Vector2(1f * moveSpeed, rg.velocity.y);
            // rg.MovePosition(transform.position + Vector3.right * .1f);
        }
        //Debug.DrawLine(this.transform.position, this.transform.position + Vector3.right * .5f);
    }
    RaycastHit2D colliderHit;



    private void FixedUpdate()
    {

        if (GameManager.Instance.IsPause) return;

        colliderHit = Physics2D.Raycast(this.transform.position, Vector2.right, .5f, objectLayer);

        if (colliderHit && colliderHit.collider.GetComponent<Obstacle>().isDestroyed)
        {
            UIManager.Instance.pausePanel.OnEnter();
        }

        else if (colliderHit)
        {


            if (colliderHit.collider.GetComponent<Obstacle>() != null && colliderHit.collider.GetComponent<Obstacle>() != obstacle)
            {

                obstacle = colliderHit.collider.GetComponent<Obstacle>();


                if (obstacle.beDetected == false)
                {
                    obstacle.beDetected = true;
                    obstacle.plotIndex = UIManager.Instance.dialogPanel.index;
                    UIManager.Instance.dialogPanel.NextMsg();
                }
                else
                {
                    UIManager.Instance.dialogPanel.NextMsg(obstacle.plotIndex);
                }
            }
            canMove = false;
            animator.SetBool(anim_idle, true);

        }
        else
        {
            canMove = true;
            animator.SetBool(anim_idle, false);
        }
    }



}

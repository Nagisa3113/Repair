using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public Text timeText;
    public Image image;
    public Sprite manSprite;

    public Text nameText;

    public Text status;

    public Animator player_anim;

    AnimatorOverrideController aoc;


    public AnimationClip m_walk;
    public AnimationClip m_idle;


    Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        aoc = new AnimatorOverrideController(player_anim.runtimeAnimatorController);
        player_anim.runtimeAnimatorController = aoc;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPause) return;
        timeText.text = (player.age).ToString("f2");



        if (player.age >= 20)
        {
            image.sprite = manSprite;
            aoc["child_walk"] = m_walk;
            aoc["child_idle"] = m_idle; ;

            status.text = "Adult";
        }

    }
}

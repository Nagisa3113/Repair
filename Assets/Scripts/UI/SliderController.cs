using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    Slider slider;

    Player player;

    float max;
    float min;

    private void Awake()
    {
        slider = GetComponent<Slider>();

    }

    // Start is called before the first frame update
    void Start()
    {

        player = GameManager.Instance.player;
        max = GameManager.Instance.endPos.x - GameManager.Instance.startPos.x;
        min = GameManager.Instance.startPos.x;

        slider.onValueChanged.AddListener((value) =>
        {
            player.transform.position = new Vector3(value * max + min, player.transform.position.y, player.transform.position.z);
        });

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (GameManager.Instance.player.transform.position.x - min) / max;
    }


    private void OnMouseDown()
    {
        player.canMove = false;
    }

    private void OnMouseUp()
    {
        player.canMove = true;
    }


}

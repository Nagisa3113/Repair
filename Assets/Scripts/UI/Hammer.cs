using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer : MonoBehaviour
{

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, Input.mousePosition, null,out pos); 

        Vector3 dis = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis.z = this.transform.position.z;
        //transform.position = dis;
        transform.position = pos;

        //this.transform.position = Vector3.Lerp(this.transform.position, dis, Time.deltaTime);
        //this.transform.position = Vector3.MoveTowards(this.transform.position, dis, Time.deltaTime);
        //Vector3 speed = Vector3.zero;
        //this.transform.position = Vector3.SmoothDamp(this.transform.position, dis, ref speed, 0.1f);

    }
}

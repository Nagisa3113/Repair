using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MouseType
{
    Null,
    Destroy,
    Repair
}

public class MousePointer : MonoBehaviour
{
    public Sprite repairSprite;
    public Sprite destroySprite;

    public string destroyText;
    public string repairText;

    Image image;
    Text text;

    [SerializeField]
    MouseType mouseType = MouseType.Null;
    public MouseType MouseType
    {
        get { return mouseType; }
        set
        {
            switch (value)
            {
                case MouseType.Destroy:
                    this.image.enabled = true;
                    this.image.sprite = destroySprite;
                    this.text.text = destroyText;
                    break;
                case MouseType.Repair:
                    this.image.enabled = true;
                    this.image.sprite = repairSprite;
                    this.text.text = repairText;
                    break;
                default:
                    this.image.enabled = false;
                    this.text.text = " ";
                    break;
            }
            mouseType = value;
        }
    }

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, Input.mousePosition, null, out pos);

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

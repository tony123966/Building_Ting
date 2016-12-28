using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{

    public List<GameObject> horlist;
    public List<GameObject> verlist;
    public List<GameObject> freelist;
    // Use this for initialization
    private DragItemController dragitemcontroller;
    private MeshObj meshobj;
    private Vector3 setPos;
    void Start()
    {
        dragitemcontroller = GameObject.Find("DragItemController").GetComponent<DragItemController>();

    }

    void Awake()
    {

        List<GameObject> horlist = new List<GameObject>();
        List<GameObject> verlist = new List<GameObject>();
        List<GameObject> freelist = new List<GameObject>();

    }
	public void Move(Vector2 mospos_)
    {
        //1.找自己在哪個list ver or hor
        GameObject obj = dragitemcontroller.chooseObj;

        // 找水平
        for (int h = 0; h < horlist.Count; h++)
        {
            if (obj == horlist[h])
            {
                setPos = new Vector3(mospos_.x, obj.transform.position.y, obj.transform.position.z);
            }
        }
        //找垂直
        for (int v = 0; v < verlist.Count; v++)
        {
            if (obj == verlist[v])
            {
                setPos = new Vector3(obj.transform.position.x, mospos_.y, obj.transform.position.z);
            }
            //print ("choose in verlist");
        }
        //free
        for (int f = 0; f < freelist.Count; f++)
        {
            if (obj == freelist[f])
            {
                setPos = new Vector3(mospos_.x, mospos_.y, obj.transform.position.z);
            }
        }

        if (obj.transform.parent.GetComponent<MeshObj>())
        {
            obj.transform.position = obj.transform.parent.GetComponent<MeshObj>().ClampPos(setPos);
            obj.transform.parent.GetComponent<MeshObj>().adjPos();
        }
		else if (obj.transform.root.GetComponent<platform2icon>())
        {
			obj.transform.position = obj.transform.root.GetComponent<platform2icon>().ClampPos(setPos);
			obj.transform.root.GetComponent<platform2icon>().adjPos();
        }

        else if (obj.transform.root.GetComponent<body2icon>())
        {
			obj.transform.position = obj.transform.root.GetComponent<body2icon>().ClampPos(setPos);
			obj.transform.root.GetComponent<body2icon>().adjPos();
        }
        //***********
        else if (obj.transform.parent.GetComponent<rooficon>())
        {
            obj.transform.position = setPos;
            obj.transform.parent.GetComponent<rooficon>().reset();
        }
		else if (obj.transform.parent.GetComponent<Testing>())
        {
			obj.transform.position = obj.transform.parent.GetComponent<Testing>().ClampPos(setPos);
            obj.transform.parent.GetComponent<Testing>().adjPos();
        }
    }
    public void intiAllList()
    {
        freelist.Clear();
        verlist.Clear();
        horlist.Clear();
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DecorateEmptyObjectList : MonoBehaviour
{
    public List<GameObject> objectList = new List<GameObject>();
    void OnDestroy()
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            Destroy(objectList[i]);
        }
    }
}

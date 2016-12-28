using UnityEngine;
using System.Collections;

public class mice2 : MonoBehaviour
{
    public bool RemoveUnusedSegments = false;
    CurvySpline mSpline;
    SplineWalkerDistance Walker;


    // Use this for initialization
    void Start()
    {
        mSpline = GetComponent<CurvySpline>();
        Walker = GameObject.FindObjectOfType(typeof(SplineWalkerDistance)) as SplineWalkerDistance;
        //while (!mSpline.IsInitialized)
        //    yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        // Add Control Point by mouseclick

       

    }

    void OnMouseOver()
    {

        GetComponent<Renderer>().material.color = Color.yellow;
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 p = Input.mousePosition;
            p.z = 10;
            p = Camera.main.ScreenToWorldPoint(p);


           
            Destroy(this.gameObject);
            pubvar.ball--;
            //mSpline.RefreshImmediately();

            




            //remove the oldest segment, if it's no longer used
            if (RemoveUnusedSegments)
            {
                var seg = mSpline.DistanceToSegment(Walker.Distance);
                if (seg != mSpline[0])
                {
                    Walker.Distance -= mSpline[0].Length;
                    mSpline.Delete(mSpline[0]);
                }
            }
        }









    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }








}

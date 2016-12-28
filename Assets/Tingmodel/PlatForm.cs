using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlatForm : MonoBehaviour
{

	public UIcontrol ucit;
	public ColumnControl clc;

	public List<GameObject> platform = new List<GameObject>();

	public bool parayn = false;


	public float looog;
	public Vector3 doot;
	public Vector3 doot2;

	public float percent;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void build()
	{

		int angle = ucit.numberslidervalue;
		if (angle != 10 && angle != 4)
		{
			GameObject haha = GameObject.Find("0" + angle + "_platform");

			Vector3 v0 = transform.parent.GetChild(3).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);


			GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;


			//plat.name=("xxx");

			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = v1 - v3;

			float ssize = Vector3.Magnitude(v2) * 2.5f;

			percent = Vector3.Magnitude(v2);



			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = 2f * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;

			if (angle == 3)
			{
				plat.transform.Rotate(0, 105, 0);
			}
			if (angle == 5)
			{
				plat.transform.Rotate(0, 153, 0);
			}
			if (angle == 6)
			{
				plat.transform.Rotate(0, 45, 0);
			}
			if (angle == 7)
			{
				plat.transform.Rotate(0, 20, 0);
			}
			if (angle == 8)
			{
				plat.transform.Rotate(0, 45, 0);
			}
			if (angle == 9)
			{
				plat.transform.Rotate(0, 25.5f, 0);
			}



		}
		else if (angle == 4)
		{

			GameObject haha = GameObject.Find("0" + angle + "_platform");
			Vector3 v0 = transform.parent.GetChild(3).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);


			GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = v1 - v3;

			float ssize = Vector3.Magnitude(v2) * 2.0f;


			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = 2f * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;

			plat.transform.Rotate(0, 45, 0);
		}
		else
		{

			GameObject haha = GameObject.Find("10_platform");
			Vector3 v0 = transform.parent.GetChild(3).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);


			GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = v1 - v3;

			float ssize = Vector3.Magnitude(v2) * 2f;


			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = 2f * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;

			plat.transform.Rotate(0, 45, 0);
		}




	}


	public void build2(float a, float b)
	{

		int angle = ucit.numberslidervalue;
		if (angle != 10 && angle != 4)
		{
			GameObject haha = GameObject.Find("0" + angle + "_platform");

			Vector3 v0 = transform.parent.GetChild(3).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);


			GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;


			//plat.name=("xxx");

			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = v1 - v3;

			float ssize = (percent + b) * 2.5f;

			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = (2f + a) * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;

			if (angle == 3)
			{
				plat.transform.Rotate(0, 105, 0);
			}
			if (angle == 5)
			{
				plat.transform.Rotate(0, 153, 0);
			}
			if (angle == 6)
			{
				plat.transform.Rotate(0, 45, 0);
			}
			if (angle == 7)
			{
				plat.transform.Rotate(0, 20, 0);
			}
			if (angle == 8)
			{
				plat.transform.Rotate(0, 45, 0);
			}
			if (angle == 9)
			{
				plat.transform.Rotate(0, 25.5f, 0);
			}



		}
		else if (angle == 4)
		{

			GameObject haha = GameObject.Find("0" + angle + "_platform");
			Vector3 v0 = transform.parent.GetChild(3).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);


			GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = v1 - v3;

			float ssize = (percent + b) * 2.0f;


			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = (2f + a) * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;

			plat.transform.Rotate(0, 45, 0);
		}
		else
		{

			GameObject haha = GameObject.Find("10_platform");
			Vector3 v0 = transform.parent.GetChild(3).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);


			GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = v1 - v3;

			float ssize = (percent + b) * 2f;


			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = (2f + a) * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;

			plat.transform.Rotate(0, 45, 0);
		}




	}




    public void build3(float a, float b)
    {

        int angle = ucit.numberslidervalue;
        
     
            GameObject haha = GameObject.Find("0" + angle + "_platform");
            Vector3 v0 = transform.parent.GetChild(3).transform.position;
            Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
            v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

            Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);


            GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
            plat.transform.parent = this.transform;
            platform.Add(plat);

            Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
            Vector3 v2 = v1 - v3;

            float ssize = (percent) * 2.0f;


            float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
            float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
            float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

            Vector3 scale = plat.transform.GetChild(0).transform.localScale;

            scale.x = (a+2f) * scale.x / xxb;
            scale.y = 2f  * scale.y / yyb;
            scale.z = (b+2f) * scale.z / zzb;

            plat.transform.GetChild(0).transform.localScale = scale;

            plat.transform.Rotate(0, 45, 0);
        
        


    }














	public void reset()
	{
		for (int i = 0; i < platform.Count; i++)
		{
			Destroy(platform[0]);
		}
		platform.Clear();

		build();
	}

	public void parareset(float a, float b)
	{

		//parayn = true;




		for (int i = 0; i < platform.Count; i++)
		{

			Destroy(platform[0]);
		}
		platform.Clear();





		build2(a, b);
	}


	public void para2reset()
	{


		for (int i = 0; i < platform.Count; i++)
		{

			Destroy(platform[0]);
		}
		platform.Clear();

		parabuild(looog, doot, doot2);

	}


    public void para3reset(float a, float b)
    {

        //parayn = true;




        for (int i = 0; i < platform.Count; i++)
        {

            Destroy(platform[0]);
        }
        platform.Clear();





        build3(a, b);
    }


















	public void parabuild(float lonng, Vector3 dot, Vector3 dot2)
	{









		int angle = ucit.numberslidervalue;
		if (angle != 10 && angle != 4 && angle != 3)
		{


			print("QQQQQ3");



			GameObject haha = GameObject.Find("0" + angle + "_platform");

			Vector3 v0 = transform.parent.GetChild(10).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);

			Vector3 pp = new Vector3(v4.x, dot2.y, v4.z);


			//GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			GameObject plat = Instantiate(haha, pp, Quaternion.identity) as GameObject;


			plat.name = ("xxxx");

			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			//Vector3 v2 = dot - v3;
			Vector3 v2 = new Vector3(dot.x - v3.x, 0, dot.z - v3.z);



			float ssize = Vector3.Magnitude(v2) * 1;

			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;


			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = lonng * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;


			if (angle == 5)
			{
				plat.transform.Rotate(0, 153, 0);
			}
			if (angle == 6)
			{
				plat.transform.Rotate(0, 45, 0);
			}
			if (angle == 7)
			{
				plat.transform.Rotate(0, 20, 0);
			}
			if (angle == 8)
			{
				plat.transform.Rotate(0, 45, 0);
			}
			if (angle == 9)
			{
				plat.transform.Rotate(0, 25.5f, 0);
			}



		}
		else if (angle == 4)
		{

			GameObject haha = GameObject.Find("0" + angle + "_platform");
			Vector3 v0 = transform.parent.GetChild(10).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);
			Vector3 pp = new Vector3(v4.x, dot2.y, v4.z);


			//GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			GameObject plat = Instantiate(haha, pp, Quaternion.identity) as GameObject;

			plat.name = ("xxxx");

			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = new Vector3(dot.x - v3.x, 0, dot.z - v3.z);

			float ssize = Vector3.Magnitude(v2) * 2.5f;


			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			//scale.x = ssize * scale.x / xxb;
			scale.y = lonng * scale.y / yyb;
			//scale.z = ssize * scale.z / zzb;

			scale.x = ssize * scale.x / xxb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;



			plat.transform.Rotate(0, 45, 0);
		}
		else if (angle == 3)
		{

			GameObject haha = GameObject.Find("0" + angle + "_platform");
			Vector3 v0 = transform.parent.GetChild(10).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);
			Vector3 pp = new Vector3(v4.x, dot2.y, v4.z);


			//GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			GameObject plat = Instantiate(haha, pp, Quaternion.identity) as GameObject;

			plat.name = ("xxxx");

			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = new Vector3(dot.x - v3.x, 0, dot.z - v3.z);

			float ssize = Vector3.Magnitude(v2) * 1f;


			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			//scale.x = ssize * scale.x / xxb;
			scale.y = lonng * scale.y / yyb;
			//scale.z = ssize * scale.z / zzb;

			scale.x = ssize * scale.x / xxb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;



			plat.transform.Rotate(0, 105, 0);
		}
		else
		{

			GameObject haha = GameObject.Find("10_platform");
			Vector3 v0 = transform.parent.GetChild(3).transform.position;
			Vector3 v3 = transform.parent.parent.GetChild(0).transform.position;
			v0.y = clc.columnmanage[0].transform.GetChild(3).transform.position.y - 2f;

			Vector3 v4 = new Vector3(v3.x, v0.y, v3.z);
			Vector3 pp = new Vector3(v4.x, dot2.y, v4.z);


			//GameObject plat = Instantiate(haha, v4, Quaternion.identity) as GameObject;
			GameObject plat = Instantiate(haha, pp, Quaternion.identity) as GameObject;

			plat.name = ("xxxx");

			plat.transform.parent = this.transform;
			platform.Add(plat);

			Vector3 v1 = clc.columnmanage[0].transform.GetChild(3).transform.position;
			Vector3 v2 = new Vector3(dot.x - v3.x, 0, dot.z - v3.z);

			float ssize = Vector3.Magnitude(v2) * 2f;


			float xxb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.x;
			float yyb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.y;
			float zzb = plat.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size.z;

			Vector3 scale = plat.transform.GetChild(0).transform.localScale;

			scale.x = ssize * scale.x / xxb;
			scale.y = lonng * scale.y / yyb;
			scale.z = ssize * scale.z / zzb;

			plat.transform.GetChild(0).transform.localScale = scale;

			plat.transform.Rotate(0, 45, 0);
		}


	}

}

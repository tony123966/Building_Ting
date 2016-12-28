using UnityEngine;
using System.Collections;

public class apple : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPostRender()
    {

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Begin(GL.LINES);
        //lineMat.SetPass(0);
        GL.Color(new Color(0f, 0f, 0f, 1f));
        GL.Vertex3(0f, 0f, 0f);
        GL.Vertex3(100f, 111f, 1f);
        GL.End();
        GL.PopMatrix();

        Debug.Log("123123");
    }
}

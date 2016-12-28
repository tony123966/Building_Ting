using UnityEngine;
using System.Collections;

public class combinemesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();


         Material[] mats = new Material[meshRenderers.Length];
         for (int j = 0; j < meshRenderers.Length; j++)
         {
             //生成材质球数组 
             mats[j] = meshRenderers[j].sharedMaterial;
            
         }


        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.active = false;
            i++;
        }


        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine,false);
        
        transform.gameObject.active = true;

       
        transform.GetComponent<MeshRenderer>().sharedMaterials = mats;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

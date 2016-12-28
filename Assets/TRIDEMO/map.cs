using UnityEngine;
using System.Collections;

public class map : MonoBehaviour
{

    public Material myMaterial;

    [Range(-10, 10)]
    public float uvValue = 0.9f;

    Mesh m;

    void Start()
    {

        // 初始化
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material = myMaterial;

        MeshFilter mf = GetComponent<MeshFilter>();
        m = new Mesh();
        mf.mesh = m;

        // 建立頂點
        Vector3[] v = new Vector3[4];
        v[0] = new Vector3(0, 0, 0);
        v[1] = new Vector3(1, 0, 0);
        v[2] = new Vector3(0, 1, 0);
        v[3] = new Vector3(1, 1, 0);

        // 建立三角形
        int[] t = new int[6];
        t[0] = 2;
        t[1] = 1;
        t[2] = 0;

        t[3] = 1;
        t[4] = 2;
        t[5] = 3;

        // 建立法線
        Vector3[] n = new Vector3[4];
        n[0] = new Vector3(0, 0, -1);
        n[1] = new Vector3(0, 0, -1);
        n[2] = new Vector3(0, 0, -1);
        n[3] = new Vector3(0, 0, -1);

        // 套用
        m.vertices = v;
        m.triangles = t;
        m.normals = n;
    }

    // 動態改變 UV 貼圖
    void Update()
    {
        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(uvValue, 0);
        uv[2] = new Vector2(0, uvValue);
        uv[3] = new Vector2(uvValue, uvValue);
        m.uv = uv;
    }

}
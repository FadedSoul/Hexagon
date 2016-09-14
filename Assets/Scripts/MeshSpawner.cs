using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshSpawner : MonoBehaviour
{
    public List<Vector3> Vertices;
    public Vector2[] UV;
    public List<int> Triangles;

    private float rad = 0.0174532925f;

    [SerializeField]
    private Material material;

    [SerializeField]
    private int sides = 6;

    void Start()
    {
        meshSetup();
        meshDraw();
    }

    void meshSetup() {
        Vertices = new List<Vector3> { };

        for(int i = 0; i < sides ; i++)
        {
            Vertices.Add(new Vector3(Mathf.Cos((30 + (360 / sides) * i) * rad) * 1f, 0f, Mathf.Sin((30 + (360 / sides) * i) * rad) * 1f));
        }

        Vertices.Add(Vector3.zero);

        Triangles = new List<int> { };

        for (int i = 0; i < sides; i++)
        {
            Triangles.Add(sides);
                if(i < sides-1)
                    Triangles.Add(i +1);
                else
                    Triangles.Add(0);
                Triangles.Add(i);
        }
    }

    void meshDraw() {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        Mesh mesh = new Mesh();

        mesh.vertices = Vertices.ToArray();
        mesh.triangles = Triangles.ToArray();
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

        GetComponent<MeshRenderer>().material = material;
    
    }

}
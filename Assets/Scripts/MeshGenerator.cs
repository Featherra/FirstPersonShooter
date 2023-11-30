using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (MeshFilter))]
[RequireComponent(typeof (MeshRenderer))]
[RequireComponent (typeof (MeshCollider))]

public class MeshGenerator : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3 (0f, 0f, 0f), //0
            new Vector3 (1f, 0f, 0f), //1
            new Vector3 (0f, 0f, 1f), //2
            new Vector3 (1f, 0f, 1f), //3
            new Vector3 (0.5f, 1f, 0.5f), //4 
        };

        triangles = new int[]
        {
            // piramide
            0,1,2, //bottom
            2,1,3, //bottom
           4,1,0, //side 1
           0,2,4, // side 2
           4,2,3, //side 3
           1,4,3, // side 4
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

}
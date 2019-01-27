﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour
{

    public Mesh mesh; 
    // Start is called before the first frame update
    void Start()
    {
        if (!mesh)
        {
            mesh = this.gameObject.GetComponent<MeshFilter>().sharedMesh;
            var rb  = this.gameObject.AddComponent<Rigidbody>();
            rb.mass = VolumeOfMesh(mesh);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 o)
    {
        Vector3 v1 = p1 - o;
        Vector3 v2 = p2 - o;
        Vector3 v3 = p3 - o;

        return Vector3.Dot(Vector3.Cross(v1, v2), v3) / 6f; ;
    }

    public float VolumeOfMesh(Mesh mesh)
    {
        float volume = 0;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        Vector3 o = new Vector3(0f, 0f, 0f);
        // Computing the center mass of the polyhedron as the fourth element of each mesh
        for (int i = 0; i < mesh.triangles.Length; i++)
        {
            o += vertices[triangles[i]];
        }
        o = o / mesh.triangles.Length;

        // Computing the sum of the volumes of all the sub-polyhedrons
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i + 0]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            volume += SignedVolumeOfTriangle(p1, p2, p3, o);
        }
        return Mathf.Abs(volume);
    }

}

using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

// This script is placed in public domain. The author takes no responsibility for any possible harm.


public class CrumpleMesh : MonoBehaviour {

	public float scale = 1.0f;
    public float speed = 0.5f;
    public bool recalculateNormals = false;

    Vector3[] baseVertices;
    Perlin noise;

    void Start ()
    {
        noise = new Perlin ();
    }

    void Update () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
        if (baseVertices == null)
        baseVertices = mesh.vertices;

        Vector3[] vertices = new Vector3[baseVertices.Length];
        
        float timex = Time.time * speed + 0.1365143f;
        float timey = Time.time * speed + 1.21688f;
        float timez = Time.time * speed + 2.5564f;
        for (int i=0;i<vertices.Length;i++)
        {
            Vector3 vertex = baseVertices[i];

            vertex.x += noise.Noise(timex + vertex.x, 
                timex + vertex.y, 
                timex + vertex.z) * scale;
            vertex.y += noise.Noise(timey + vertex.x, timey + 
                vertex.y, 
                timey + vertex.z) * scale;
            vertex.z += noise.Noise(timez + vertex.x, 
                timez + vertex.y, 
                timez + vertex.z) * scale;
            
            vertices[i] = vertex;
        }
        
        mesh.vertices = vertices;
        
        if (recalculateNormals) 
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}

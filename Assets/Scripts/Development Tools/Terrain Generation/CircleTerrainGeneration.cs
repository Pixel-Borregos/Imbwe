using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CircleTerrainGeneration : MonoBehaviour
{
    [Header("Terrain Configuration")]

    [Tooltip("How big the terrain should be")]
    [SerializeField] float terrain_radius;

    [Tooltip("Default is 1, change if you need to height")]
    [SerializeField] int terrain_height = 1;

    [Tooltip("Set to true if you wish to randomize the height")]
    [SerializeField] bool terrain_randomizeHeight = false;

    [Tooltip("Set max height to randomize terrain height")]
    [SerializeField] int terrain_maxHeight = 1;

    [Header("Generation Configuration")]
    [Tooltip("Sets terrain's center")]
    [SerializeField] Vector3 terrain_origin;

    [Tooltip("Define the object to place while generating the terrain")]
    [SerializeField] GameObject prefab;

    [Tooltip("Set the object that will hold the objects that create the terrain.")]
    [SerializeField] Transform terrain_container;


    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> createdPoints = new List<Vector3>();
        int position = 0;
        while( position < 360)
        {
            float x = MathF.Cos(position) * terrain_radius + terrain_origin.x;
            float z = Mathf.Sin(position) * terrain_radius + terrain_origin.z;
            int Y = (terrain_randomizeHeight) 
                ? UnityEngine.Random.Range(terrain_height, terrain_maxHeight + 1) 
                : terrain_height;

            Vector3 prefabPosition = new Vector3((int)x, 0, (int)z);
            position++;

            if (createdPoints.Contains(prefabPosition))
                continue;

            createdPoints.Add(new Vector3((int)x, 0, z));

            for(int y = 1; y <= Y; y++)
            {
                prefabPosition.y++;
                
                GameObject go = Instantiate(prefab, prefabPosition, Quaternion.identity);
                go.transform.parent = terrain_container;
            }
            
        }
    }
}

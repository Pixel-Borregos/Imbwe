using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeTerrainGeneration : MonoBehaviour
{
    [Header("Terrain Configuration")]

    [Tooltip("How big the terrain should be")]
    [SerializeField] float terrain_radius;

    [Tooltip("Default is 5, change if you need to make the base higher. Will affect Dome starting height.")]
    [SerializeField] int terrain_baseHeight = 5;

    [Tooltip("Default is 5. The dome height is multiplied by 2")]
    [SerializeField] int terrain_domeHeight = 5;

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
        GenerateBase();
        GenerateDome();
    }

    public void GenerateBase()
    {
        int baseHeight = 0;
        while (baseHeight++ <= terrain_baseHeight)
        {
            List<Vector3> createdPoints = new List<Vector3>();
            int position = -1;

            while (position++ < 360)
            {
                float x = MathF.Cos(position) * terrain_radius + terrain_origin.x;
                float z = MathF.Sin(position) * terrain_radius + terrain_origin.z;

                Vector3 prefabPosition = new Vector3((int)x, baseHeight, (int)z);

                if (createdPoints.Contains(prefabPosition))
                    continue;

                createdPoints.Add(prefabPosition);

                GameObject go = Instantiate(prefab, prefabPosition, Quaternion.identity);
                go.transform.parent = terrain_container;

            }
        }
    }
    
    public void GenerateDome()
    {
        int currentHeight = terrain_baseHeight + 1 ;
        while (terrain_radius > 0 )
        {
            List<Vector3> createdPoints = new List<Vector3>();
            int position = -1;

            while (position++ < 360)
            {
                float x = MathF.Cos(position) * terrain_radius + terrain_origin.x;
                float z = MathF.Sin(position) * terrain_radius + terrain_origin.z;

                Vector3 prefabPosition = new Vector3((int)x, currentHeight, (int)z);

                if (createdPoints.Contains(prefabPosition))
                    continue;

                createdPoints.Add(prefabPosition);

                GameObject go = Instantiate(prefab, prefabPosition, Quaternion.identity);
                go.transform.parent = terrain_container;

            }
                
            
            currentHeight++;
            terrain_radius--;
        }
    }
}

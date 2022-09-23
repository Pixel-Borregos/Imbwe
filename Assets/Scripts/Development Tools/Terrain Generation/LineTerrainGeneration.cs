using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTerrainGeneration : MonoBehaviour
{
    [SerializeField] Vector3 start;
    [SerializeField] Vector3 end;
    [SerializeField] char attribute;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform container;
    [SerializeField] int height;
    [SerializeField] bool randomizeHeight;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = new Vector3(0,0,0);
        switch( attribute)
        {
            case 'x':
                direction = (start.x < end.x) ?  new Vector3(1,0,0) : new Vector3(-1,0,0);
                break;
            case 'y':
                direction = (start.y < end.y) ? new Vector3(0,1,0) : new Vector3(0,-1,0);
                break;
            case 'z':
                direction = (start.z < end.z) ? new Vector3(0,0,1) : new Vector3(0,0,-1);
                break;
        }
        while( start != end)
        {
            int currentHeight = height;
            if(randomizeHeight)
                currentHeight = Random.Range(1,currentHeight);
            for (int i = 0; i <= currentHeight; i++)
            {
                Vector3 tempPosition = start;
                tempPosition.y = i;
                GameObject go = Instantiate(prefab, tempPosition, Quaternion.identity);
                go.transform.parent = container;
                
            }
            start += direction;
        }
    }

  
    
}

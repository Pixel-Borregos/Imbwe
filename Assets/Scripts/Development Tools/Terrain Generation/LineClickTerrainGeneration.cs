using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineClickTerrainGeneration : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform container;
    [SerializeField] Camera cam;
    [SerializeField] int MaxHeight;
    Vector3 startPosition;
    Vector3 endPosition;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.y = cam.pixelHeight - pos.y;
            pos.z = cam.farClipPlane;
            pos = cam.ScreenToWorldPoint(pos);
            pos.y = 1;
            int h = Random.Range(1, MaxHeight);
            for (int i = 0; i < h; i++)
            {
                GameObject go = Instantiate(prefab, pos, Quaternion.identity);
                go.transform.parent = container;
                pos.y++;
            }
        }
    }
}

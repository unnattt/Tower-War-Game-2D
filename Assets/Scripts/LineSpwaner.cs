using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpwaner : MonoBehaviour
{
    public GameObject linePrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(gameObject.transform.ge )
            LineObjectSpwaner();
        }
           
    }
    private void Start()
    {
        LineObjectSpwaner();
    }

    public void LineObjectSpwaner()
    {
        GameObject spwan = Instantiate(linePrefab, transform.position, transform.rotation);
        spwan.transform.parent = gameObject.transform;
    }
}

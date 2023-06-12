using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpwaner : MonoBehaviour
{
    public List<LinesScript> lines;
    public LinesScript lineScript;

    public static LineSpwaner inst;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
       
    }

    public void LineObjectSpwaner()
    {
        LinesScript spwan = Instantiate(lineScript, transform.position, transform.rotation);
        spwan.transform.parent = gameObject.transform;
        lines.Add(spwan);
    }
}

    

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesScript : MonoBehaviour
{
    EdgeCollider2D edgeCollider;
    public LineRenderer myline;

    private void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        myline = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        SetEdgesCollider(myline);

    }

    void SetEdgesCollider(LineRenderer line)
    {
        List<Vector2> edges = new();

        for (int i = 0; i < line.positionCount; i++)
        {
            edges.Add(line.GetPosition(i));
        }
        edgeCollider.SetPoints(edges);
        //edgeCollider.offset = new Vector2(edgeCollider.offset.x, edgeCollider.points[0].y * -1);
    }

    public void DrawLine(Vector2 startPos, Vector2 endPos)
    {
        myline.SetPosition(0, startPos);
        myline.SetPosition(1, endPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("LineDestroy");
        LineSpwaner.inst.LineObjectSpwaner();
        Destroy(gameObject, 0);
    }


}


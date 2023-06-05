using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerToTowerLine : MonoBehaviour
{
    EdgeCollider2D edgeCollider;
    LineRenderer myline;

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
            Vector2 lineRendererPoint = line.GetPosition(i);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
        edgeCollider.SetPoints(edges);       
    }
}

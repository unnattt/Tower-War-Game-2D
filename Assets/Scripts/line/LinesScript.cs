using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesScript : MonoBehaviour
{
    EdgeCollider2D edgeCollider;
    public LineRenderer myline;
    public TowerBehaviour source;    
    //public bool isLineUsed;

    private void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    //private void OnEnable()
    //{
    //    Debug.Log("From Line Script");
    //    isLineUsed = false;
    //}

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
        if (collision.gameObject.CompareTag("trail"))
        {
            Debug.Log("Name " + collision.gameObject.name);
            source.RemoveLines(this);
            //source.countLinesForSoliders--;            
            Destroy(gameObject);
            Debug.Log("LineDestroy");
        }
    }


}


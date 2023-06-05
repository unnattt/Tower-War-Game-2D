using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerToTowerLine : MonoBehaviour
{
    Vector3 target;
    Vector3 target1;
    Vector3 mousePos;

    private bool isBlue;
    LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void OnMouseDown()
    {
        ScreenMouseRay();
    }

    void ScreenMouseRay()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit)
        {
            isBlue = hit.collider.gameObject.CompareTag("blue");
            if (isBlue)
            {
                target = hit.collider.gameObject.transform.position;
            }
        }
    }

    private void OnMouseDrag()
    {
        TargetToTowerLine();
    }

    private void OnMouseUp()
    {
        CheckTower();
    }

    void CheckTower()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit)
        {
            target1 = hit.collider.gameObject.transform.position;
            DrawLine();
        }
        if (!hit)
        {
            line.SetPosition(1, target);
            Destroy(gameObject, 1f);
        }




    }

    void TargetToTowerLine()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target1 = new Vector3(mousePos.x, mousePos.y, 0f);
        DrawLine();
    }

    void DrawLine()
    {
        line.SetPosition(0, target);
        line.SetPosition(1, target1);
    }
}

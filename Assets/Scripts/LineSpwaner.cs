using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpwaner : MonoBehaviour
{
    public List<LineRenderer> Lines;

    Vector3 target;
    Vector3 target1;
    Vector3 mousePos;
    int i = 2;
    private bool isBlue;

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        //    if (hit)
        //    {
        //        Lines[i].SetPosition(1, target);
        //    }
        //}
    }
    private void OnMouseDown()
    {
        ScreenMouseRay();
    }

    private void OnMouseDrag()
    {
        TargetToTowerLine();
    }

    private void OnMouseUp()
    {
        CheckTower();
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

    void CheckTower()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit)
        {
            target1 = hit.collider.gameObject.transform.position;
            Lines[i].SetPosition(0, target);
            Lines[i].SetPosition(1, target1);
            i--;
        }

        if (!hit)
        {
            Lines[i].SetPosition(1, target);
        }

    }

    void TargetToTowerLine()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target1 = new Vector3(mousePos.x, mousePos.y, 0f);
        Lines[i].SetPosition(0, target);
        Lines[i].SetPosition(1, target1);
    }
}

//private void Update()
//{
//    if (Input.GetMouseButtonDown(0) && gameObject.transform.childCount < 0)
//    {
//        LineObjectSpwaner();
//    }

//}

//private void Start()
//{
//    LineObjectSpwaner();
//}

//public void LineObjectSpwaner()
//{
//    GameObject spwan = Instantiate(linePrefab, transform.position, transform.rotation);
//    spwan.transform.parent = gameObject.transform;
//}

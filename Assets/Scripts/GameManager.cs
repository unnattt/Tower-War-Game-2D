using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color myColor;
    GameObject Source;
    Vector3 mousePos;
    Vector3 Destination;
    private bool isEnemyTowerOccupied;
    private bool isBlue;
    int i = 0;
    [SerializeField] LayerMask BlueTowerMask;
    [SerializeField] LayerMask GreyTowerMask;
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetTowerSource();
        }
        if (Input.GetMouseButton(0))
        {
            LineToMousePos();
        }
        if (Input.GetMouseButtonUp(0))
        {
            //TrailCollison.inst.isUpdate = true;
            CheckTower();
            DestoryLine();
        }
    }

    public void GetTowerSource()
    {
        //TrailCollison.inst.isUpdate = false;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 10, BlueTowerMask);
        if (hit.collider != null)
        {

            //TowerBehaviour t = hit.collider.gameObject.GetComponent<TowerBehaviour>();

            //if (t == null)
            //{
            //    return;
            //}

            //isBlue = t.myColor == myColor;
            //if (isBlue)
            //{                
            //    Source = hit.collider.gameObject.transform.position;
            //}
            Source = hit.collider.gameObject;
        }
    }

    public void CheckTower()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 10, GreyTowerMask);
        isEnemyTowerOccupied = hit.collider.GetComponent<TowerBehaviour>().isOccupied;
        if (hit.collider != null && !isEnemyTowerOccupied)
        {
            isEnemyTowerOccupied = true;
            Destination = hit.collider.gameObject.transform.position;
            LineSpwaner.inst.lines[i].DrawLine(Source.transform.position, Destination);
            i++;            
        }

        

        //if (hit)
        //{
        //    TowerBehaviour t = hit.collider.gameObject.GetComponent<TowerBehaviour>();
        //    if (t == null)
        //    {
        //        return;
        //    }

        //    isEnemyTower = t.myColor == Color.Grey;
        //    if (isEnemyTower)
        //    {
        //        Debug.Log("isEnemy made true count:" + i);
        //        Destination = hit.collider.gameObject.transform.position;
        //        LineSpwaner.inst.lines[i].DrawLine(Source.transform.position, Destination);
        //        i++;
        //    }
        //    else
        //    {
        //        LineSpwaner.inst.LineObjectSpwaner();
        //        Destroy(LineSpwaner.inst.lines[i].gameObject);
        //        i++;
        //        Debug.Log("isDestroy and count+ : " + i);
        //    }
        //}

    }

    public void LineToMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Destination = new Vector3(mousePos.x, mousePos.y, 0f);

        if (Source != null)
            LineSpwaner.inst.lines[i].DrawLine(Source.transform.position, Destination);
    }

    void DestoryLine()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 10, GreyTowerMask);
        if (hit.collider == null)
        {
            Destroy(LineSpwaner.inst.lines[i].gameObject);
            LineSpwaner.inst.LineObjectSpwaner();
            i++;
            Debug.Log("isDestroy and count+ : " + i);
        }
    }

    public void GetMaxLineCount()
    {


    }
}

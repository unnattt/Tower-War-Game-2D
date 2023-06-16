using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color myColor;

    GameObject Source;
    GameObject Destination;
    Vector3 mousePos;

    //List<Vector3> _destinations;
    public GameObject trailObject;
    public TrailRenderer myline;
    public LinesScript tempLine;

    TowerBehaviour tower;

    public bool isTrailOn;
    private bool isBlue;
    private bool isEnemyTower;


    private void Start()
    {
        isTrailOn = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetTowerSource();
        }

        if (Input.GetMouseButton(0))
        {
            if (isTrailOn == true)
            {
                TrialRendererOn();
            }
            else
                LineToMousePos();

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isTrailOn == true)
            {
                TrialRendererOff();
            }
            else
            {
                CheckTowerIsDestination();
                DestoryLine();
            }
        }
    }

    public void TrialRendererOff()
    {
        trailObject.SetActive(false);
    }

    public void TrialRendererOn()
    {
        trailObject.SetActive(true);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit)
        {
            trailObject.transform.position = new Vector2(hit.point.x, hit.point.y);
        }
    }

    public void GetTowerSource()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit)
        {
            TowerBehaviour t = hit.collider.gameObject.GetComponent<TowerBehaviour>();

            if (t == null)
            {
                return;
            }

            isBlue = t.myColor == myColor;
            if (isBlue)
            {
                isTrailOn = false;
                Source = hit.collider.gameObject;
                tower = Source.GetComponent<TowerBehaviour>();
            }
        }
        else
        {
            isTrailOn = true;
        }
    }

    public void CheckTowerIsDestination()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        Debug.LogWarning("hit: " + hit.collider.name);
        Debug.LogWarning("SOurce: " + Source.name);
        if (hit.collider != null && hit.collider != Source && hit.collider.GetComponent<TowerBehaviour>())
        {
            Destination = hit.collider.gameObject;
            if (tower.CanMakeNewLine())
            {
                tower.AddLines(Source.transform.position, Destination.transform.position);
            }
            isTrailOn = true;
        }
    }

    public void LineToMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Source != null)
        {
            if (tower.CanMakeNewLine())
            {
                Vector3 Destination = new Vector3(mousePos.x, mousePos.y, 0f);
                tempLine.DrawLine(Source.transform.position, Destination);
            }
        }
    }

    void DestoryLine()
    {
        Debug.Log(" ResetLine");
        tempLine.DrawLine(Source.transform.position, Source.transform.position);
        isTrailOn = true;
    }
}

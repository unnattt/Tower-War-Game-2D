using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color myColor;

    GameObject spwan;
    GameObject Source;
    Vector3 Destination;
    Vector3 mousePos;

    public GameObject trailObject;
    public TrailRenderer myline;
    public GameObject SoliderPrefab;

    public bool isUpdate;
    private bool isBlue;
    private bool isEnemyTower;

    int i = 0;

    private void Start()
    {
        isUpdate = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetTowerSource();
        }

        if (Input.GetMouseButton(0))
        {
            if (isUpdate == true)
            {
                TrialRendererOn();
            }
            else
                LineToMousePos();

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isUpdate == true)
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
                isUpdate = false;
                Source = hit.collider.gameObject;
                LineSpwaner.inst.LineObjectSpwaner();
            }
        }
        else
        {
            isUpdate = true;
        }

    }

    public void CheckTowerIsDestination()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("is hit on up: " + hit.collider.gameObject.name);
            TowerBehaviour t = hit.collider.gameObject.GetComponent<TowerBehaviour>();
            if (t == null)
            {
                return;
            }

            isEnemyTower = t.myColor == Color.Grey;
            if (isEnemyTower)
            {
                Debug.Log("isEnemy made true count:" + i);
                Destination = hit.collider.gameObject.transform.position;
                LineSpwaner.inst.lines[i].DrawLine(Source.transform.position, Destination);
                StartCoroutine(SoliderObjectSpwaner(Source.transform.position, Destination));
                i++;
                isUpdate = true;
            }
        }
    }

    public void LineToMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Source != null)
        {
            Destination = new Vector3(mousePos.x, mousePos.y, 0f);
            LineSpwaner.inst.lines[i].DrawLine(Source.transform.position, Destination);
        }
    }

    void DestoryLine()
    {
        Debug.Log("is Destroy");
        Destroy(LineSpwaner.inst.lines[i].gameObject);
        LineSpwaner.inst.LineObjectSpwaner();
        i++;
        isUpdate = true;
    }

    IEnumerator SoliderObjectSpwaner(Vector2 startPos, Vector2 endPos)
    {
        yield return new WaitForSeconds(0.2f);
        spwan = Instantiate(SoliderPrefab, Source.transform.position, Source.transform.rotation);
        spwan.transform.parent = Source.transform;
        SolidersScript obj = spwan.GetComponent<SolidersScript>();
        obj.StartCoroutine(obj.SoliderMovement(startPos, endPos, 1));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color myColor;

    GameObject Source;
    GameObject Destination;
    Vector3 mousePos;
    
    public GameObject trailObject;
    public TrailRenderer myline;

    public LinesScript tempLine;

    TowerBehaviour tower;
    
    public bool isTrailOn;
    private bool isBlue;
    private bool isGround;

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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero);      
        if (hit.collider != null)
        {
            Ground g = hit.collider.GetComponent<Ground>();
            if(g== null)
            {
                Debug.Log("Ground is null");
                return;
            }

            isGround = g.myColor == Color.None;
            if (isGround)
            {
                trailObject.SetActive(true);
                trailObject.transform.position = new Vector2(mousePos.x, mousePos.y);
            }
        }       
    }

    public void GetTowerSource()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null)
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
        
        if (hit.collider != null && hit.collider.GetComponent<TowerBehaviour>() && Vector2.Distance(tower.transform.position,mousePos) > 1)
        {
            Debug.Log("Is Tower");
            Destination = hit.collider.gameObject;            
            if (tower.CanMakeNewLine())
            {              
                for (int i = 0; i < tower.lines.Count; i++)
                {
                    if (Vector2.Distance(tower.lines[i].myline.GetPosition(1), Destination.transform.position) < 1f)
                    {
                        Debug.Log("destination SAme Return");
                        return;
                    }
                }
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

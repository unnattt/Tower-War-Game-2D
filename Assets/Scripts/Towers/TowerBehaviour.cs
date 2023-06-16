using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerBehaviour : MonoBehaviour
{
    public Color myColor;

    int Level1 = 5;
    int Level2 = 10;
    int Level3 = 30;
    int levelCount;

    [Header("All Int For Lines And Soliders")]
    public int tempLineCount = 1;
    public int countLinesForSoliders = 0;

    [Header("Soliders")]
    public SolidersScript SoliderPrefab;
    public GameObject SolidersSpwanPoint;


    [Header("TowerLines")]
    public List<LinesScript> lines;
    public LinesScript lineScriptPrefab;
    public GameObject LineSpwanerPoint;


    [Header("LevelCount")]
    [SerializeField] TextMeshPro CurrentLevel;
    

    bool checkSolidersAlive;

    private void Start()
    {
        CurrentLevel = GetComponentInChildren<TextMeshPro>();
        levelCount = int.Parse(CurrentLevel.text);
    }

    private void Update()
    {
        levelCount = int.Parse(CurrentLevel.text);
    }

    public bool CanMakeNewLine()
    {

        if (levelCount <= Level1)
        {

            if (lines.Count < tempLineCount)
            {
                return true;
            }
        }

        else if (levelCount <= Level2)
        {

            if (lines.Count < tempLineCount + 1)
            {
                return true;
            }
        }

        else if (levelCount <= Level3)
        {

            if (lines.Count < tempLineCount + 2)
            {
                return true;
            }
        }

        return false;
    }

    public void AddLines(Vector2 start, Vector2 end)
    {
        LinesScript spwanLine = Instantiate(lineScriptPrefab, LineSpwanerPoint.transform.position, LineSpwanerPoint.transform.rotation);
        spwanLine.transform.parent = LineSpwanerPoint.transform;
        spwanLine.DrawLine(start, end);
        spwanLine.source = this;        
        lines.Add(spwanLine);
        StartCoroutine(SoliderSpwanEverySec(start, end));
        
    }

    public void RemoveLines(LinesScript SpwanLine)
    {
        lines.Remove(SpwanLine);
    }

    public IEnumerator SoliderSpwanEverySec(Vector2 start,Vector2 end)
    {
        yield return new WaitForSeconds(1);
        SolidersScript spwanSolider = Instantiate(SoliderPrefab, SolidersSpwanPoint.transform.position, SolidersSpwanPoint.transform.rotation);
        spwanSolider.transform.parent = SolidersSpwanPoint.transform;
        StartCoroutine(spwanSolider.SoliderMovement(start, end, 1f));
        StartCoroutine(SoliderSpwanEverySec(start, end));
    }

    public void AddPoint()
    {

    }

    public void RemovePoint()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("soliders"))
        {
            checkSolidersAlive = collision.gameObject.GetComponent<SolidersScript>().Isdead == true;
            if (checkSolidersAlive)
                Destroy(collision.gameObject, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("soliders"))
        {
            collision.gameObject.GetComponent<SolidersScript>().Isdead = true;
        }
    }
}




    //int counter = 0;
    //for (int i = 0; i < lines.Count; i++)
    //{
    //    Debug.Log("Loop " + i);
    //    if (lines[i].isLineUsed == true)
    //    {
    //        Debug.Log("Loop true" + i);
    //        counter++;
    //    }
    //}
    //if (counter >= lineCount)
    //{
    //    canMakeLines = false;
    //    return;
    //}
    //Debug.Log("pre");
    ////spwanLine.isLineUsed = true;
    //Debug.Log("post");
    ////Debug.Log("Post1:" + spwanLine.isLineUsed);

//void ManageSolidersAccordingToLines()
//{
//    if (lines.Count > coun)
//    {
//        Debug.Log("is Line countBefore: " + countLinesForSoliders);
//        countLinesForSoliders++;            
//        Debug.Log("is Line countAfter: " + countLinesForSoliders);

//    }
//}


//Debug.Log(Destination);
//LinesScript.inst.DrawLine(Source, Destination);

//foreach (LinesScript item in lines)
//{
//    if(Vector2.Distance( item..GetPosition(1), Destination) < 1f)
//    {
//        return;
//    }
//}
//private void Update()
//{
//    if (Input.GetMouseButtonDown(0) && gameObject.transform.childCount < 0)
//    {
//        LineObjectSpwaner();
//    }

//}


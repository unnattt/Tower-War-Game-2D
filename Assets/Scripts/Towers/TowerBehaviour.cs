using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerBehaviour : MonoBehaviour
{
    public Color myColor;

    //AllLevels Define;
    int Level1 = 5;
    int Level2 = 10;
    int Level3 = 30;    
    int levelCount;

    [Header("All Int For Lines And Soliders")]
    public int tempLineCount = 1;
    public int countLinesForSoliders = 0;
    public int currentLine = -1;

    [Header("Soliders")]
    public SolidersScript SoliderPrefab;
    public GameObject SolidersSpwanPoint;


    [Header("TowerLines")]
    public List<LinesScript> lines;
    public LinesScript lineScriptPrefab;
    public GameObject LineSpwanerPoint;


    [Header("LevelCount")]
    [SerializeField] TextMeshPro CurrentLevel;


    [Header("LevelSpriteChangeArea")]
    public SpriteRenderer[] towerSprite;
    SpriteRenderer myCurrentSprite;

    private void Start()
    {
        CurrentLevel = GetComponentInChildren<TextMeshPro>();
        levelCount = int.Parse(CurrentLevel.text);
        StartCoroutine(SoliderSpwanEverySec());
        myCurrentSprite = GetComponent<SpriteRenderer>();
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
    }

    public void RemoveLines(LinesScript SpwanLine)
    {
        lines.Remove(SpwanLine);
    }

    public IEnumerator SoliderSpwanEverySec()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (lines.Count > 0)
            {
                currentLine++;
                if (currentLine < lines.Count)
                {
                    SolidersScript spwanSolider = Instantiate(SoliderPrefab, SolidersSpwanPoint.transform.position, SolidersSpwanPoint.transform.rotation);
                    spwanSolider.transform.parent = SolidersSpwanPoint.transform;
                    StartCoroutine(spwanSolider.SoliderMovement(lines[currentLine].myline.GetPosition(0), lines[currentLine].myline.GetPosition(1), 1f));
                }
                else
                {
                    currentLine = -1;
                }
            }           
        }
    }

    public void AddPoint()
    {
        levelCount++;
        CurrentLevel.text = levelCount.ToString();
    }

    public void RemovePoint()
    {
        if(levelCount < 0)
        {
            levelCount = 0;
        }
        levelCount--;
        CurrentLevel.text = levelCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("soliders"))
        {
            collision.gameObject.GetComponent<SolidersScript>().Isdead = true;
        }
    }

    public void ChangeTowerColorAccordingToCurrentLevel(SolidersScript soliders)
    {
       if(levelCount <= 0 && soliders.mycolor != myColor)
        {
            myCurrentSprite.color = towerSprite[1].color;
            myColor = Color.Blue;
        }       

       //else if(levelCount > 0)
       // {
       //     myCurrentSprite.color = towerSprite[1].color;
       //     myColor = Color.Blue;
       // }       
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


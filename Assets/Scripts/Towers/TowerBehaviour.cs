using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerBehaviour : MonoBehaviour
{
    public Color myColor;

    int Level1 = 0;
    int Level2 = 10;
    int level3 = 30;

     TextMeshPro CurrentLevel;

    private void Start()
    {
        CurrentLevel = GetComponent<TextMeshPro>();
        CurrentLevel.text = level3.ToString();
    }

}


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


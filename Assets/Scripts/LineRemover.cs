using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRemover : MonoBehaviour
{
    public GameObject touchPrefab;

    void Start()
    {

    }

    void Update()
    {

    }

    void GroundTouch()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider)
        {
            GameObject spwan = Instantiate(touchPrefab, transform.position, transform.rotation);
            spwan.transform.parent = gameObject.transform;
        }

    }

   

}


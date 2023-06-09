using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollison : MonoBehaviour
{
    public GameObject trailObject;
    public TrailRenderer myline;
    Vector2 mousePos;
    public bool isUpdate;
    public static TrailCollison inst;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        isUpdate = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0) && isUpdate)
        {
            trailObject.SetActive(false);
        }
        if (Input.GetMouseButton(0) && isUpdate)
        {
            trailObject.SetActive(true);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit)
            {
                trailObject.transform.position = new Vector2(hit.point.x, hit.point.y);
            }
        }


    }
}
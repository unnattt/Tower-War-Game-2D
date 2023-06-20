using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidersScript : MonoBehaviour
{
    public Color mycolor;
    
    public bool Isdead;

    public IEnumerator SoliderMovement(Vector2 StartPoint, Vector2 EndPoint, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(StartPoint, EndPoint, time / duration);
            time += Time.deltaTime;
            yield return null;
        }        
    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Isdead)
        {
            TowerBehaviour destination = collision.gameObject.GetComponent<TowerBehaviour>();
            if(destination == null)
            {
                return;
            }

            if (destination.myColor == mycolor && destination)
            {
                destination.AddPoint();
                destination.ChangeTowerColorAccordingToCurrentLevel(this);
                Destroy(gameObject, 1f);
            }
            else
            {
                destination.RemovePoint();
                destination.ChangeTowerColorAccordingToCurrentLevel(this);
                Destroy(gameObject, 1f);
            }
        }
    }
}

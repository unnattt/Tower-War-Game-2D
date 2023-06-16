using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidersScript : MonoBehaviour
{
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
}

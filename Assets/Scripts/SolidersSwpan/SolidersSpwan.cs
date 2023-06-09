using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidersSpwan : MonoBehaviour
{
    public List<SolidersScript> soliders;
    public SolidersScript SoliderPrefab;


    public void SoliderObjectSpwaner()
    {
        SolidersScript spwan = Instantiate(SoliderPrefab, transform.position, transform.rotation);
        spwan.transform.parent = gameObject.transform;
        soliders.Add(spwan);
    }

}

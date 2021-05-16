using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSyS : MonoBehaviour
{
    [HideInInspector]
    public int ObjCode = -1;
    public GameObject[] MapObj;
    public Life.State state;
    public bool All = false;
    public bool Loop = false;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (End && !Loop) return;
        if (collision.tag == "Att" && collision.GetComponent<Att>() != null && collision.GetComponent<Att>().Set && (collision.GetComponent<Att>().AttState == state || (All && collision.GetComponent<Att>().AttState != Life.State.일반공격))) 
        {
            if (ObjCode >= 0) GameSystem.instance.MapSSS(ObjCode);
            SpeO();
        }
    }
    bool End = false;
    public virtual void MapTrue()
    {
        for (int i = 0; MapObj != null &&i< MapObj.Length; i++) 
        {
            if (MapObj[i] != null && MapObj[i].GetComponent<Animator>() != null) 
            {
                MapObj[i].GetComponent<Animator>().SetTrigger("On");
            }
        }
        End = true;
    }
    public virtual void SpeO()
    {
        MapTrue();
        
    }
}

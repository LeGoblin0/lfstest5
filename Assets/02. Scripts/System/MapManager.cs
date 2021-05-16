using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (EnemySetPre == null) EnemySetPre = new GameObject("Enemy").transform;
        EnemySetPre.transform.parent = transform;
        EnemySetPre.gameObject.SetActive(false);
    }
    public Transform EnemySetPre;
    [HideInInspector]
    public Transform EEE;

    public bool XLock;
    public bool YLock;
    public void MakeEEE()
    {
        EEE = Instantiate(EnemySetPre);
        EEE.position = transform.position;
        EEE.gameObject.SetActive(true);
    }
}

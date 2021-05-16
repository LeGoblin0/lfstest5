using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SayTxtBox : MonoBehaviour
{
    public string TextBox;
    public Text InTxt;

    public bool StartText = false;
    public float DesTime = 0;

    private void Start()
    {
        transform.parent = GameObject.Find("SayCanv").transform;
        transform.localScale = new Vector3(1, 1, 1);
        if (StartText) StartTiping();
    }

    public void StartTiping()
    {
        StartCoroutine(TTipin());
    }


    int nowT = 0;
    IEnumerator TTipin()
    {
        while (nowT++< TextBox.Length)
        {
            InTxt.text = TextBox.Substring(0, nowT);
            yield return new WaitForSeconds(.05f);
        }
        if (DesTime > 0) Destroy(gameObject, DesTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_1 : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    public float TimeLate = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Boss_1_2>() != null)
        {
            Invoke("SET", TimeLate);
        }
    }
    void SET()
    {
        ani.SetTrigger("On");
    }
}

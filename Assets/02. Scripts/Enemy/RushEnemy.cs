using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemy : Enemy01
{
    public float Speed;
    public float RushTime = .8f;
    public float RushSpeed = 5;

    Rigidbody2D rig;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();//체력감소하면 사망

        rig.velocity = new Vector3(nowSpeed * flip, rig.velocity.y, 0);
        if (SenserPly && !gogo)  //플레이어와 충돌시 러쉬
        {
            gogo = true;
            ani.SetInteger("state", 1);
            Invoke("stop", RushTime);
        }
        rig.gravityScale = 1;


    }
    bool gogo = false;
    float nowSpeed;
    int flip = -1;
    public void Rush1()
    {
        nowSpeed = 0;
    }
    public void Rush2()
    {
        nowSpeed = RushSpeed;
    }
    public void Rush3()
    {
        nowSpeed = Speed;
    }
    void stop() //러시 멈춤
    {
        ani.SetInteger("state", 0);
        gogo = false;
    }
  
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.gameObject.tag == "TurnPoint")
        {
            flip *= -1;
            transform.GetChild(0).localScale = new Vector3(-flip, 1, 1);
        }
        
    }
}

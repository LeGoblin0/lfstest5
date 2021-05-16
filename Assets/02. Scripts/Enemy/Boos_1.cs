﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos_1 : Enemy01
{
    int AttNow = 0;
    int AttSave = 0;
    public int attCoolTime = 3;
    float nowCoolTime = 3.5f;
    public float SlowParsent = .7f;
    public float SlowTime = 5;
    public GameObject SlowImg;
    float nowSlowTime = 0;
    public float MaxSpeed = 12;
    float nowSpeed = 0;
    public float AcSpeed = 10;
    protected override void Start()
    {
        base.Start();
        ani.SetFloat("Speed", 1.6f);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (AttNow == 0 && nowCoolTime < 0)
        {
            while(AttNow==0|| AttNow == AttSave)
            {
                AttNow = Random.Range(1, 5);
            }
            AttSave = AttNow;
            ani.SetInteger("State", AttNow);
        }
        else nowCoolTime -= Time.deltaTime;

        if (nowSlowTime > 0)
        {
            SlowImg.SetActive(true);
            nowSlowTime -= Time.deltaTime;
            ani.SetFloat("Speed", 1.6f * SlowParsent);
        }
        else
        {
            SlowImg.SetActive(false);
            ani.SetFloat("Speed", 1.6f);
        }
    }
    public Transform ShootPre;
    public Transform ShootTr;
    public Transform ShootPre1;
    public Transform ShootTr1;
    public Vector2[] PowerShoot1;
    public void ShootAtt()
    {
        Transform ss = Instantiate(ShootPre);
        ss.position = ShootTr.position;
        ss.GetComponent<Rigidbody2D>().velocity = new Vector2(flip, 0) * 5;
    }
    public void ShootAtt1()
    {
        for (int i = 0; i < PowerShoot1.Length; i++)
        {
            Transform ss = Instantiate(ShootPre1);
            ss.position = ShootTr1.position;
            ss.GetComponent<Rigidbody2D>().velocity = new Vector2(PowerShoot1[i].x * flip, PowerShoot1[i].y);
        }
    }
    public void EndAtt()
    {
        ani.SetInteger("State", 0);
        AttNow = 0;
        nowCoolTime = attCoolTime;
    }
    private void FixedUpdate()
    {
        if (Hp <= 0)
        {
            AttNow = 0;
        }
        if (AttNow == 3)
        {
            transform.position += new Vector3(flip, 0, 0) * Time.deltaTime * nowSpeed * ((nowSlowTime > 0) ? 0.7f : 1);
            if (MaxSpeed > nowSpeed) nowSpeed += Time.deltaTime * AcSpeed;
            else nowSpeed = MaxSpeed;
        }
    }
    public Transform Boss_2;
    public void DieOne()
    {
        Transform ss = Instantiate(Boss_2);
        ss.position = transform.position;
        ss.GetChild(0).localScale = transform.GetChild(0).localScale;
        ss.GetComponent<Boss_1_2>().flip = flip;
        ss.GetComponent<SaveMonsetDie>().Code = GetComponent<SaveMonsetDie>().Code;
        Destroy(gameObject);
    }
    int flip = 1;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "TurnPoint")
        {
            flip *= -1;
            transform.GetChild(0).localScale = new Vector3(flip, 1, 1);
            ani.SetInteger("State", 0);
            nowSpeed = 0;
        }
        if (collision.tag == "Att" && collision.GetComponent<Att>() != null && collision.GetComponent<Att>().Set && collision.GetComponent<Att>().AttState == State.감전) 
        {
            nowSlowTime = SlowTime;
        }
    }
}

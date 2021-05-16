using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCont : MonoBehaviour
{
    public int aniState = 0;
    [Range(-1,1)]
    public int PlayerLook = 1;
    
    public bool MoveRight = false;
    public bool Moveleft = false;


    public float EndStoryTime = -1;

    Player ply;
    Transform plyTr;
    void Start()
    {
        plyTr = GameSystem.instance.Ply;
        ply = plyTr.GetComponent<Player>();

        plyTr.position = transform.position;
        plyTr.GetChild(0).localScale = new Vector3(PlayerLook, 1, 1);
        if (aniState == -1)
        {
            ply.ani.SetTrigger("Test");
            ply.ani.SetInteger("State", 0);
        }
        else
        {
            ply.ani.SetInteger("State", aniState);
        }
        if (MoveRight)
        {
            ply.OnStory_rigtht = true;
        }
        if (Moveleft)
        {
            ply.OnStory_left = true;
        }
        if (EndStoryTime > 0)
        {
            Invoke("EndS",EndStoryTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndS()
    {
        transform.parent.GetComponent<StoryOnOFf>().EndStory();
        ply.OnStory_left = false;
        ply.OnStory_rigtht = false;
    }
}

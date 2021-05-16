using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTxtSay : MonoBehaviour
{
    [System.Serializable]
    public class StoryTT
    {
        public int who;
        public string TxtIn;
    }
    public StoryTT[] Story;
    int NowStory = 0;
    public Transform[] TxtPos;
    public Transform TxtPre;
    void Start()
    {
        NextTxt();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NowStory++;
            if (NowStory >= Story.Length)
            {
                Destroy(tt.gameObject);
                transform.parent.GetComponent<StoryOnOFf>().EndStory();
                return;
            }
            else
            {
                Destroy(tt.gameObject);
                NextTxt();
            }
        }
    }
    Transform tt;
    void NextTxt()
    {
        tt= Instantiate(TxtPre, TxtPos[Story[NowStory].who]);
        tt.GetComponent<SayTxtBox>().TextBox = Story[NowStory].TxtIn;
        tt.GetComponent<SayTxtBox>().StartTiping();
    }
}

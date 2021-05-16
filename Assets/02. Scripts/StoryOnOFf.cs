using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryOnOFf : MonoBehaviour
{
    public int Codess = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int NowStory = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameSystem.instance.Ply.GetComponent<Player>().OnStory = true;
            Destroy(GetComponent<Collider2D>());
            OpenStory();
        }
    }
    void OpenStory()
    {
       //Debug.Log(NowStory + "  " + transform.childCount);
        if (NowStory >= transform.childCount)
        {
            //스토리 끝
            GameSystem.instance.StorySave(Codess);
            GameSystem.instance.Ply.GetComponent<Player>().OnStory = false;
            Destroy(gameObject);
            return;
        }
        transform.GetChild(NowStory).gameObject.SetActive(true);
    }
    public void EndStory()
    {
        transform.GetChild(NowStory).gameObject.SetActive(false);
        NowStory++;
        OpenStory();

    }
    private void OnDestroy()
    {
        
    }
}

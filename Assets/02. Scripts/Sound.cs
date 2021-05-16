using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        if (GetComponent<AudioSource>() == null)
        {
            aus = gameObject.AddComponent<AudioSource>();
            aus.spatialBlend = 1;
            aus.minDistance = 5; //Debug.Log(aus+"  1");
            aus.maxDistance = 15;
            aus.rolloffMode = AudioRolloffMode.Custom;
            //aus.volume = 0;
            //Invoke("OnVolum", 1);
        }
    }
    public void OnVolum()
    {

    }
    AudioSource aus;
    // Update is called once per frame
    void Update()
    {
        
    }
    public AudioClip[] SSS;
    public void Sound00()
    {
        gogo(0);
    }
    public void Sound01()
    {
        gogo(1);
    }

    public void Sound02()
    {
        gogo(2);
    }

    void gogo(int i)
    {
        if (aus == null) aus = GetComponent<AudioSource>();
        aus.PlayOneShot(SSS[i]);
    }
}

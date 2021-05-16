using DataInfo;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MainMu : MonoBehaviour
{
    public int Choose = 0;




    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == Choose) transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
            else transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.gray;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Choose--;
            if (Choose < 0) Choose = 0;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Choose++;
            if (Choose >= transform.childCount) Choose = transform.childCount - 1;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Choose == 0) PlayNext();
            else if (Choose == 1) UnityEngine.SceneManagement.SceneManager.LoadScene("Stage01");
            else if (Choose == 2) Application.Quit();
        }
    }



    GameData gameData; 
    private string dataPath;//파일저장위치
    public void Initialize()// 저장경로 파일명
    {
        if (!Directory.Exists(Application.persistentDataPath + "SavesDir/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "SavesDir/");
        }
        dataPath = Application.persistentDataPath + "SavesDir/Info.GD";
        Debug.Log(Application.persistentDataPath);
        //Debug.Log(dataPath);
    }
    void PlayNext()
    {
        Initialize();
        gameData = new GameData();
        gameData.AllSavePoint = new int[1000]; gameData.AllSavePoint[0] = 1;
        gameData.AllSavePoint = new int[1000]; gameData.AllSavePoint[1] = 1;
        gameData.MapObj = new int[1000];
        gameData.Dest = new int[1000];

        BinaryFormatter bf = new BinaryFormatter();//바이러니 포맷을위해생성
        FileStream file = File.Create(dataPath);//데이터 저장을 위한 파일 생성

        bf.Serialize(file, gameData);
        file.Close();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Stage01");
    }
}

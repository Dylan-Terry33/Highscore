using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Counter : MonoBehaviour
{
    public Text CounterText;
    public Text HighScoreText;
    private int Count = 0;       
    private SpawnManager spawnManagerScript;
        public int highScore;


    private void Start()
    {
         spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        loadScore();


        Count = 0;
          HighScoreText.text = "HighScore: " + highScore;

    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
    }
     void Update(){
        getHighScore();
     }
   
    public void getHighScore(){
        if(spawnManagerScript.gameActive == false){
            if(Count > highScore){
                highScore = Count;
                saveScore(highScore);
            }
        }
    }



    [System.Serializable]

    public class Savedata{
        public int highScore;
    }
    
    public void saveScore(int highScore){
        Savedata data = new Savedata();
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data,true);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json",json);
        Debug.Log(highScore);

    }

    public void loadScore(){
        string path = Application.persistentDataPath + "/savedata.json";
                    Debug.Log(highScore);

        if(File.Exists(path)){
            Debug.Log("Found");

            string json = File.ReadAllText(path);
            Debug.Log(highScore);
            Savedata data = JsonUtility.FromJson<Savedata>(json);      

            highScore = data.highScore;
        }
        else{            Debug.Log("file not found");

        }
    }
    
}

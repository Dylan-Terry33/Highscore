using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject basketball;
    public float time = 60;
    public Text timer;
    public bool gameActive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       StartCoroutine(spawnDelay());

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
       
    }

    private IEnumerator spawnDelay(){
            while(gameActive){
                yield return new WaitForSeconds(4);
                        float spawnPos = Random.Range(-2.0f, 2.0f );
                        Instantiate(basketball, new Vector3(0, 5, spawnPos) ,basketball.transform.rotation);

            }
    }
   public void Timer(){
        if(time > 0){
            time -= Time.deltaTime;
            timer.text = "Time Left:" +time;
        }
        else{
            gameActive = false;
        }

    }

    
    
}

/* 
add movement of the goal and a spawn randomizer
*/

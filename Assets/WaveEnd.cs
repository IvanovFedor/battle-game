using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnd : MonoBehaviour
{
    public int wave;
    public int waveAll;
    public GameObject[] waveObjects;
    public bool Startuem;
    public bool Started;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Startuem = false;
        wave = 0;
        Invoke("check", 0.1f);  
    }
    private void check()
    {
        if (Started)
        {

            if (GameObject.FindGameObjectsWithTag("Enemy").Length  == 0)
            {
                if (wave < waveAll)
                {
                    wave++;
                    Startuem = true;
                }
                else
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().EnemiesDeath = true;
                }

            }
            if (Startuem)
            {
               
                
                waveObjects[wave - 1].SetActive(true);
                Startuem = false;
            }
            
        }

        Invoke("check", 0.1f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posohScriptUse : MonoBehaviour
{
    public GameObject PlayerBots;
    public GameObject Posoh;
    public GameObject Effect;
    public Transform[] points;
    
    public int RandomPoint;
    public int RandomPoint2;
    public bool isCanUse = true;

    public void BotsSpawn()
    {

        if (isCanUse && Posoh.activeSelf == true)
        {
            RandomPoint = 0;
            RandomPoint2 = 0;
            while (RandomPoint2 == RandomPoint)
            {
                RandomPoint = Random.Range(0, 4);
                
                RandomPoint2 = Random.Range(0, 4);
            }
            
            
            Instantiate(PlayerBots, points[RandomPoint].transform.position, Quaternion.identity);
            Instantiate(PlayerBots, points[RandomPoint2].transform.position, Quaternion.identity);
            
            Instantiate(Effect, points[RandomPoint2].transform.position, Quaternion.identity);
            Instantiate(Effect, points[RandomPoint].transform.position, Quaternion.identity);
           
            isCanUse = false;
            StartCoroutine(TimerIsCaneUse()); 
        }
    }

    IEnumerator TimerIsCaneUse()
    {
        yield return new WaitForSeconds(10f);
        isCanUse = true;
    }
}

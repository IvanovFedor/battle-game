using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posohScriptUse : MonoBehaviour
{
    public GameObject PlayerBots;
    public GameObject Posoh;
    public GameObject Effect;

    public Transform pointSpawn1;
    public Transform pointSpawn2;
    public Transform pointSpawn3;
    public Transform pointSpawn4;

    private bool isCanUse = true;

    public void BotsSpawn()
    {
        if (isCanUse && Posoh.activeSelf == true)
        {
            Instantiate(PlayerBots, pointSpawn1.position, Quaternion.identity);
            Instantiate(PlayerBots, pointSpawn2.position, Quaternion.identity);
            Instantiate(PlayerBots, pointSpawn3.position, Quaternion.identity);
            Instantiate(PlayerBots, pointSpawn4.position, Quaternion.identity);
            Instantiate(Effect, pointSpawn1.position, Quaternion.identity);
            Instantiate(Effect, pointSpawn2.position, Quaternion.identity);
            Instantiate(Effect, pointSpawn3.position, Quaternion.identity);
            Instantiate(Effect, pointSpawn4.position, Quaternion.identity);
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

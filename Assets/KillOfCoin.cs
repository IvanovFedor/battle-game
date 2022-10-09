using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOfCoin : MonoBehaviour
{
    public GameObject Enemy1;


    private void Update()
    {
        if(Enemy1 == null)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 25);
            //тут место для заданий по убийствам
        }
    }
}

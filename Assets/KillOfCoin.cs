using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOfCoin : MonoBehaviour
{
    private bool GiveCoins = true;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MySword" && GiveCoins)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 25);
            GiveCoins = false;
        }
    }
}

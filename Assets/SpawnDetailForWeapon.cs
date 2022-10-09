using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDetailForWeapon : MonoBehaviour
{
    [SerializeField] private string IdPlPrefs;
    [SerializeField] private GameObject ThisgameObject;

    void Start()
    {
        if (PlayerPrefs.GetInt(IdPlPrefs) == 1)
        {
            ThisgameObject.SetActive(false);
        } 
        else if (PlayerPrefs.GetInt(IdPlPrefs) == 0)
        {
            ThisgameObject.SetActive(true);
        }
        print(PlayerPrefs.GetInt(IdPlPrefs));
        print(PlayerPrefs.GetInt("TakedDetAxe"));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInShop : MonoBehaviour
{
    private void Start()
    {
        if(!PlayerPrefs.HasKey("Weapon"))
            PlayerPrefs.SetInt("Weapon", 1);
        if (PlayerPrefs.GetInt("Weapon") == 3)
            PlayerPrefs.SetInt("Weapon", 1);

    }

    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("Weapon", 1);
    }
}

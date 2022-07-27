using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInShop1 : MonoBehaviour
{
    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("Weapon", 2);
    }
}

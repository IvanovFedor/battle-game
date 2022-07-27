using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInShop : MonoBehaviour
{
    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("Weapon", 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInShop3 : MonoBehaviour
{
    public void OnMouseDown()
    {
        PlayerPrefs.SetInt("Weapon", 3);
    }
}

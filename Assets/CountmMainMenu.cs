using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountmMainMenu : MonoBehaviour
{
    public Text text1;

    void Update()
    {
        print($"{PlayerPrefs.GetInt("Coins")}");
        text1.text = $"{PlayerPrefs.GetInt("Coins")}$";
    }
}

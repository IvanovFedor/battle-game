using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMake : MonoBehaviour
{
    [SerializeField] private Text IntDetals1;
    [SerializeField] private Text IntDetals2;
    [SerializeField] private Text IntDetals3;

    [SerializeField] private Button BBuyAxe;
    [SerializeField] private Button BBuyArm;
    [SerializeField] private Button BBuyHunter;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("TakedDetAxe"))
            PlayerPrefs.SetInt("TakedDetAxe", 0);
        if (!PlayerPrefs.HasKey("TakedDetArm"))
            PlayerPrefs.SetInt("TakedDetArm", 0);
        if (!PlayerPrefs.HasKey("TakedDetHunter"))
            PlayerPrefs.SetInt("TakedDetHunter", 0);
    }

    // Update is called once per frame
    void Update()
    {
        IntDetals1.text = $"{PlayerPrefs.GetInt("TakedDetAxe")}/2";
        IntDetals2.text = $"{PlayerPrefs.GetInt("TakedDetArm")}/2";
        IntDetals3.text = $"{PlayerPrefs.GetInt("TakedDetHunter")}/2";

        if(PlayerPrefs.GetInt("TakedDetAxe") == 2)
        {
            BBuyAxe.interactable = true;
        }
        if (PlayerPrefs.GetInt("TakedDetArm") == 2)
        {
            BBuyArm.interactable = true;
        }
        if (PlayerPrefs.GetInt("TakedDetHunter") == 2)
        {
            BBuyHunter.interactable = true;
        }
    }
}

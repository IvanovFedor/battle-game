using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWeaponStart : MonoBehaviour
{
    public GameObject[] Weapon;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("Weapon"))
        {
            case 1:
                Weapon[0].SetActive(true);
                Weapon[1].SetActive(false);
                Weapon[2].SetActive(false);
                Weapon[3].SetActive(false);
                Weapon[4].SetActive(false);
                break;
            case 2:
                Weapon[0].SetActive(false);
                Weapon[1].SetActive(true);
                Weapon[2].SetActive(false);
                Weapon[3].SetActive(false);
                Weapon[4].SetActive(false);
                break;
            case 3:
                Weapon[0].SetActive(false);
                Weapon[1].SetActive(false);
                Weapon[2].SetActive(true);
                Weapon[3].SetActive(false);
                Weapon[4].SetActive(false);
                break;
            case 4:
                Weapon[0].SetActive(false);
                Weapon[1].SetActive(false);
                Weapon[2].SetActive(false);
                Weapon[3].SetActive(true);
                Weapon[4].SetActive(false);
                break;
            case 5:
                Weapon[0].SetActive(false);
                Weapon[1].SetActive(false);
                Weapon[2].SetActive(false);
                Weapon[3].SetActive(false);
                Weapon[4].SetActive(true);
                break;
        }
    }
}

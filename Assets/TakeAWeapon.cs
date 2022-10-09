using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAWeapon : MonoBehaviour
{
    [SerializeField] private string WDID;
    [SerializeField] private GameObject BTakeW;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            BTakeW.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BTakeW.SetActive(false);
        }
    }


    public void TAW()
    {
        switch (WDID)
        {
            case "Axe1Det":
                
                PlayerPrefs.SetInt("TakedDetAxe", PlayerPrefs.GetInt("TakedDetAxe") + 1);
                PlayerPrefs.SetInt("1DetAxeSp", 1);
                print(PlayerPrefs.GetInt("TakedDetAxe"));
                BTakeW.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Axe2Det":
                
                PlayerPrefs.SetInt("TakedDetAxe", PlayerPrefs.GetInt("TakedDetAxe") + 1);
                PlayerPrefs.SetInt("2DetAxeSp", 1);
                BTakeW.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Arm1Det":
                
                PlayerPrefs.SetInt("TakedDetArm", PlayerPrefs.GetInt("TakedDetArm") + 1);
                PlayerPrefs.SetInt("1DetArmSp", 1);
                BTakeW.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Arm2Det":
                
                PlayerPrefs.SetInt("TakedDetArm", PlayerPrefs.GetInt("TakedDetArm") + 1);
                PlayerPrefs.SetInt("2DetArmSp", 1);
                BTakeW.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Huter1Det":
                
                PlayerPrefs.SetInt("TakedDetHunter", PlayerPrefs.GetInt("TakedDetHunter") + 1);
                PlayerPrefs.SetInt("1DetHunterSp", 1);
                BTakeW.SetActive(false);
                gameObject.SetActive(false);
                break;
            case "Huter2Det":
                
                PlayerPrefs.SetInt("TakedDetHunter", PlayerPrefs.GetInt("TakedDetHunter") + 1);
                PlayerPrefs.SetInt("2DetHunterSp", 1);
                BTakeW.SetActive(false);
                gameObject.SetActive(false);
                break;
        }
    }
}

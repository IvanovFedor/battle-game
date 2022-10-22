using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Item;
    [SerializeField] private GameObject DemoItem;
    [SerializeField] private GameObject ErrorTXT;

    [SerializeField] private GameObject ButtonBuy;

    [SerializeField] private string IdWeaponBuy;

    public void buyItem(int Count)
    {
        if (PlayerPrefs.GetInt("Coins") >= Count)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - Count);
            Item.SetActive(true);
            DemoItem.SetActive(false);
            PlayerPrefs.SetInt(IdWeaponBuy, 1);
        }else if(PlayerPrefs.GetInt("Coins") < Count)
        {
            ErrorTXT.SetActive(true);
            StartCoroutine(ErrorTXTFalse());
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
            PlayerPrefs.SetInt("IsBuyAxe", 1);
        if(Input.GetKeyDown(KeyCode.F2))
            PlayerPrefs.SetInt("IsBuyArm", 1);
        if(Input.GetKeyDown(KeyCode.F3))
            PlayerPrefs.SetInt("IsBuyHunter", 1);
        
        if (PlayerPrefs.GetInt(IdWeaponBuy) == 1)
        {
            Item.SetActive(true);
            DemoItem.SetActive(false);
            ButtonBuy.SetActive(false);
        }
    }

    IEnumerator ErrorTXTFalse()
    {
        yield return new WaitForSeconds(1f);
        ErrorTXT.SetActive(false);
    }
}

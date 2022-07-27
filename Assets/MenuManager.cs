using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator ImageButtonPlay1;
    public Animator ImageButtonPlay2;

    public GameObject ShopGameObjects;
    public GameObject MainMenuGameObjects;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Weapon"))
        {
            PlayerPrefs.SetInt("Weapon", 3);
        }
    }

    public void PointerEnterPlay()
    {
        ImageButtonPlay1.SetInteger("MenuPlay", 1);
        ImageButtonPlay2.SetInteger("MenuPlay1", 1);
    }
    public void PointerExitPlay()
    {
        ImageButtonPlay1.SetInteger("MenuPlay", 2);
        ImageButtonPlay2.SetInteger("MenuPlay1", 2);
    }
    public void SetWeapon(int _IdWeapon)
    {
        PlayerPrefs.SetInt("Weapon", _IdWeapon);
    }
    public void GoShop()
    {
        ShopGameObjects.SetActive(true);
        MainMenuGameObjects.SetActive(false);
    }
    public void BackMainMenu()
    {
        ShopGameObjects.SetActive(false);
        MainMenuGameObjects.SetActive(true);
    }

    public void GoFirstLevelDemo(int IdLevel)
    {
        SceneManager.LoadScene(IdLevel);
    }
}

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
    public GameObject CameraMain;

    public Transform PointShop;
    public Transform PointMainMenu;

    bool menu = true;
    bool shop = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Weapon"))
        {
            PlayerPrefs.SetInt("Weapon", 3);
        }
    }
    private void Update()
    {
        if (shop)
        {
            CameraMain.transform.position = Vector3.Lerp(CameraMain.transform.position, PointShop.position, 0.1f);
        }
        if (menu)
        {
            CameraMain.transform.position = Vector3.Lerp(CameraMain.transform.position, PointMainMenu.position, 0.1f);
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
        MainMenuGameObjects.SetActive(false);
        ShopGameObjects.SetActive(true);
        menu = false;
        shop = true;
    }
    public void BackMainMenu()
    {
        MainMenuGameObjects.SetActive(true);
        ShopGameObjects.SetActive(false);
        menu = true;
        shop = false;
    }

    public void GoFirstLevelDemo(int IdLevel)
    {
        SceneManager.LoadScene(IdLevel);
    }

    public void DiscordServer()
    {
        Application.OpenURL("https://discord.gg/Hs69P9bH6w");
    }

    public void YouTubeChanel() 
    { 
        Application.OpenURL("https://www.youtube.com/channel/UCD4gdCcIisrzyRl_T3uQehQ/featured");
    }
}

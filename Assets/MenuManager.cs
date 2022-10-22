using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    public Button[] levelB;

    bool menu = true;
    bool shop = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Weapon"))
        {
            PlayerPrefs.SetInt("Weapon", 3);
        }
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
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

        //Ќужно дл€ того чтобы активировались новые уровни
        switch (PlayerPrefs.GetInt("Level"))
        {
            case 0:
                levelB[0].interactable = true;
                levelB[1].interactable = false;
                levelB[2].interactable = false;
                levelB[3].interactable = false;
                levelB[4].interactable = false;
                levelB[5].interactable = false;
                levelB[6].interactable = false;
                levelB[7].interactable = false;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 1:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = false;
                levelB[3].interactable = false;
                levelB[4].interactable = false;
                levelB[5].interactable = false;
                levelB[6].interactable = false;
                levelB[7].interactable = false;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 2:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = false;
                levelB[4].interactable = false;
                levelB[5].interactable = false;
                levelB[6].interactable = false;
                levelB[7].interactable = false;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 3:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = false;
                levelB[5].interactable = false;
                levelB[6].interactable = false;
                levelB[7].interactable = false;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 4:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = false;
                levelB[6].interactable = false;
                levelB[7].interactable = false;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 5:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = true;
                levelB[6].interactable = false;
                levelB[7].interactable = false;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 6:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = true;
                levelB[6].interactable = true;
                levelB[7].interactable = false;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 7:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = true;
                levelB[6].interactable = true;
                levelB[7].interactable = true;
                levelB[8].interactable = false;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 8:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = true;
                levelB[6].interactable = true;
                levelB[7].interactable = true;
                levelB[8].interactable = true;
                levelB[9].interactable = false;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 9:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = true;
                levelB[6].interactable = true;
                levelB[7].interactable = true;
                levelB[8].interactable = true;
                levelB[9].interactable = true;
                levelB[10].interactable = false;
                levelB[11].interactable = false;
                break;
            case 10:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = true;
                levelB[6].interactable = true;
                levelB[7].interactable = true;
                levelB[8].interactable = true;
                levelB[9].interactable = true;
                levelB[10].interactable = true;
                levelB[11].interactable = false;
                break;
            case 11:
                levelB[0].interactable = true;
                levelB[1].interactable = true;
                levelB[2].interactable = true;
                levelB[3].interactable = true;
                levelB[4].interactable = true;
                levelB[5].interactable = true;
                levelB[6].interactable = true;
                levelB[7].interactable = true;
                levelB[8].interactable = true;
                levelB[9].interactable = true;
                levelB[10].interactable = true;
                levelB[11].interactable = true;
                break;
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
        Application.OpenURL("https://discord.gg/a47pJ3fhTv");
    }

    public void YouTubeChanel() 
    { 
        Application.OpenURL("https://www.youtube.com/channel/UCD4gdCcIisrzyRl_T3uQehQ/featured");
    }
}

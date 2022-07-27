using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchWeaopnsMenu : MonoBehaviour
{
    public GameObject weap1;
    public GameObject weap2;
    public GameObject weap3;
    public GameObject weap4;
    public GameObject weap5;
    public int weap;
    // Start is called before the first frame update
    void Start()
    {
        weap1.SetActive(false);
        weap2.SetActive(false);
        weap3.SetActive(false);
        weap4.SetActive(false);
        weap5.SetActive(false);

    }
    private void FixedUpdate()
    {
        weap = PlayerPrefs.GetInt("Weapon");
        switch (weap)
        {
            case 1:
                weap1.SetActive(true);
                weap2.SetActive(false);
                weap3.SetActive(false);
                weap4.SetActive(false);
                weap5.SetActive(false);
                break;
            case 2:
                weap2.SetActive(true);
                weap1.SetActive(false);
                weap3.SetActive(false);
                weap4.SetActive(false);
                weap5.SetActive(false);
                break;
            case 3:
                weap3.SetActive(true);
                weap4.SetActive(false);
                weap1.SetActive(false);
                weap2.SetActive(false);
                weap5.SetActive(false);
                break;
            case 4:
                weap4.SetActive(true);
                weap1.SetActive(false);
                weap2.SetActive(false);
                weap3.SetActive(false);
                weap5.SetActive(false);
                break;
            case 5:
                weap5.SetActive(true);
                weap1.SetActive(false);
                weap2.SetActive(false);
                weap3.SetActive(false);
                weap4.SetActive(false);
                break;
        }
            
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

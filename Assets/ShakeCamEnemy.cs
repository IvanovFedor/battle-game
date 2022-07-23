using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamEnemy : MonoBehaviour
{
    public bool touch;
    public GameObject WeaponEnemy;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<IdentifyEnemy>())
            {
               
               CameraShake.Shake(0.5f, 0.1f);
               
               Instantiate(WeaponEnemy, other.gameObject.transform.parent.gameObject.transform.Find("HisWeapon").transform.position, other.gameObject.transform.parent.gameObject.transform.Find("HisWeapon").rotation);
               
            }
            
           
           
        }
        else if(other.gameObject.tag == "block")
        {
            touch = true;
        }
        else if (other.gameObject.tag == "Sword")
        {
            CameraShake.Shake(0.5f, 0.1f);
            

        }

    }
    private void OnTriggerExit(Collider other)
    {
        
    }



} 

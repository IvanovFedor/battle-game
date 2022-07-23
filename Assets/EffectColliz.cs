using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectColliz : MonoBehaviour
{
    public GameObject part;
    // Start is called before the first frame update
    void Start()
    {
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("это меч");
        if (collision.gameObject.tag == "Sword")
        {
           
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.Log("Есть точка");
                Instantiate(part, contact.point, Quaternion.identity);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

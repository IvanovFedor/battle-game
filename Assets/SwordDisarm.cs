using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDisarm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (transform.parent.tag != "Enemy")
        {
            Destroy(GetComponent<RayFire.RayfireBlade>());
            Destroy(GetComponent<RayFire.RayfireRigid>());
            gameObject.layer =8;
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

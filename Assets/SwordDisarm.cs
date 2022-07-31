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
        if (transform.parent.tag == "Enemy")
            GetComponent<RayFire.RayfireBlade>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

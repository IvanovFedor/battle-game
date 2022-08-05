using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("dest", 1);
    }
    public void dest()
    {
        if(!transform.parent.GetComponent<IdentifyEnemy>())
        {
            Destroy(gameObject);
        }
        else
        {
            Invoke("dest", 2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTerrainOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ddd",0.4f);
    }
    public void ddd()
    {
        GetComponent<Terrain>().enabled = false;
        GetComponent<TerrainCollider>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

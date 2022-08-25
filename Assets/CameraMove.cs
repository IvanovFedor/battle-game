using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject SpaceShip;
    public Transform SpaceShipTr;

    public Transform TRPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, SpaceShip.transform.position.x, 0.05f), 15f, Mathf.Lerp(transform.position.z, SpaceShip.transform.position.z -2.5f, 0.05f));
    }
}

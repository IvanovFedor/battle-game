using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject SpaceShip;
    public Transform SpaceShipTr;

    public Transform TRPlayer;
    public int IntPlusKPos = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, SpaceShip.transform.position.x, 0.05f), Mathf.Lerp(transform.position.y, SpaceShip.transform.position.y + IntPlusKPos, 10f), Mathf.Lerp(transform.position.z, SpaceShip.transform.position.z -2.5f, 0.05f));
    }
}

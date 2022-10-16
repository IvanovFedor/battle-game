using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject SpaceShip;
    public Transform SpaceShipTr;

    public Transform TRPlayer;
    public int IntPlusKPos = 10;
    public float IntMinusKPosZ = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, SpaceShip.transform.position.x, 0.1f), Mathf.Lerp(transform.position.y, SpaceShip.transform.position.y + IntPlusKPos, 10f), Mathf.Lerp(transform.position.z, SpaceShip.transform.position.z - IntMinusKPosZ, 0.1f));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 destination;
    public float speed;
    private GameObject player;
    public GameObject babah;
    private bool playerInAttackRange;
    public LayerMask WhatIsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if(Vector3.Distance(transform.position,destination) > 0.1f)
        {
            Invoke("boom", Random.Range(5f, 7f));
            destination = new Vector3(player.transform.position.x + Random.Range(-4f, 4f), player.transform.position.y + Random.Range(-1f, 1f), player.transform.position.z + Random.Range(-3f, 3f));

        }
    }
    
    public void boom()
    {
        Instantiate(babah, transform.position, Quaternion.identity);
        
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        
        
        if (Physics.CheckSphere(transform.position, 2, WhatIsPlayer))
         {
            GameObject.Find("GameManager").GetComponent<GameManager>().death = true;
            GameObject.Find("Player").GetComponent<RayFire.RayfireRigid>().Demolish();
        }

        GetComponent<Rigidbody>().AddExplosionForce(5, transform.position, 2);
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, destination) > 1)
        {
          transform.position=  Vector3.Lerp(transform.position,destination,speed*Time.deltaTime);
        }
        else
        {
            return;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeMove : MonoBehaviour
{
    Rigidbody rbAxe;
    public GameObject joistick;
    bool move = false;
    public GameObject Axe;
    public GameObject AxeIdleTransform;

    private bool CanUse = true;
    private bool Vosvrat = false;

    // Start is called before the first frame update
    void Start()
    {
        rbAxe = Axe.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            rbAxe.AddRelativeForce(0f, 8f, 0f);
        }
        if (Vosvrat)
        {
            Axe.transform.position = Vector3.Lerp(Axe.transform.position, AxeIdleTransform.transform.position, 0.01f);
            Axe.transform.rotation = Quaternion.Lerp(Axe.transform.rotation, AxeIdleTransform.transform.rotation, 0.01f);
        }
    }

    public void MoveAxe()
    {
        if(Axe.activeSelf == true && CanUse)
        {
            rbAxe.isKinematic = false;
            Axe.transform.parent = null;
            move = true;
            StartCoroutine(TimerMoveAxe());
            CanUse = false;
        }
        
    }

    IEnumerator TimerMoveAxe()
    {
        yield return new WaitForSeconds(2f);
        Axe.transform.SetParent(gameObject.transform);
        move = false;
        Vosvrat = true;
        rbAxe.isKinematic = true;       
        yield return new WaitForSeconds(0.5f);
        Vosvrat = false;
        CanUse = true;
        StopCoroutine(TimerMoveAxe());
    }
}

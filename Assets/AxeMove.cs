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
            rbAxe.AddRelativeForce(0f, 3f, 0f);
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
        yield return new WaitForSeconds(2.5f);
        Axe.transform.SetParent(gameObject.transform);
        move = false;
        Axe.transform.position =  AxeIdleTransform.transform.position;
        Axe.transform.rotation =  Quaternion.Euler(0, -90, -90);
        rbAxe.isKinematic = true;
        CanUse = true;
        StopCoroutine(TimerMoveAxe());
    }
}

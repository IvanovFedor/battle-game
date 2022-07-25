using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeMove : MonoBehaviour
{
    Rigidbody rbAxe;
    public GameObject joistick;
    bool move = false;
    public GameObject AxeIdleTransform;

    // Start is called before the first frame update
    void Start()
    {
        rbAxe = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            rbAxe.AddRelativeForce(0f, 1f, 0f);
        }
    }

    public void MoveAxe()
    {
        rbAxe.isKinematic = false;
        move = true;
        StartCoroutine(TimerMoveAxe());
        joistick.SetActive(false);
    }

    IEnumerator TimerMoveAxe()
    {
        yield return new WaitForSeconds(2.5f);
        move = false;
        transform.position = Vector3.Lerp(transform.position, AxeIdleTransform.transform.position, 1f);
        joistick.SetActive(true);
        rbAxe.isKinematic = true;
        StopCoroutine(TimerMoveAxe());
    }
}

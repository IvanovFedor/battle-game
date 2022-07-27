using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public Rigidbody rbArrow;

    private void Start()
    {
        StartCoroutine(TimerMove());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rbArrow.AddRelativeForce(-15f, 0f, 0f);
    }

    IEnumerator TimerMove()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    IEnumerator OptimisationArrow()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(OptimisationArrow());
        }
    }
}

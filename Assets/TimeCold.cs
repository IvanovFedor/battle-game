using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCold : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}

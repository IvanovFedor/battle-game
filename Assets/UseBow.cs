using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBow : MonoBehaviour
{

    public GameObject Bow;
    public GameObject Arrow;

    public Transform ArrowSpawnPoint;

    private bool IsCanUse = true;

    public void UsingBow()
    {
        if(Bow.activeSelf == true && IsCanUse)
        {
            Instantiate(Arrow, ArrowSpawnPoint.position, Bow.transform.rotation);
            StartCoroutine(TimerCoolDown());
            IsCanUse = false;
        }
    }

    IEnumerator TimerCoolDown()
    {
        yield return new WaitForSeconds(0.3f);
        IsCanUse = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBamCold : MonoBehaviour
{
    public GameObject ColiderCold;
    public GameObject VolnaOfLed;
    public GameObject SvetOfLed;

    public Transform transformPlayer;


    private bool isCoolDawn = false;
    public void BamCold()
    {
        if (!isCoolDawn && gameObject.activeSelf == true)
        {
            ColiderCold.SetActive(true);
            StartCoroutine(BamTime());
            isCoolDawn = true;
        }
    }
    IEnumerator BamTime()
    {
        Instantiate(SvetOfLed, transformPlayer.position, Quaternion.identity);
        Instantiate(VolnaOfLed, transformPlayer.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ColiderCold.SetActive(false);
        yield return new WaitForSeconds(5f);
        isCoolDawn = false;
        StopCoroutine(BamTime());
    }
}

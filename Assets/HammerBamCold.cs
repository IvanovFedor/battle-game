using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBamCold : MonoBehaviour
{
    public GameObject ColiderCold;
    public GameObject VolnaOfLed;
    public GameObject SvetOfLed;
    public GameObject joistick;
    public void BamCold()
    {
        ColiderCold.SetActive(true);
        Instantiate(SvetOfLed, transform.position, Quaternion.identity);
        Instantiate(VolnaOfLed, transform.position, Quaternion.identity);
        StartCoroutine(BamTime());
        joistick.SetActive(false);
    }
    IEnumerator BamTime()
    {
        yield return new WaitForSeconds(2f);
        ColiderCold.SetActive(false);
        yield return new WaitForSeconds(5f);
        joistick.SetActive(true);
    }
}

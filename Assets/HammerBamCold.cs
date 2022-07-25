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
        StartCoroutine(BamTime());
        joistick.SetActive(false);
    }
    IEnumerator BamTime()
    {
        SvetOfLed.SetActive(true);
        VolnaOfLed.SetActive(true);
        yield return new WaitForSeconds(2f);
        ColiderCold.SetActive(false);
        yield return new WaitForSeconds(5f);
        SvetOfLed.SetActive(false);
        VolnaOfLed.SetActive(false);
        joistick.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBamCold : MonoBehaviour
{
    public GameObject ColiderCold;
    public void BamCold()
    {
        ColiderCold.SetActive(true);
        StartCoroutine(BamTime());
    }
    IEnumerator BamTime()
    {
        yield return new WaitForSeconds(2f);
        ColiderCold.SetActive(false);
    }
}

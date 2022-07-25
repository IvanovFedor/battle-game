using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCold : MonoBehaviour
{
    public EnemyAi enemyAiScript;
    public GameObject CubeOfLed;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BamColdSone")
        {
            Instantiate(CubeOfLed, transform.position, Quaternion.identity);
            enemyAiScript.enabled = false;
            StartCoroutine(BamCold());
        }
    }

    IEnumerator BamCold()
    {
        yield return new WaitForSeconds(4f);
        enemyAiScript.enabled = true;
    }
}

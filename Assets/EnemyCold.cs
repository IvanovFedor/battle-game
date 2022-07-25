using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCold : MonoBehaviour
{
    public EnemyAi enemyAiScript;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BamColdSone")
        {
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

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
            CubeOfLed.SetActive(true);
            enemyAiScript.enabled = false;
            CubeOfLed.transform.parent = null;
            StartCoroutine(BamCold());
        }
    }

    IEnumerator BamCold()
    {
        yield return new WaitForSeconds(5f);
        CubeOfLed.transform.SetParent(gameObject.transform);
        CubeOfLed.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); 
        enemyAiScript.enabled = true;
        CubeOfLed.SetActive(false);
    }
}

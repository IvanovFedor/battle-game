using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CheckEnemies", 1);
    }
    private void CheckEnemies()
    {
        GameObject[] massivEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (massivEnemy.Length == 0)
        {
            Debug.Log("врагов нету");
        }
        Invoke("CheckEnemies", 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI[] texts;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Player"))
        {
            
            panel.gameObject.SetActive(true);
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, Mathf.Lerp(panel.color.a, 1, 1f * Time.deltaTime));
            foreach (var item in texts)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, Mathf.Lerp(item.color.a, 1, 1f * Time.deltaTime));
            }
        }
    }
    private void FixedUpdate()
    {
        

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}

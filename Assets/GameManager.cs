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
    public TextMeshProUGUI[] texts2;
    public Image panel2;
    public bool death;
    public bool EnemiesDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Player") || death)
        {
            
            panel.gameObject.SetActive(true);
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, Mathf.Lerp(panel.color.a, 1, 1f * Time.deltaTime));
            foreach (var item in texts)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, Mathf.Lerp(item.color.a, 1, 1f * Time.deltaTime));
            }

        }
        
        if (EnemiesDeath)
        {
            panel2.gameObject.SetActive(true);
            panel2.color = new Color(panel2.color.r, panel2.color.g, panel2.color.b, Mathf.Lerp(panel2.color.a, 1, 1f * Time.deltaTime));
            foreach (var item in texts2)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, Mathf.Lerp(item.color.a, 1, 1f * Time.deltaTime));
            }
            if(SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex <= PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.GetInt("Level");
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
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

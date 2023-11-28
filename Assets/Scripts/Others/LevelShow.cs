using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelShow : MonoBehaviour
{
    Text text;
    float countDown1 = 1f;
    float countDown2 = 2f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowText();
    }

    public void ShowText()
    {
        countDown1 -= Time.deltaTime;
        if (countDown1 <= 0)
        {
            text.text = SceneManager.GetActiveScene().name;
            countDown2 -= Time.deltaTime;   
            if(countDown2 < 0)
            {
                gameObject.SetActive(false);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCotunaScene : MonoBehaviour
{
    [SerializeField] LoadSceneAsync loadScene;
    float countDown = 2f;
    bool changeScene = false;
  private void Update()
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && changeScene == false)
        {
            loadScene.LoadSceneInSync("Interface");
            changeScene = true;
        }
    }
}

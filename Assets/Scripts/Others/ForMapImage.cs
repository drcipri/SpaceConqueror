using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForMapImage : MonoBehaviour
{
    [SerializeField] ManageScene manageScene;
    [SerializeField] Image image;
    [SerializeField] Text text;
    [SerializeField] int cleared = 10;
    [SerializeField] Image nextMapImage;
    private void Start()
    {
        
        if(manageScene.GetLevelsCleared() >= cleared)
        {
            text.text = "Cleared !";
            if (nextMapImage != null)
            {
                nextMapImage.color = Color.white;
            }
        }
        
    }
    private void Update()
    {
        gameObject.GetComponent<Image>().color = image.color;
    }
}

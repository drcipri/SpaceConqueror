using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectRatio : MonoBehaviour
{

    float cameraHeight = 0f;//for performance


    private void Update()
    {
        GetAspectRatio();
    }




    private void GetAspectRatio()
    {
        

        if (cameraHeight != Camera.main.orthographicSize * 2f)
        {
            //Get Screen height and width
            float screenHeight = Screen.height;
            float screenWidth = Screen.width;
            //calculate aspect
            float deviceScreenAspect = screenWidth / screenHeight;

            //calulate camera Height and width
            cameraHeight = Camera.main.orthographicSize * 2f;
            float cameraWidth = cameraHeight * deviceScreenAspect;

            transform.localScale = new Vector3(cameraWidth, cameraHeight, 1);
            
        }   

        
        
    }

 

 
}

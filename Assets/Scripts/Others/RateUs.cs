using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RateUs : MonoBehaviour
{
#if UNITY_ANDROID
    string url = "https://www.google.com/?hl=ro";
#elif UNITY_IOS
    string url = "https://www.google.com/?hl=ro";
#endif
    Button thisButton;

    private void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OpenURL);
        
    }

    private void OpenURL()
    {
        Application.OpenURL(url);
    }



}

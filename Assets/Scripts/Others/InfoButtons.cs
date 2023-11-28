using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButtons : MonoBehaviour
{
    [SerializeField]GameObject content1;
    [SerializeField]GameObject content2;
    [SerializeField]Text titleText;

    // Start is called before the first frame update
    

    public void ChangeContentOne()
    {
        content2.SetActive(false);
        content1.SetActive(true);
        titleText.text = "Info";

    }
    public void ChangeContetTwo()
    {
        content2.SetActive(true);
        content1.SetActive(false);
        titleText.text = "Credits";
    }
}

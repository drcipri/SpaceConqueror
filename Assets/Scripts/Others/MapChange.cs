using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChange : MonoBehaviour
{
   
    [SerializeField] GameObject bg2;
    [SerializeField] GameObject bg3;
    [SerializeField] GameObject bg4;
    [SerializeField] SFX sfx;
    float volume = 10f;






    public void Forward()
    {
        if(bg2.activeSelf == false)
        {
            AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
            bg2.SetActive(true);
        }
        else if (bg3.activeSelf == false)
        {
            AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
            bg3.SetActive(true);
        }
        else if (bg4.activeSelf == false)
        {
            AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
            bg4.SetActive(true);
        }
    }
    public void BackWard()
    {
        if(bg4.activeSelf  == true)
        {
            AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
            bg4.SetActive(false);
        }
        else if (bg3.activeSelf == true)
        {
            AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
            bg3.SetActive(false);
        }
        else if (bg2.activeSelf == true)
        {
            AudioSource.PlayClipAtPoint(sfx.GeneralButton(), Camera.main.transform.position, volume);
            bg2.SetActive(false);
        }
    }

}

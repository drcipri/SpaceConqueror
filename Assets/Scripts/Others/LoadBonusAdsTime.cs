using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBonusAdsTime : MonoBehaviour
{

    [SerializeField]TimeForBonus timeUntilAds;


    private void Awake()
    {
        SingleTon();
    }


    public void SingleTon()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    private void Update()
    {
        StartTimer();
       
    }


    public void StartTimer()
    {
        if(timeUntilAds.GetAdBonusTime() >= 0.1f)
        {
            timeUntilAds.adBonusTime -= Time.unscaledDeltaTime;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager2 : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "4560288";
#elif UNITY_ANDROID
    private string gameId = "4560289";
#endif

    [SerializeField] GameObject adsInfoWindow;
    [SerializeField] Text adsInfoWindowText;
    [SerializeField] GameObject watchAdWindow;
    [SerializeField] RestartWave restartWave;
    Button thisButton;



    [SerializeField] bool testMode = true;
    public const string myPlacementId = "Reward_Video";

    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    private void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.interactable = Advertisement.IsReady(myPlacementId);
        if (thisButton)
        {
            thisButton.onClick.AddListener(ShowRewardedVideo);
        }

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId);
    }

    public void OnUnityAdsDidError(string message)
    {
        adsInfoWindowText.text = $"Unity ads error: {message}";
        adsInfoWindow.SetActive(true);
        watchAdWindow.SetActive(false);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            
            watchAdWindow.SetActive(false);
            restartWave.RestartWaveForWatchingAds();
            

        }
        else if (showResult == ShowResult.Skipped)
        {
            adsInfoWindowText.text = $"Ad video was skipped -- Reward Failed !";
            adsInfoWindow.SetActive(true);
            watchAdWindow.SetActive(false);
        }
        else if (showResult == ShowResult.Failed)
        {
            adsInfoWindowText.text = $"Ad video failed -- Reward Failed !";
            adsInfoWindow.SetActive(true);
            watchAdWindow.SetActive(false);
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //ads start
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            thisButton.interactable = true;
        }
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);

    }

    
}

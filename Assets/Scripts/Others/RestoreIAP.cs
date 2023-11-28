using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreIAP : MonoBehaviour
{
    [SerializeField] FreePlay freePlay;

    public void RestorePurchasing()
    {
        freePlay.SetFreePlay(true);
        SaveSystem.SaveFreePlay(freePlay);
    }

}

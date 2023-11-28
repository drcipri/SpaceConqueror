using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FreePlay")]
public class FreePlay : ScriptableObject
{
    [SerializeField] bool freePlay = false;

    public void SetFreePlay(bool freePlay)
    {
        this.freePlay = freePlay;
    }
    public bool GetFreePlay()
    {
        return freePlay;
    }

    public void LoadFreePlay(bool freePlay)
    {
        this.freePlay = freePlay;
    }
}

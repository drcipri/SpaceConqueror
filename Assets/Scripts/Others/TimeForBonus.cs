using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TimeForBonus")]
public class TimeForBonus : ScriptableObject
{
    public float adBonusTime = 90f;
    const float resetBonusTime = 90f;



   
    public void ResetTime()
    {
        adBonusTime = resetBonusTime;
    }
   
    public float GetAdBonusTime()
    {
        return this.adBonusTime;
    }
}

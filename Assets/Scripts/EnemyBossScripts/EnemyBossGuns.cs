using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossGuns : MonoBehaviour
{

    [SerializeField]SFX sounds;
    [SerializeField][Range(0,1)] float soundVolume;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(sounds.GetBossMissileSound(), Camera.main.transform.position, soundVolume);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBeamLaser : MonoBehaviour
{
    GameObject getPlayer;
    Player player;
    PlayerStatus playerStatus;
    private void Awake()
    {
         getPlayer = GameObject.FindGameObjectWithTag("ThePlayer");
    }
    private void Start()
    {
        playerStatus = getPlayer.GetComponent<PlayerStatus>();
        player = getPlayer.GetComponent<Player>();
    }
    void Update()
    {
        if (player.GetLaser().name != "PlayerLaser7")
        {
            Destroy(gameObject);
        }
        if (playerStatus.GetPlayerHealth() <= 0f)
        {
            Destroy(gameObject);
        }
    }
}

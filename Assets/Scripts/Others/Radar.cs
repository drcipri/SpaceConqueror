using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] float radarSpeed = 1500f;
    GameObject enemy;
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("ThePlayer").GetComponent<Player>();
    }
    void Update()
    {
        
        FindEnemy();
        Boundaries();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SmallEnemy")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Boundaries()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void FindEnemy()
    {
        if (player.GetIWonLevel() == false)
        {
            if (enemy == null)
            {
                enemy = GameObject.FindGameObjectWithTag("SmallEnemy");
            }
            else if (enemy != null)
            {
                var moveThisFrame = radarSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, moveThisFrame);
            }
        }
    }
}

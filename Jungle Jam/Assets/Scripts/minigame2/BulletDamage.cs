using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public Player_Health playerHealth;
    public GameScoreBoard GameScoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            
            playerHealth.TakeDamage(5);
            GameScoreBoard.miniGamePlayerScore += 20;

        }
        Debug.Log("touch");
    }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketDamage : MonoBehaviour
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
        if (collision.gameObject.tag == ("bananaBomb"))
        {

            playerHealth.TakeDamage(20);


        }
        if (collision.gameObject.tag == ("banana"))
        {

            GameScoreBoard.miniGamePlayerScore += 20;


        }
        if (collision.gameObject.tag == ("bananaCombo"))
        {

            GameScoreBoard.miniGamePlayerScore += 60;


        }
    }
}

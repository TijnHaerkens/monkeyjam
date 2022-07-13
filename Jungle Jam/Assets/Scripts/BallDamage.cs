using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    public Player_Health playerHealth;
    public Collider2D collider2D;
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
        if (collision.gameObject.tag == ("Ball"))
        {
            BallDamagePlayer();


        }

    }
    public void BallDamagePlayer()
    {
        playerHealth.TakeDamage(10);
        StartCoroutine(PlayerHurt());
        IEnumerator PlayerHurt()
        {

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(1f);

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

    }
}

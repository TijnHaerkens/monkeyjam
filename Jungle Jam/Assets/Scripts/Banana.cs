using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private Vector2 screenBounds;
    private float randomSpeed;
    private float bananaScale;
    bool caughtBanana;
    public GameController gameController;

    public LayerMask groundLayer;


    public ParticleSystem bananaExplosion;
    // Start is called before the first frame update
    void Start()
    {
        

        if (gameObject.CompareTag("bananaCombo"))
        {
            randomSpeed = Random.Range(0.2f, 0.5f);
        }else
        {
            randomSpeed = Random.Range(0.005f, 0.2f);
        }




        rb2d.gravityScale = randomSpeed;
        transform.rotation = Quaternion.Euler(Vector3.forward * Random.Range(0, 359));

        bananaScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
//Rotation relative to the speed
        if (gameObject.CompareTag("bananaCombo"))
        {
            transform.Rotate(Vector3.forward * randomSpeed * 1);
        }
        else
        {
            transform.Rotate(Vector3.forward * randomSpeed * 4);
        }

        if (gameController.gameEndDone == true)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == ("basket") && gameObject.CompareTag("banana") && caughtBanana == false)
        {
            CatchAnimation();
            gameObject.GetComponent<Transform>().SetParent(collision.gameObject.transform);
            gameObject.transform.localPosition = Vector3.zero + new Vector3(0.0f, 2.1f, 0.0f);
            caughtBanana = true;
        }


        else if (collision.gameObject.tag == ("basket") && gameObject.CompareTag("bananaBomb") && caughtBanana == false)
        {
            CatchAnimation();
            gameObject.GetComponent<Transform>().SetParent(collision.gameObject.transform);
            gameObject.transform.localPosition = Vector3.zero + new Vector3(0.0f, 2.1f, 0.0f);
            bananaExplosion.Play();
            caughtBanana = true;
        }

        else if (collision.gameObject.tag == ("basket") && gameObject.CompareTag("bananaCombo") && caughtBanana == false)
        {
            CatchAnimation();
            gameObject.GetComponent<Transform>().SetParent(collision.gameObject.transform);
            gameObject.transform.localPosition = Vector3.zero + new Vector3(0.0f, 2.1f, 0.0f);
            caughtBanana = true;
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

    }
    public void CatchAnimation()
    {
        Destroy(GetComponent<Rigidbody2D>());
        StartCoroutine(scaleBananaSmaller());
        

        IEnumerator scaleBananaSmaller()
        {
            yield return new WaitForSeconds(0.05f);
            transform.localScale = new Vector3(bananaScale -= 0.01f, bananaScale -= 0.01f, bananaScale -= 0.01f);
            //Kill banana after the animation
            if (bananaScale <= 0)
            {
                Destroy(gameObject);
            }
            StartCoroutine(scaleBananaSmaller());
        }

    }




}


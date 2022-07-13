using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana_bg : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private Vector2 screenBounds;
    private float randomSpeed;
    public float bananaScale;
    private float bananaScaleGlobal;


    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        

        if (gameObject.CompareTag("bananaCombo"))
        {
            randomSpeed = Random.Range(0.2f, 0.5f);
        }else
        {
            randomSpeed = Random.Range(0.05f, 0.7f);
        }




        rb2d.gravityScale = randomSpeed;
        transform.rotation = Quaternion.Euler(Vector3.forward * Random.Range(0, 359));

        bananaScaleGlobal = bananaScale * Random.Range(0.2f, 1.5f);
        this.transform.localScale = new Vector3(bananaScaleGlobal, bananaScaleGlobal, bananaScaleGlobal);
        
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

    }


}


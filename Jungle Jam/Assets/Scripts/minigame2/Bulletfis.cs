using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletfis : MonoBehaviour
{

    Rigidbody2D Body;
    public Vector2 direction;
    public float Force = 25;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.right;
        Destroy(gameObject, 5f);
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Body.AddForce(direction * Force, ForceMode2D.Force);
        Debug.Log(direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("MonkeyBulletPoint"))
        {

            Destroy(gameObject);


        }
    }
}

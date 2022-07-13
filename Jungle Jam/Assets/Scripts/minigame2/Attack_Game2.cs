using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Game2 : MonoBehaviour
{
    public Vector2 direction;
    private float randomSpeed;
    public float Force;
    public Rigidbody2D Body;
    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(0.05f, 0.2f);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Body.AddForce(direction * Force, ForceMode2D.Force);
        transform.Translate(direction * Force * Time.deltaTime);
        
        Debug.Log(direction);
    }
}

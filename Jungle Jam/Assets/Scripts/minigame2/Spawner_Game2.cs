using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Game2 : MonoBehaviour
{
    public GameObject shootProjectile;
    public int spawnLocation;
    public GameObject Projectile;
    public GameObject Spawnplace1;
    public GameObject Spawnplace2;
    public GameObject spawner;
    public GameObject block1;
    public GameObject block2;
    public float nextActionTime = 0.0f;
    public float period = 1f;
    public float on;
    // Start is called before the first frame update
    void Start()
    {
        block1.gameObject.SetActive(false);
        block2.gameObject.SetActive(false);

        Debug.Log("spawnLaction " + spawnLocation);

        
    }

    // Update is called once per frame

    void Update()
    {
       
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            
            period = Mathf.Clamp(period, 0.4f, 5f);
            //nextActionTime += period;
            spawnLocation = Random.Range(1, 3);
            Shoot();
            

        }

        void Shoot()
        {
            on = Random.Range(1, 3);
            switch (spawnLocation)
            {
                case 1:

                    shootProjectile = Instantiate(Projectile, Spawnplace1.transform.position, transform.rotation);
                    shootProjectile.GetComponent<Attack_Game2>().direction = Vector2.right;
                   shootProjectile.GetComponentInChildren<Roll>().fdirection = -1f;
                    break;

                case 2:
                    shootProjectile = Instantiate(Projectile, Spawnplace2.transform.position, transform.rotation);
                    shootProjectile.GetComponent<Attack_Game2>().direction = Vector2.left;
                     shootProjectile.GetComponentInChildren<Roll>().fdirection = 1f;
                    break;

                

            }
            
            switch (on)
            {
                case 1:
                    block1.gameObject.SetActive(false);
                    block2.gameObject.SetActive(true);
                    break;

                case 2:
                    
                    block1.gameObject.SetActive(true);
                    block2.gameObject.SetActive(false);
                    break;
            }
        }
    }
    
}

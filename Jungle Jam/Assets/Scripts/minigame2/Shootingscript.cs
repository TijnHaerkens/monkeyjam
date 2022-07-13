using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingscript : MonoBehaviour
{
    public bool direction;
    public GameObject shootProjectile;
    public Bulletfis bulletFis;
    
    public Vector3 offset;
    [SerializeField] KeyCode ShootKey = KeyCode.R;
    [SerializeField] KeyCode akey = KeyCode.A;
    [SerializeField] KeyCode dkey = KeyCode.D;

    private bool isInCoolDown = false;

    // Start is called before the first frame update


    void Start()
    {
        direction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(akey))
        {
            shootProjectile.GetComponent<Bulletfis>().direction = Vector2.left;
            direction = false;
        }
        if (Input.GetKey(dkey))
        {
            direction = true;
            shootProjectile.GetComponent<Bulletfis>().direction = Vector2.left;
        }
        if (Input.GetKeyDown(ShootKey))
        {
            if (!isInCoolDown)
            {
                

                Invoke("ResetCooldown", 0.3f);
                isInCoolDown = true;

                Instantiate(shootProjectile, transform.position + offset, transform.rotation);
            }
        }

    }
    private void ResetCooldown()
    {
        isInCoolDown = false;
    }
}
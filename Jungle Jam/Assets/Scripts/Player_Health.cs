using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health: MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    public Health_Face_Hud healthFace;
    // Start is called before the first frame update
    void Start()
    {
        /*currentHealth = maxHealth;*/

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeDamage(20);
        }*/
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        /*healthBar.SetHealth(currentHealth);*/
        healthFace.PlayerHurtImage();
    }
}

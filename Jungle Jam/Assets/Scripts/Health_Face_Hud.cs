using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Face_Hud : MonoBehaviour
{
    public Sprite playerIdle;
    public Sprite playerHurt;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = playerIdle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerIdleImage()
    {
        this.gameObject.GetComponent<Image>().sprite = playerIdle;
    }
    public void PlayerHurtImage()
    {
        this.gameObject.GetComponent<Image>().sprite = playerHurt;


        StartCoroutine(PlayerHurtImageTimer());
        IEnumerator PlayerHurtImageTimer()
        {
            yield return new WaitForSeconds(1f);
            PlayerIdleImage();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Button1;
    public float menuchoose = 1;
    public LevelLoader levelLoader;
    public StaticValue staticValue;
    [SerializeField] KeyCode Startkey = KeyCode.R;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            menuchoose = menuchoose - 1;
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            menuchoose = menuchoose + 1;
            
        }
        switch (menuchoose)
        {
            case 1:
                Button1.gameObject.transform.position = new Vector3(-1.35f, 1.93f, 0);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    staticValue.ClearValues();
                    levelLoader.RandomMiniGame();
                }
                break;
            case 2:
                Button1.gameObject.transform.position = new Vector3(-1.0793f, 0.44f, 0);
                if (Input.GetKeyDown(KeyCode.R))
                {

                }
                break;
            case 3:
                Button1.gameObject.transform.position = new Vector3(-1.0793f, -0.45f, 0);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Application.Quit();
                }
                break;
        }
        if (menuchoose >= 4)
        {
            menuchoose = 1;
        }
        if (menuchoose <= 0)
        {
            menuchoose = 1;
        }
    }

}

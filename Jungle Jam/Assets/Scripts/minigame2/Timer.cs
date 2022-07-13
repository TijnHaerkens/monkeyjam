using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Spawner_Game2 spawner;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DisableScript");
    }

    IEnumerator DisableScript()
    {
        spawner.enabled = false;

        yield return new WaitForSeconds(3f);

        spawner.enabled = true;
    }
}
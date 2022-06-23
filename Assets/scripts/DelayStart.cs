using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStart : MonoBehaviour
{
    public GameObject countDown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartDelay");
    }


    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

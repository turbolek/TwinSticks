using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{

    public bool recording = true;
    bool paused = false;

    float fixedDeltaTime;


    private void Start()
    {
        PlayerPrefsManager.UnlockLevel(0);
        Debug.Log("Level 0 unlocked? : " + PlayerPrefsManager.IsLevelUnlocked(0));
        Debug.Log("Level 1 unlocked? : " + PlayerPrefsManager.IsLevelUnlocked(1));

        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        recording = !CrossPlatformInputManager.GetButton("Fire1");
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!paused) Pause(); else Resume();
        }

    }

    private void Pause()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
        paused = true;

    }

    void Resume()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
        paused = false;
    }
}

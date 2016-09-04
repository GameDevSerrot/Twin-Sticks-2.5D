using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private bool isPaused = false;
    private float fixedDeltaTime;        

	// Use this for initialization
	void Start () {
        // PlayerPrefsManager.UnlockLevel(2);
        // print(PlayerPrefsManager.IsLevelUnlocked(1));
        fixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {

        if (CrossPlatformInputManager.GetButton ("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        } else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }

       // print("update");
	}

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PauseControl : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool IsPaused;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }
        
        PauseMenu.SetActive(IsPaused);
        Time.timeScale = IsPaused ? 0.0f : 1.0f;
    }
    public void ResumeButton()
    {
        IsPaused = false;
    }

    public void ExitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

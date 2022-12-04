using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PauseControl : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject HUD;
    public bool IsPaused;
    public Volume Vol;
    private DepthOfField dof;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        IsPaused = false;
        Vol.profile.TryGet(out dof);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }

        dof.focalLength.value = IsPaused ? 100f : 0f; 
        PauseMenu.SetActive(IsPaused);
        HUD.SetActive(!IsPaused);
        Time.timeScale = IsPaused ? 0.0f : 1.0f;
    }
    public void ResumeButton()
    {
        IsPaused = false;
    }

    public void ExitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        dof.focalLength.value = 0f;
    }
}

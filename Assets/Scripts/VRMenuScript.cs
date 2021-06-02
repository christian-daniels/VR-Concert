using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VRMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameManager gameManager;
    public AudioSource audioSource;
    public AudioSource dontSource;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        // Time.timeScale = 1f;
        GameIsPaused = false;
        // Cursor.lockState = CursorLockMode.Locked;
        if (!gameManager.getSongSwitch())
            audioSource.Play();
        else{
            dontSource.Play();
        }
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        // Time.timeScale = 0f;
        GameIsPaused = true;
//         if(Cursor.lockState != CursorLockMode.None){
// Cursor.lockState = CursorLockMode.None;
//         }
        if (!gameManager.getSongSwitch())
            audioSource.Pause();
        else{
            dontSource.Pause();
        }
    }
    public void LoadMenu(){
        Debug.Log("Loading menu");
        SceneManager.LoadScene(0);
    }
    public void QuitGame(){
        Debug.Log("Quitting game");
        Application.Quit();
    }
}

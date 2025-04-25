using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject controlsMenu;

    public bool flipAvant;
    public bool menuIdle;
    public bool settings;
    public bool controls;
    public bool menu;
    public bool flipArriere;

    public Animator animator;

    void Start()
    {
        
    }

    public void Play()
    {
        Debug.Log("Jeu lancé");
        //SceneManager.LoadScene("GameScene"); // remplacer par nom de level1
    }

    public void FlipPages()
    {
        flipAvant = true;
        flipArriere = false;
        animator.SetBool("FlipPages", flipAvant);
    }

    public void UnflipPages()
    {
        flipArriere = true;
        flipAvant = false;
        animator.SetBool("UnflipPages", flipArriere);
    }

    public void ButtonSettings()
    {
        Debug.Log("Page settings");
        mainMenu.gameObject.SetActive(false);
        settings=true;
        controls=false;
        FlipPages();
        menuIdle = false;
        animator.SetBool("idle", menuIdle);
        menu = false;
        animator.SetBool("UnflipPages", menu);

    }

    public void Settings()
    {   
        if (settings&&!controls)
        {
            flipAvant = false;
            animator.SetBool("FlipPages", flipAvant);
            menuIdle = true;
            animator.SetBool("idle", menuIdle);
            Debug.Log("settings");
            settingsMenu.gameObject.SetActive(true);

        }
    }

     public void ButtonControls()
    {
        Debug.Log("Page controls");
        settingsMenu.gameObject.SetActive(false);
        controls=true;
        FlipPages();
        menuIdle = false;
        animator.SetBool("idle", menuIdle); 
        settings=false;
    }

    public void Controls()
    {   
        if (controls && !settings)
        {
        
        flipAvant = false;
        animator.SetBool("FlipPages", flipAvant);
        menuIdle = true;
        animator.SetBool("idle", menuIdle);
        Debug.Log("controls");
        controlsMenu.gameObject.SetActive(true);
        }
    }
     public void ButtonBackToSettings()
    {
        Debug.Log("back to settings");
        controls=false;
        menuIdle = false;
        UnflipPages();
        settings = true;
        menu = false;
        animator.SetBool("idle", menuIdle);
        controlsMenu.gameObject.SetActive(false);
    }

    public void BackToSettings()
    {
        if (!menu && settings)
       {
        Debug.Log("menu settings active");
        settingsMenu.gameObject.SetActive(true);
        flipArriere = false;
        animator.SetBool("UnflipPages", flipArriere);
        settings = true;
        animator.SetBool("idle", menu);
       }
    }

    public void ButtonBackToMenu()
    {
        Debug.Log("back to menu");

        UnflipPages();
        menuIdle = false;
        animator.SetBool("idle", menuIdle);
        settingsMenu.gameObject.SetActive(false);
        settings=false;
        menu=true;
    }

    public void BackToMenu()
    { if (!settings && menu)
     {
        Debug.Log("main menu active");
        mainMenu.gameObject.SetActive(true);
        flipArriere = false;
        animator.SetBool("UnflipPages", flipArriere);
        animator.SetBool("idle", menu);
     }
    }

    public void Quit()
    {
        Debug.Log("Quit");

        Application.Quit();
    }
}

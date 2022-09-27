using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playPauseManager : MonoBehaviour
{
    Animator ani;
    public bool toggleBool;
    public Canvas mainCanvas;
    public GameObject gamePanel;
    public GameObject pausePanel;
    public AnimationClip clip1;
    public AnimationClip clip2;
    private UI userI;


    public pauseTextManager textManager;
    public retryButtonManager retryManager;

    // Start is called before the first frame update
    void Start() {
        ani = this.GetComponent<Animator>();
        userI = mainCanvas.GetComponent<UI>();
    }

    void Update() {
    }

    public void toggle() {
        // Manages states based on bool and flips it when called
        if (StateManager.instance.playerDead)
        {
            return;
            //wont let you pause or unpause when player is dead
        }
        if (toggleBool) {
            pause();

            // Manager Controls
            textManager.slideIn();
            retryManager.slideIn();
        } else {
            resume();

            // Manager Controls
            textManager.slideOut();
            retryManager.slideOut();
        }

    }

    
    // Pause and resume methods replace the functions of the onClick() functions added directly to the legacy buttons.
    // Adding code in the respective sections should be straightforward and hopefully doesnt break stuff
    public void pause() {
        // Pause code
        toggleBool = false;
        ani.Play(clip1.name);
        userI.Pause();
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void resume() {
        // Resume code
        toggleBool = true;
        ani.Play(clip2.name);
        userI.Resume();
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
    }
}

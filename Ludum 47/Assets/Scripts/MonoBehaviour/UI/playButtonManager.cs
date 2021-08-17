using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonManager : MonoBehaviour
{
    
    public bool doStartScreen = true;
    public UI ui;
    public GameObject playPause;
    // Start is called before the first frame update
    void Start()
    {

        if (doStartScreen) {
            playPause.SetActive(false);
            ui.Pause();
        } else {
            this.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSequence() {
        ui.Resume();
        playPause.SetActive(true);
        
    }

    public void destroyButton() {
        this.gameObject.SetActive(false);
    }

}

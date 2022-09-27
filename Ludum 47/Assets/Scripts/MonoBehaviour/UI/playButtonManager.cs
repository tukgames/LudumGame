using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playButtonManager : MonoBehaviour
{
    
    public bool doStartScreen = true;
    public UI ui;
    public GameObject playPause;
    public Image image;

    public static playButtonManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    public void StartScreen()
    {

        //if (doStartScreen) {
        image.enabled = true;
            playPause.SetActive(false);
            ui.Pause();
       /* } else {
            this.gameObject.SetActive(false);
        }*/

    }

    public void NoStartScreen()
    {
        image.enabled = false;
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

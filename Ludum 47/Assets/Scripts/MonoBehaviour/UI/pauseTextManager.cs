using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseTextManager : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Methods called by the playPauseManager to manage the two main animation states.
    // The "substates" / inbetween states are found in the animation tab within unity.
    public void slideIn() {
        ani.Play("SlideVisible");
    }

    public void slideOut() {
        ani.Play("SlideHide");
    }

}

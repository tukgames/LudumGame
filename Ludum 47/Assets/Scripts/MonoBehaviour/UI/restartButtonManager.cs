using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartButtonManager : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start() {
        ani = this.GetComponent<Animator>();
    }

    private void OnEnable() {
        ani = this.GetComponent<Animator>();
        ani.Play("RestartSlideIn");
    }
    // Update is called once per frame
    void Update() {

    }
    // The "substates" / inbetween states are found in the animation tab within unity.
    public void slideIn() {
        ani.Play("RestartSlideIn");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAnimationManager : MonoBehaviour
{
    public bool opened;
    Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        opened = false;
    }


    public void closeAnim() {
        anim.Play("DashClose");
        opened = false;
    }

    public void openAnim() {
        anim.Play("DashOpen");
        opened = true;
    }
}

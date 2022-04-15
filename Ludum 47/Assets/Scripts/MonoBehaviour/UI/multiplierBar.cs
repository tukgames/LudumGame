using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplierBar : MonoBehaviour
{

    public ScoreManager sManager;
    public RectTransform bar;
    public GameObject mainCanvas;

    float targ;

    // Start is called before the first frame update
    void Start()
    {
        targ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (sManager.multiplier != 1) {
            updateMultBarWidth(sManager.timerLose);
        } else {
            updateMultBarWidth((float)0);
        }

        float width = Mathf.Lerp(bar.sizeDelta.x, targ, Time.deltaTime*8);
        bar.sizeDelta = new Vector2(width, (float)7.5);
    }

    public void updateMultBarWidth(float val) {
        if(val == 0) {
            targ = 0;
        } else {
            targ = -(1 / sManager.timeToLoseMult) * val + 1;
            targ *= 600;
        }
        if (targ < 0) {
            targ = 0;
        }
        
    }

}

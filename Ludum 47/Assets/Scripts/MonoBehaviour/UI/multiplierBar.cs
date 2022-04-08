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
        float width = Mathf.Lerp(bar.sizeDelta.x, targ, Time.deltaTime*8);
        bar.sizeDelta = new Vector2(width, (float)7.5);
    }

    public void updateMultBarWidth(float multiplier) {
        multiplier--;
        float scale = (mainCanvas.GetComponent<RectTransform>().sizeDelta.x) / 2 / 6;

        // rational function
        // float targ = scale * (-(9) / (multiplier + 2) + 4.5);
        float val;
        // square root
        if(multiplier < 9) {
            val = 2 * Mathf.Pow(multiplier, (float)0.5);
        } else {
            val = 6;
        }

        targ = val * scale;
        
        
    }

}

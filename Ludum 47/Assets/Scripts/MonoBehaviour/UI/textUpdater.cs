using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textUpdater : MonoBehaviour
{
    TextMeshProUGUI textObj;
    public ScoreManager sManager;

    // Start is called before the first frame update
    void Start()
    {
        textObj = this.GetComponent<TextMeshProUGUI>();
        float score = sManager.score;
        string original = "Score: ";
        string newText = original + score.ToString();

        textObj.SetText(newText);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

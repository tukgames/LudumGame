using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartFunction : MonoBehaviour
{
    public UI ui;
    public GameObject deadPanel;

    // This script exists only so unity's stupid (and useful) event system works
    
    public void runRestart() {
        ui.Restart();
        deadPanel.gameObject.SetActive(false);

    }
}

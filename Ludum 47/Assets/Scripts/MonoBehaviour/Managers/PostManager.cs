using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static PostManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);

        }
        else
        {
            instance = this;
        }
    }

    float startingVignette;
    public float smoothChange;

    Bloom bloom;
    Vignette vignette;

    PostProcessVolume pp;

    void Start()
    {
        pp = GetComponent<PostProcessVolume>();

        pp.profile.TryGetSettings(out bloom);
        pp.profile.TryGetSettings(out vignette);

        startingVignette = vignette.smoothness;
    }

    // Update is called once per frame
  

    public void IncreaseVignette()
    {
        vignette.smoothness.value = smoothChange;
    } 

    public void ResetVignette()
    {
        vignette.smoothness.value = startingVignette;
    }
}

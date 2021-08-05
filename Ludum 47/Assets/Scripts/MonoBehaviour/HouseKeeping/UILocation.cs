using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocation : MonoBehaviour
{
    // Start is called before the first frame update

    public float distanceFromTop;
    void Start()
    {
        //GetComponent<RectTransform>().localPosition = new Vector3(0,transform.GetComponentInParent<RectTransform>().rect.height * distanceFromTop,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

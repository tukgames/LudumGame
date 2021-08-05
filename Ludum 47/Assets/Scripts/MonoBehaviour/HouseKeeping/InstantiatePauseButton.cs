using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePauseButton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseButtonPrefab;

    public Vector3 pos;

    void Start()
    {
        GameObject button = Instantiate(pauseButtonPrefab, pos, Quaternion.identity, transform);

        button.GetComponent<RectTransform>().localPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

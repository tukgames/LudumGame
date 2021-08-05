using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    float startScale;

    private void Start()
    {
        startScale = transform.GetChild(0).localScale.x;

    }
    private void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }


    }

    public void updateBar(int hp, int hpst)
    {
        transform.GetChild(0).localScale = new Vector3((float)hp / hpst * startScale, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
    }


}

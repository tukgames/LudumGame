using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{


    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    public float shakeTime;

    // A measure of magnitude for the shake. Tweak based on your preference
    public float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    public float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    void Update()
    {
    }

    public void TriggerShake()
    {
        shakeDuration = shakeTime;

        PostManager.instance.IncreaseVignette();

        StartCoroutine(ShakeRoutine());
    }

    IEnumerator ShakeRoutine()
    {
        initialPosition = GetComponent<CameraFollow>().currentPosition;

        while (shakeDuration > 0)
        {
            initialPosition = GetComponent<CameraFollow>().currentPosition;

            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;

            yield return null;
        }
    }
}

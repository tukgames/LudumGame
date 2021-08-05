using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailParticle : MonoBehaviour
{
    // Start is called before the first frame update

    ParticleSystem ps;
    public GameObject psPrefab;
    ParticleSystem.ShapeModule editable_shape;
    GameObject system;
    void Start()
    {
        system = Instantiate(psPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ps = system.GetComponent<ParticleSystem>();
        //Debug.Log(ps.shape.position);
        editable_shape = ps.shape;
        editable_shape.enabled = true;
        editable_shape.position = transform.position;
        Debug.Log(editable_shape.position);

    }

    // Update is called once per frame
    void Update()
    {

        if (!StateManager.instance.playerDead) { 
       

            //editable_shape = ps.shape;
            editable_shape.position = transform.position;
        }
    }

    public void OnPlayerDeath()
    {
        Destroy(system);
    }
}

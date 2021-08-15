using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering;

public class RailGun : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject myLine;
    LineRenderer lr;
    public Color lineColor;
    public float startWidth;
    public float endWidth;
    Material mat;


    public int lineLength;
    public float chargeTime;
    public float alphaChangeSpeed;
    public float lifeTime;

    public GameObject particlePrefab;
    public Transform particleSpawn;
    public LayerMask layer_mask;

    Material materialPrefab;


    Coroutine rayChargeCoroutine;
    Vector3 lineEndPosition;

    bool gened = false;

    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent
    }


    void Start()
    {
        if(!gened) gen();


    }

    public void gen()
    {
        gened = true;
        mat = new Material(Shader.Find("Standard"));

        ChangeRenderMode(mat, BlendMode.Transparent);







        myLine = new GameObject();
        myLine.transform.position = Vector3.zero;
        myLine.AddComponent<LineRenderer>();
        lr = myLine.GetComponent<LineRenderer>();
        mat.color = lineColor;
        lr.material = mat;
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        lr.startWidth = startWidth;
        lr.endWidth = endWidth;

        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.instance.playerDead)
        {
            lr.enabled = false;
        }
    }


    public void StartRailGun(Vector3 targetPosition)
    {
        if(!gened) gen();
        SetLine(targetPosition);
        rayChargeCoroutine = StartCoroutine(FireCoroutine(targetPosition));
    }



    public void SetLine(Vector3 targetPosition)
    {

        lineEndPosition = new Vector2( targetPosition.x - transform.position.x, targetPosition.y - transform.position.y);

        //Debug.Log(lineEndPosition);

        lineEndPosition *= lineLength;

        //Debug.Log(lr.name);

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + lineEndPosition);

        lr.enabled = true;
    }

    IEnumerator FireCoroutine(Vector3 targetPosition)
    {
        float time = 0;

        ParticleSystem ps = Instantiate(particlePrefab, particleSpawn.position, Quaternion.Euler(new Vector3(-90,0,0))).GetComponent<ParticleSystem>();

        if (GetComponent<RailGunEnemy>() != null)  GetComponent<RailGunEnemy>().Rotate();


        mat.color = lineColor;

        //Debug.Log(mat.color);

        while(time <= chargeTime)
        {
            time += Time.deltaTime;

            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + (Time.deltaTime * alphaChangeSpeed / chargeTime));



            yield return null;
        }

        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 255);

        time = 0;

        while(time < lifeTime)
        {


            //detect collision with raycast that only detects character layer

            RaycastHit2D hit = Physics2D.Raycast(transform.position, lineEndPosition, 1000, layer_mask);

            if (hit.collider != null)
            {
                //Debug.Log("hitSomething");
                
                hit.transform.GetComponent<Player>().KillPlayer();
            }

            Debug.DrawLine(transform.position, hit.point);

            time += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Line disabled");
        lr.enabled = false;
        if (GetComponent<RailGunEnemy>() != null)
        {
            GetComponent<RailGunEnemy>().ResetEnemy();
        }
    }

    public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }

    }

    public void OnDestroy()
    {
        Destroy(myLine);
    }
}


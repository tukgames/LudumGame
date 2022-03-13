using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinManager : MonoBehaviour
{

    private GameObject skinHolder;
    private SpriteRenderer shRenderer;
    private SpriteRenderer pRenderer;
    private Sprite parentSprite;
    public Sprite skin;

    // Start is called before the first frame update
    void Start()
    {
        if (skin != null)
        {
            // Parent's Renderer
            pRenderer = this.GetComponent<SpriteRenderer>();

            // Initialize Skin Holder Object
            skinHolder = new GameObject();
            skinHolder.name = "skinHolder";

            // Modify Skin Holder
            skinHolder.transform.parent = this.transform;
            shRenderer = skinHolder.AddComponent<SpriteRenderer>();
            shRenderer.sprite = skin;
            shRenderer.sortingOrder = pRenderer.sortingOrder + 1;


            // Adjust scale by dividing bound size of parent by the skin then multiplying by the inverse scale of the parent
            // I do not know why this works but I do not want to do the math to learn why it does
            float adjustedScale = (pRenderer.bounds.size.x) / (shRenderer.bounds.size.x) * Mathf.Pow(this.transform.localScale.x, -1) + (float)0.001;
            skinHolder.transform.localScale = new Vector3(adjustedScale, adjustedScale, 1);
        }


        




    }
}

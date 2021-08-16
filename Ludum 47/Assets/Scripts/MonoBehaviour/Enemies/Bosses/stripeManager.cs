using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripeManager : MonoBehaviour
{
    public int stripeCount;
    public float stripeThickness;
    public float stripeLengthModifier;
    public float totalStripeOffset;
    public float individualStripeOffset;
    public Color stripeColor;

    private GameObject parent;
    private SpriteRenderer sRenderer;
    private SpriteMask mask;

    private Sprite stripeSprite;
    private SpriteRenderer sr;


    void Start()
    {
        // Finds renderer Component
        sRenderer = this.GetComponent<SpriteRenderer>();

        // Create Sprite Mask
        this.gameObject.AddComponent<SpriteMask>();
        mask = this.gameObject.GetComponent<SpriteMask>();
        mask.sprite = sRenderer.sprite;


        // Makes the stripes and attaches them
        for (int i = 0; i<stripeCount; i++) {

            // Pixels per unit (Dont touch this it sucks to work with)
            float ppu = 1 / sRenderer.sprite.bounds.size.x;

            // Makes new sprite
            Sprite stripeSprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), ppu);

            // Creates foundation
            GameObject foundation = new GameObject();
            foundation.name = this.gameObject.name + ": Stripe #" + i;
            

            // Adds sprite renderer component
            foundation.AddComponent<SpriteRenderer>();
            SpriteRenderer fRenderer = foundation.GetComponent<SpriteRenderer>();

            // Modifies the foundation's renderer
            fRenderer.sprite = stripeSprite;
            fRenderer.sortingOrder = sRenderer.sortingOrder + 1;
            fRenderer.color = stripeColor;
            

            //mask interaction
            foundation.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            // stripe Thickness
            stripeThickness = stripeThickness != 0 ? stripeThickness : 1;
            foundation.transform.localScale = new Vector3(2f, 0.1f*stripeThickness, 1);

            // Stripe location
            foundation.transform.parent = this.transform;
            foundation.transform.localPosition = new Vector3(0, 0, 0);
            individualStripeOffset = individualStripeOffset != 0 ? individualStripeOffset : 30;
            stripeLengthModifier = stripeLengthModifier != 0 ? stripeLengthModifier : 1.25f;
            foundation.transform.rotation = Quaternion.Euler(0, 0, (i * individualStripeOffset)+totalStripeOffset);

        }
    }

    void Update()
    {
        
    }
}

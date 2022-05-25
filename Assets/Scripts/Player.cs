using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
   private Vector3 direction;

   public float gravity = -9.8f;
   public float strength = 5f;

   private void Awake() 
   {
       spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void Start() 
   {
       InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // calls the animatesprite function every 0.15 seconds
   }

   private void Update() 
   {
       if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
       {
           direction = Vector3.up * strength;
       }

       if (Input.touchCount > 0)
       {
           Touch touch = Input.GetTouch(0);

           if (touch.phase == TouchPhase.Began)
               {
                   direction = Vector3.up * strength;
               }
           }
        
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
       }
    
    private void AnimateSprite() // increasing the index and then reassigning the sprite on sprite renderer based on the sprite index in array
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) // need to make sure it loops back to beginning when we get to end of array
        {
            spriteIndex = 0; // starts over
        }

        spriteRenderer.sprite = sprites[spriteIndex]; // update sprites
    }



   }

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
   public float tilt = 5f;

   private void Awake() 
   {
       spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void Start() 
   {
       InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // calls the animatesprite function every 0.15 seconds
   }

   private void OnEnable() 
   {
       Vector3 position = transform.position;
       position.y = 0f;
       transform.position = position;
       direction = Vector3.zero;
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

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
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

    private void OnTriggerEnter2D(Collider2D other) // we can now check what is the tag of the object and whether to add score or death
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver(); // this is an expensive function and usually are better ways to get a reference to our game manager
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }



   }

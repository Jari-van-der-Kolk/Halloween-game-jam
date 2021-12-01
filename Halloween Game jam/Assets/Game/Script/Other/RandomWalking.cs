using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomWalking : MonoBehaviour
{

   [SerializeField] private float speed;
   private float plusSpeed;
   private float minusSpeed;

   [Header("timer")] 
   [SerializeField] private float switchSpeed;

   private float timer;
   private float randomNumber;

   private Rigidbody2D rb;
   private SpriteRenderer r;
   

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      r = GetComponent<SpriteRenderer>();
   }

   private void Start()
   {
      plusSpeed = speed;
      minusSpeed = -speed;
   }

   private void Update()
   {
      timer += Time.deltaTime * switchSpeed;

      if (timer >= 1f)
      {
         randomNumber = Random.Range(-1, 1);
         timer = 0f;
      }
      if (randomNumber >= 0)
      {
         r.flipX = false;
         speed = plusSpeed;
      }
      else
      {
         r.flipX = true;
         speed = minusSpeed;
      }
   }

   private void FixedUpdate()
   {
      rb.velocity = new Vector2(speed, 0);
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class RandomizeOrder <T> 
    {
        private T[] bagContents;
        private T[] peekBagContents;
        private int remaining = 0;
        
        public RandomizeOrder(T[] bagContents)
        {
            this.bagContents = bagContents;
            Debug.Log(this.bagContents.Length);
            peekBagContents = bagContents;
        }

        public T Next()
        {
            remaining--;
            return bagContents[remaining];
        }

       
        public void Shuffle()  
        {
            int n = bagContents.Length;
            while (n > 1)
            {  
                n--;  
                int k = Random.Range(0, n + 1);
                (bagContents[k], bagContents[n]) = (bagContents[n], bagContents[k]);
                 peekBagContents[n] = bagContents[n];
            }

            remaining = bagContents.Length;
        }
        public T Peek()
        {
            if (remaining <= 0)
            {
                Shuffle();
            }
            return bagContents[remaining - 1];
        }
    }

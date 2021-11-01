using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractionHandler : MonoBehaviour
{

    private IActionCheck actionCheck;

    [SerializeField]private TextMeshProUGUI interactionText;

    
    private void Awake() => actionCheck = GetComponent<IActionCheck>();
    
    void Update()
    {
        bool successfulHit = false;
        Collider2D check = actionCheck.Check().collider;
        if (check != null)
        {
            var action = check.GetComponent<Interaction>(); 
            action.Interact();
            interactionText.text = action.GetDescription();
            successfulHit = true;
        }
        
        if (successfulHit == false) interactionText.text = "";
    }
    
    
}

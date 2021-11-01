using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState instance;


    public enum WalkingMode
    {
        Human,
        Ghost
    }

    public WalkingMode walkingMode;

    private void Awake()
    {
        instance = this;
    }
}

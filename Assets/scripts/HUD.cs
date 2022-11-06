using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    // These are abstract %s of hud elements
    [SerializeField] private float health_bar = 100f;
    [SerializeField] private float gun_bar = 100f;


    void Start()
    {
    
    }

    void Update()
    {
        // draw a bar to represent health
        
    }

    void changeHealth(float new_value)
    {
        health_bar = new_value;
    }

    void changeGun(float new_value)
    {
        gun_bar = new_value;
    }
}
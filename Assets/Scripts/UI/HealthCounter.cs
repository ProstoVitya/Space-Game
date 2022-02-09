﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    private List<Transform> _hearts;
    
    private void Start()
    {
        _hearts = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _hearts.Add(transform.GetChild(i));
        }
        
        /*foreach (Transform child in transform)
            _hearts.Add(child);*/

        DrawHealth(FindObjectOfType<Spaceship>().StartHealth);
    }

    public void DrawHealth(int health)
    {
        for (int i = 0; i < health; ++i)
        {
            _hearts[i].gameObject.SetActive(true);
        }
        for (int i = health; i < transform.childCount; ++i)
        {
            _hearts[i].gameObject.SetActive(false);
        }
    }
}

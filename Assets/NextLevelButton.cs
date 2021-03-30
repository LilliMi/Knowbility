﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    private GameObject nextLevelButton;


    // Start is called before the first frame update
    void Start()
    {
        nextLevelButton = GameObject.FindWithTag("StartNextLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerHand")){
            SceneManager.LoadScene("LevelTwo_KnowbilityScene");
        }
    }
}

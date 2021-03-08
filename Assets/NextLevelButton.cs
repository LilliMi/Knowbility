using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    private bool buttonHit = false;
    private GameObject StartNextLevelButton;
    

    // Start is called before the first frame update
    void Start()
    {
        StartNextLevelButton = GameObject.FindWithTag("StartNextLevel");
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonHit == true){
             buttonHit = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerHand")){
            SceneManager.LoadScene("LevelTwo_KnowbilityScene");
        }
    }
}

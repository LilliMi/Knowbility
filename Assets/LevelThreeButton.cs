using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelThreeButton : MonoBehaviour
{
    private GameObject levelThreeButton;


    // Start is called before the first frame update
    void Start()
    {
        levelThreeButton = GameObject.FindWithTag("StartLevelThree");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerHand")){
            SceneManager.LoadScene("LevelThree_KnowbilityScene");
        }
    }
}

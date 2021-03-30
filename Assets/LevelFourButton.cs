using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFourButton : MonoBehaviour
{
    private GameObject levelFourButton;


    // Start is called before the first frame update
    void Start()
    {
        levelFourButton = GameObject.FindWithTag("StartLevelFour");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerHand")){
            //SceneManager.LoadScene("LevelFour_KnowbilityScene");
        }
    }
}

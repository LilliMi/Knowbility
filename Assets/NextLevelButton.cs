using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("LevelTwo_KnowbilityScene");
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene("LevelTwo_KnowbilityScene");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerHand")){
            SceneManager.LoadScene("LevelTwo_KnowbilityScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControlLevelThree : MonoBehaviour
{
    private bool buttonHit = false;
    private GameObject button;
    private float buttonDownDistance = 0.025f;
    private float buttonReturnSpeed = 0.001f;
    private float buttonOriginalY;
    private float buttonHitAgainTime = 0.5f;
    private float canHitAgain;

    // Check Ball - Objects
    private GameObject QuestionMarkLevelThree;
    private GameObject Number31LevelThree;

    // TextMessages
    private GameObject CongratzLevelThree;
    private GameObject WrongNumberLevelThree;
    private GameObject LevelFourButton;
    //private GameObject LevelNameTwo;
    //private GameObject LevelNameThree;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
 
         string sceneName = currentScene.name;
 
         if (sceneName == "LevelThree_KnowbilityScene") 
         {
        
        //Button
            //source = gameObject.AddComponent // für Sound später
            button = transform.GetChild(0).gameObject;
            buttonOriginalY = button.transform.position.y;

        //Balls
        QuestionMarkLevelThree = GameObject.FindWithTag("QuestionMarkLevelThree");
        Number31LevelThree = GameObject.FindWithTag("Number38");

        //Button
        LevelFourButton = GameObject.FindWithTag("StartLevelFour");
        LevelFourButton.SetActive(false);

        //Texts
        CongratzLevelThree = GameObject.FindWithTag("CongratzLevelThree");
        WrongNumberLevelThree = GameObject.FindWithTag("WrongLevelThree");
        //LevelNameTwo = GameObject.FindWithTag("LevelNameTwo");
        //LevelNameThree = GameObject.FindWithTag("LevelNameThree");

        CongratzLevelThree.SetActive(false);
        WrongNumberLevelThree.SetActive(false);
        //LevelNameTwo.SetActive(false);
        //LevelNameThree.SetActive(true);
         }
    }

    // Update is called once per frame
    void Update()
    {
         Scene currentScene = SceneManager.GetActiveScene ();
 
         string sceneName = currentScene.name;
 
         if (sceneName == "LevelThree_KnowbilityScene") 
         {
            if(buttonHit == true){
             buttonHit = false;
             button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonDownDistance, button.transform.position.z);
             Debug.Log(QuestionMarkLevelThree.transform.position);
             //Debug.Log(QuestionMarkLevelThree.getposition);
             Debug.Log(Number31LevelThree.transform.position);
         }

         if(button.transform.position.y < buttonOriginalY){
             button.transform.position += new Vector3(0, buttonReturnSpeed, 0);

         }
        //System.out.print("Hallu");
        //Console.WriteLine("Hallu");
         }
    }

    private void OnTriggerEnter(Collider other) {
        Scene currentScene = SceneManager.GetActiveScene ();
 
         string sceneName = currentScene.name;
 
         if (sceneName == "LevelThree_KnowbilityScene") 
         {
        if(other.CompareTag("PlayerHand") && canHitAgain < Time.time){
            canHitAgain = Time.time + buttonHitAgainTime;
            buttonHit = true;

            CongratzLevelThree.SetActive(false);
            WrongNumberLevelThree.SetActive(false);
            LevelFourButton.SetActive(false);


            if (QuestionMarkLevelThree != null && Number31LevelThree != null)
            {
                double distance = (Vector3.Distance(QuestionMarkLevelThree.transform.position, Number31LevelThree.transform.position));
                double sumRadius = ((QuestionMarkLevelThree.GetComponent<SphereCollider>().radius*QuestionMarkLevelThree.transform.localScale.x) + (Number31LevelThree.GetComponent<SphereCollider>().radius*Number31LevelThree.transform.localScale.x));

                Debug.Log(string.Format("Distance between {0} and {1} is: {2}", QuestionMarkLevelThree, Number31LevelThree, distance));
                Debug.Log(string.Format("QuestionMark: {0}", (QuestionMarkLevelThree.GetComponent<SphereCollider>().radius*QuestionMarkLevelThree.transform.localScale.x)));
                Debug.Log(string.Format("Number31: {0}", (Number31LevelThree.GetComponent<SphereCollider>().radius*Number31LevelThree.transform.localScale.x)));
                Debug.Log(string.Format("sumRadius: {0}", sumRadius));

                if(distance <= sumRadius){
                    CongratzLevelThree.SetActive(true);
                    LevelFourButton.SetActive(true);
                } else{
                    WrongNumberLevelThree.SetActive(true);
                }

            }
        }
         }

    }
}
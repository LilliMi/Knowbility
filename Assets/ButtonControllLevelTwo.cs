using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllLevelTwo : MonoBehaviour
{
    private bool buttonHit = false;
    private GameObject button;
    private float buttonDownDistance = 0.025f;
    private float buttonReturnSpeed = 0.001f;
    private float buttonOriginalY;
    private float buttonHitAgainTime = 0.5f;
    private float canHitAgain;

    // Check Ball - Objects
    private GameObject QuestionMarkLevelTwo;
    private GameObject Number31LevelTwo;

    // TextMessages
    private GameObject CongratzLevelTwo;
    private GameObject WrongNumberLevelTwo;
    private GameObject LevelThreeButton;
    //private GameObject LevelNameTwo;
    //private GameObject LevelNameThree;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
 
         string sceneName = currentScene.name;
 
         if (sceneName == "LevelTwo_KnowbilityScene") 
         {
        
        //Button
            //source = gameObject.AddComponent // für Sound später
            button = transform.GetChild(0).gameObject;
            buttonOriginalY = button.transform.position.y;

        //Balls
        QuestionMarkLevelTwo = GameObject.FindWithTag("QuestionMarkLevelTwo");
        Number31LevelTwo = GameObject.FindWithTag("Number5");

        //Button
        LevelThreeButton = GameObject.FindWithTag("StartLevelThree");
        LevelThreeButton.SetActive(false);

        //Texts
        CongratzLevelTwo = GameObject.FindWithTag("CongratzLevelTwo");
        WrongNumberLevelTwo = GameObject.FindWithTag("WrongLevelTwo");
        //LevelNameTwo = GameObject.FindWithTag("LevelNameTwo");
        //LevelNameThree = GameObject.FindWithTag("LevelNameThree");

        CongratzLevelTwo.SetActive(false);
        WrongNumberLevelTwo.SetActive(false);
        //LevelNameTwo.SetActive(true);
        //LevelNameThree.SetActive(false);
         }
    }
    

    // Update is called once per frame
    void Update()
    {
         Scene currentScene = SceneManager.GetActiveScene ();
 
         string sceneName = currentScene.name;
 
         if (sceneName == "LevelTwo_KnowbilityScene") 
         {
            if(buttonHit == true){
             buttonHit = false;
             button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonDownDistance, button.transform.position.z);
             Debug.Log(QuestionMarkLevelTwo.transform.position);
             //Debug.Log(QuestionMark.getposition);
             Debug.Log(Number31LevelTwo.transform.position);
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
 
         if (sceneName == "LevelTwo_KnowbilityScene") 
         {
        if(other.CompareTag("PlayerHand") && canHitAgain < Time.time){
            canHitAgain = Time.time + buttonHitAgainTime;
            buttonHit = true;

            CongratzLevelTwo.SetActive(false);
            WrongNumberLevelTwo.SetActive(false);
            LevelThreeButton.SetActive(false);


            if (QuestionMarkLevelTwo != null && Number31LevelTwo != null)
            {
                double distance = (Vector3.Distance(QuestionMarkLevelTwo.transform.position, Number31LevelTwo.transform.position));
                double sumRadius = ((QuestionMarkLevelTwo.GetComponent<SphereCollider>().radius*QuestionMarkLevelTwo.transform.localScale.x) + (Number31LevelTwo.GetComponent<SphereCollider>().radius*Number31LevelTwo.transform.localScale.x));

                Debug.Log(string.Format("Distance between {0} and {1} is: {2}", QuestionMarkLevelTwo, Number31LevelTwo, distance));
                Debug.Log(string.Format("QuestionMark: {0}", (QuestionMarkLevelTwo.GetComponent<SphereCollider>().radius*QuestionMarkLevelTwo.transform.localScale.x)));
                Debug.Log(string.Format("Number31: {0}", (Number31LevelTwo.GetComponent<SphereCollider>().radius*Number31LevelTwo.transform.localScale.x)));
                Debug.Log(string.Format("sumRadius: {0}", sumRadius));

                if(distance <= sumRadius){
                    CongratzLevelTwo.SetActive(true);
                    LevelThreeButton.SetActive(true);
                } else{
                    WrongNumberLevelTwo.SetActive(true);
                }

            }
        }
         }

    }
}
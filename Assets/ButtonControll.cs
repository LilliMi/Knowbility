using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    private bool buttonHit = false;
    private GameObject button;
    private float buttonDownDistance = 0.025f;
    private float buttonReturnSpeed = 0.001f;
    private float buttonOriginalY;
    private float buttonHitAgainTime = 0.5f;
    private float canHitAgain;

    // Check Ball - Objects
    private GameObject QuestionMark;
    private GameObject Number31;

    // TextMessages
    private GameObject Congratz;
    private GameObject WrongNumber;
    private GameObject StartNextLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        //Button
            //source = gameObject.AddComponent // für Sound später

            button = transform.GetChild(0).gameObject;
            buttonOriginalY = button.transform.position.y;

        //Balls
        QuestionMark = GameObject.FindWithTag("QuestionMark");
        Number31 = GameObject.FindWithTag("Number31");
        Congratz = GameObject.FindWithTag("Congratz");
        WrongNumber = GameObject.FindWithTag("Wrong");
        StartNextLevelButton = GameObject.FindWithTag("StartNextLevel");

        Congratz.SetActive(false);
        WrongNumber.SetActive(false);
        StartNextLevelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(buttonHit == true){
             buttonHit = false;
             button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonDownDistance, button.transform.position.z);
             Debug.Log(QuestionMark.transform.position);
             //Debug.Log(QuestionMark.getposition);
             Debug.Log(Number31.transform.position);
         }

         if(button.transform.position.y < buttonOriginalY){
             button.transform.position += new Vector3(0, buttonReturnSpeed, 0);

         }
        //System.out.print("Hallu");
        //Console.WriteLine("Hallu");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerHand") && canHitAgain < Time.time){
            canHitAgain = Time.time + buttonHitAgainTime;
            buttonHit = true;

            Congratz.SetActive(false);
            WrongNumber.SetActive(false);
            StartNextLevelButton.SetActive(false);


            if (QuestionMark != null && Number31 != null)
            {
                double distance = (Vector3.Distance(QuestionMark.transform.position, Number31.transform.position));
                double sumRadius = ((QuestionMark.GetComponent<SphereCollider>().radius*QuestionMark.transform.localScale.x) + (Number31.GetComponent<SphereCollider>().radius*Number31.transform.localScale.x));

                Debug.Log(string.Format("Distance between {0} and {1} is: {2}", QuestionMark, Number31, distance));
                Debug.Log(string.Format("QuestionMark: {0}", (QuestionMark.GetComponent<SphereCollider>().radius*QuestionMark.transform.localScale.x)));
                Debug.Log(string.Format("Number31: {0}", (Number31.GetComponent<SphereCollider>().radius*Number31.transform.localScale.x)));
                Debug.Log(string.Format("sumRadius: {0}", sumRadius));

                if(distance <= sumRadius){
                    Congratz.SetActive(true);
                    StartNextLevelButton.SetActive(true);
                } else{
                    WrongNumber.SetActive(true);
                }

            }
        }

    }
}

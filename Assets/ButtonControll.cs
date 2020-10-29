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

    // Start is called before the first frame update
    void Start()
    {
        //source = gameObject.AddComponent // für Sound später

        button = transform.GetChild(0).gameObject;
        buttonOriginalY = button.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
         if(buttonHit == true){
             buttonHit = false;
             button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonDownDistance, button.transform.position.z);

         }

         if(button.transform.position.y < buttonOriginalY){
             button.transform.position += new Vector3(0, buttonReturnSpeed, 0);

         }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerHand") && canHitAgain < Time.time){
            canHitAgain = Time.time + buttonHitAgainTime;
            buttonHit = true;
        }

    }
}

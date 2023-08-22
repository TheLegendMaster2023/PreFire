using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersScript : MonoBehaviour
{

    public float OtherBulletColor; //эта фигня просто -0.5 или плюс, чтобы пуля в тригере на багалась
    public string ThisTriggerType;
    public string PreviousDirection;
    public GameObject CollisionObj;
    public void OnTriggerEnter(Collider other)
    {
        
        CollisionObj = other.gameObject;
        PreviousDirection = CollisionObj.GetComponent<BBScript>().DirectionOfThisBullet;

        if (CollisionObj.GetComponent<BBScript>().CountOfBounce < 0)
        {
            CollisionObj.GetComponent<BBScript>().DeleteByTrigger();
        }
            
            
        
            

        if (CollisionObj.GetComponent<BBScript>().IdBulletColour == 1)
        {
            OtherBulletColor = -0.6f; //это зеленая пуля, минус тут правильный


        }
        if (CollisionObj.GetComponent<BBScript>().IdBulletColour == 2)
        {
            OtherBulletColor = 0.6f; 


        }

        if (PreviousDirection == "OnRight" && ThisTriggerType == "CentralRight")
            {

                CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
                CollisionObj.transform.Rotate(new Vector3(0, 90, 0));
                CollisionObj.GetComponent<BBScript>().CountOfBounce--;
                CollisionObj.GetComponent<BBScript>().DirectionOfThisBullet = "Right";


            }



        if (PreviousDirection == "Return")
        {
            
            CollisionObj.transform.Rotate(new Vector3(0, 180, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;




        }

        if (PreviousDirection == "OnLeft" && ThisTriggerType == "CentralLeft")
        {

            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, -90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;
            CollisionObj.GetComponent<BBScript>().DirectionOfThisBullet = "Left";


        }

        if (PreviousDirection == "Right" && ThisTriggerType == "TopLeft")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, 90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;
            CollisionObj.GetComponent<BBScript>().DirectionOfThisBullet = "OnRight";



        }

        if (PreviousDirection == "Left" && ThisTriggerType == "TopRight")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, -90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;
            CollisionObj.GetComponent<BBScript>().DirectionOfThisBullet = "OnLeft";



        }

        if (PreviousDirection == "RightPerfect" && ThisTriggerType == "TopLeft")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, 90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;
            



        }

        if (PreviousDirection == "LeftPerfect" && ThisTriggerType == "TopRight")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, -90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;
            



        }

        if (PreviousDirection == "Left" && ThisTriggerType == "Central")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, -90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;
            



        }

        if (PreviousDirection == "Right" && ThisTriggerType == "Central")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, 90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;
            


        }


        if (ThisTriggerType == "MostRight")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, 90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;



        }

        if (ThisTriggerType == "MostLeft")
        {
            CollisionObj.transform.Translate(new Vector3(0, 0, OtherBulletColor));
            CollisionObj.transform.Rotate(new Vector3(0, -90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;



        }

    }
   /* public void OnTriggerExit(Collider other)
    {

        if (PreviousDirection == "Right" && ThisTriggerType == "CentralRight")
        {

            CollisionObj.transform.Rotate(new Vector3(0, 90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;



        }

        if (PreviousDirection == "Left" && ThisTriggerType == "CentralLeft")
        {

            CollisionObj.transform.Rotate(new Vector3(0, -90, 0));
            CollisionObj.GetComponent<BBScript>().CountOfBounce--;


                
        }

    }*/

}

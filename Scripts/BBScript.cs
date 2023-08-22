using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBScript : MonoBehaviour
{
    
    public GameObject GC;
    public int CountOfBounce, ThisNumberInListG;
    public string DirectionOfThisBullet;
    public GameObject OtherObj;
    public int IdBulletColour;
    public string TypeOfThisBullet;
    public int OtherIdBulletColour;
    public int ThisBulletPower, OtherBulletPower;

    public float BulletBSpeed = 15;
    public float BBulletBSpeed = -15;

    private void Start()
    {
        GC = GameObject.Find("GameControllerObj");
    }
    void FixedUpdate()
    {
        if(IdBulletColour == 1)
        transform.Translate(new Vector3(0, 0, BulletBSpeed) * Time.deltaTime);

        if (IdBulletColour == 2 )
            transform.Translate(new Vector3(0, 0, BBulletBSpeed) * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
          OtherObj = other.gameObject;
        OtherIdBulletColour = OtherObj.GetComponent<BBScript>().IdBulletColour;
        OtherBulletPower = OtherObj.GetComponent<BBScript>().ThisBulletPower;


        /* if(TypeOfThisBullet == "Iron" && OtherIdBulletColour != IdBulletColour)
         {

           if(other.CompareTag("IRonBullet"))
           {

               Destroy(this);
           }

           if(other.CompareTag("SimpleBullet"))
           {
               Destroy(other);

           }

           if(other.CompareTag("Blast"))
           {
               Destroy(this);
           }

         }*/
        if (OtherIdBulletColour != IdBulletColour)
        {
            ThisBulletPower -= OtherBulletPower;
            if (ThisBulletPower < 1)
            {

                GC.GetComponent<GameControllerNew>().ActiveBulletsG.Remove(this.gameObject); 
                Destroy(this);

            }
        }



    }
    public void DeleteByTrigger()
    {
        print("сработало");
        GC.GetComponent<GameControllerNew>().ActiveBulletsG.Remove(this.gameObject);
        Destroy(this.gameObject);
      // ThisNumberInListG = GetComponent<GameControllerNew>().ActiveBulletsG.Count - 1;
        //GC.GetComponent<GameControllerNew>().ActiveBulletsG.RemoveAt(ThisNumberInListG);
            //Destroy(this.gameObject);
        
    }
}

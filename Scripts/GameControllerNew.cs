using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerNew : MonoBehaviour
{

    public Button MyButton, MyButton2;
    public int CouldownMoveG, CouldownMoveB;
    private bool MoveCouldownB, MoveCouldownG;
    private int XB, XG;
    public GameObject PlayerG, PlayerB;
    public Transform GreenPlayerPos, BluePlayerPos;
    public int BlueCharacterChoose, GreenCharacterChoose;
    public GameObject[] CharactersGreen;
    public GameObject[] CharactersBlue;
    public int BlueAbilityChoose, GreenAbilityChoose;
    public bool CouldownAbilityGreenActive, CouldownAbilityBlueActive;
    public int CouldownSecGreen, CouldownSecBlue;




    public void Start()
    {
        FirstStringG = directionsG[Random.Range(0, directionsG.Length - 1)];
        SecondStringG = directionsG[Random.Range(0, directionsG.Length - 1)];
        GreenAbilityChoose = PlayerPrefs.GetInt("GreenAbilityIndex");
        BlueAbilityChoose = PlayerPrefs.GetInt("BlueAbilityIndex");
        GreenCharacterChoose = PlayerPrefs.GetInt("GreenCharacterIndex");
        BlueCharacterChoose = PlayerPrefs.GetInt("BlueCharacterIndex");
        CharactersSpawner();
        MyButton.onClick.AddListener(ShielderUsesUltG);
        MyButton2.onClick.AddListener(BulletSpawnG);

    }
    public void CharactersSpawner()
    {
        PlayerG = Instantiate(CharactersGreen[GreenCharacterChoose], GreenPlayerPos.position, Quaternion.identity);
        PlayerB = Instantiate(CharactersBlue[BlueCharacterChoose], BluePlayerPos.position, Quaternion.identity);

    }
    //Раздел Shielder
    public GameObject ShielderWallsG;
    public GameObject ShielderHeartShieldG;
    public GameObject ShielderBulletsShieldG;
    public GameObject SimpleBulletG;
    public bool TimingAbiliti1G, TimingAbiliti2G, UltChargedG;
    public float Ab1FloatTimeG, Ab2FloatTimeG;
    public Transform HeartPosG, PosGunG;
    public List<GameObject> ActiveBulletsG;
    public string[] directionsG; //надо наполнить от Return до PerfectRight
    public string FirstStringG, SecondStringG;


    public void BulletSpawnG()
    {

      GameObject NewBullet = Instantiate(SimpleBulletG, PosGunG.position, Quaternion.identity);
        NewBullet.GetComponent<BBScript>().DirectionOfThisBullet = FirstStringG;
        
        RandomizerDirectOfBulletG();
        ActiveBulletsG.Add(NewBullet);
        NewBullet.GetComponent<BBScript>().ThisNumberInListG = ActiveBulletsG.Count -1;
    }
    public void ShielderUseWallsG() //время их жизни и прочее должно быть прописано в них самих
    {
        if (TimingAbiliti1G == false)
        {
            TimingAbiliti1G = true;
            Instantiate(ShielderWallsG, new Vector3(0f, 2f, GreenPlayerPos.position.z), Quaternion.identity);
            StartCoroutine(Ab1G());
        }
    }

    public void ShielderUseHeartShieldG() 
    {
        if (TimingAbiliti2G == false)
        {
            TimingAbiliti2G = true;
            GameObject AbHeartShieldG = Instantiate(ShielderHeartShieldG, HeartPosG.position, Quaternion.identity);
            AbHeartShieldG.transform.SetParent(HeartPosG);
            StartCoroutine(Ab2G());
        }
    }
    public void ShielderUsesUltG()  //также новые пули должны быть прочнее
    {
        if(UltChargedG == true)
        {
            UltChargedG = false;

            for (int i = 0; i < ActiveBulletsG.Count; i++)
            {
                ActiveBulletsG[i].GetComponent<BBScript>().ThisBulletPower++;

            }
        }

    }

    public void RandomizerDirectOfBulletG()
    {
        FirstStringG = SecondStringG;
        SecondStringG = directionsG[Random.Range(0, directionsG.Length - 1)];
    }
    
    private IEnumerator Ab1G()
    {
        yield return new WaitForSeconds(Ab1FloatTimeG);
        TimingAbiliti1G = false;
    }

    private IEnumerator Ab2G()
    {
        yield return new WaitForSeconds(Ab2FloatTimeG);
        TimingAbiliti2G = false;
    }



    private IEnumerator CouldownB()
    {
        yield return new WaitForSeconds(CouldownMoveB);
        MoveCouldownB = false;
    }

    private IEnumerator CouldownG()
    {
        yield return new WaitForSeconds(CouldownMoveG);
        MoveCouldownG = false;
    }

    public IEnumerator CouldownerGreen()
    {
        yield return new WaitForSeconds(CouldownSecGreen);
        CouldownAbilityGreenActive = false;
    }
    public IEnumerator CouldownerBlue()
    {
        yield return new WaitForSeconds(CouldownSecBlue);
        CouldownAbilityBlueActive = false;
    }

    public void PlayerRightG()
    {
        if (!MoveCouldownG && XG >= 0)
        {

            MoveCouldownG = true;
            XG--;
            
            PlayerG.transform.Translate(new Vector3(3.4f, 0, 0));
            StartCoroutine(CouldownG());
            

        }
    }

    public void PlayerleftG()
    {
        if (!MoveCouldownG && XG <= 0)
        {

            MoveCouldownG = true;
            XG++;

            PlayerG.transform.Translate(new Vector3(-3.4f, 0, 0));
            StartCoroutine(CouldownG());

        }
    }

    public void PlayerRightB()
    {
        if (!MoveCouldownB && XB >= 0)
        {

            MoveCouldownB = true;
            XB--;

            PlayerB.transform.Translate(new Vector3(-3.4f, 0, 0));
            StartCoroutine(CouldownB());

        }
    }

    public void PlayerleftB()
    {
        if (!MoveCouldownB && XB <= 0)
        {

            MoveCouldownB = true;
            XB++;

            PlayerB.transform.Translate(new Vector3(3.4f, 0, 0));
            StartCoroutine(CouldownB());

        }
    }
    
    public void GreenAbilityUse()
    {
        if (GreenAbilityChoose == 1 && !CouldownAbilityGreenActive)
        {
            CouldownAbilityGreenActive = true;
             GreenPlayerShieldAbility();
            StartCoroutine(CouldownerGreen());
        }
           
    }
    public void BlueAbilityUse()
    {
        if (BlueAbilityChoose == 1 && !CouldownAbilityBlueActive)
        {
            CouldownAbilityBlueActive = true;
            BluePlayerShieldAbility();
            StartCoroutine(CouldownerBlue());
        }

    }

    public void BluePlayerShieldAbility()
    {
        
    }
    public void GreenPlayerShieldAbility()
    {

    }

   

  
}

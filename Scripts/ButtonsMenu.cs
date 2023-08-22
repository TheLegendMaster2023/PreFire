using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    public bool GreenReady, BlueReady;
    public int ThisButtonInt;
    public GameObject GreenCharactersVariantsSelect, BlueCharactersVariantsSelect;
    public bool GCSActive = false, BCSActive = false;
    //public GameObject GreenAbilitiesSelect, BlueAbilitiesSelect;

    public Text ReadyTxtBl, ReadyTxtGr;
    public int CurrentCam = 0;
    public GameObject AlternativeCameraButton;
    private void Start()
    {
        if(PlayerPrefs.HasKey("SelectedCameraPP"))
        {
            CurrentCam = PlayerPrefs.GetInt("SelectedCameraPP");
        }
    }
    public void GreenCharactersSelect()
    {
        if(!GCSActive)
        {
            GCSActive = true;
            GreenCharactersVariantsSelect.SetActive(true);
            
        }
       else if (GCSActive == true)
        {
            GCSActive = false;
            GreenCharactersVariantsSelect.SetActive(false);

        }
    }

    public void BlueCharactersSelect() //Просто выдвигает остальные кнопки при выборе перса
    {
        if (!BCSActive)
        {
            BCSActive = true;
            BlueCharactersVariantsSelect.SetActive(true);

        }
       else if (BCSActive == true)
        {
            BCSActive = false;
            BlueCharactersVariantsSelect.SetActive(false);

        }
    }

    public void SelectCharacterButtonGreen()
    {
        PlayerPrefs.SetInt("GreenCharacterIndex", ThisButtonInt);

    }
    public void SelectCharacterButtonBlue()
    {
        PlayerPrefs.SetInt("BlueCharacterIndex", ThisButtonInt);

    }


    public void SelectCamera()
    {
        if (CurrentCam == 1)
        {
            CurrentCam = 0;
            PlayerPrefs.SetInt("SelectedCameraPP", 0);
        }
        else if(CurrentCam == 0)
        {
            CurrentCam = 1;
            PlayerPrefs.SetInt("SelectedCameraPP", 1);
        }

    }
    public void StartGameGreen()
    {
        
        if (!GreenReady)
        {
            GreenReady = true;
            
        }
        else GreenReady = false;


        if (BlueReady == true) 
        { 
            SceneManager.LoadScene("PreFireArenaOnOneDevice");
        }
    }

    public void StartGameBlue()
    {
        if (!BlueReady)
        {
            BlueReady = true;

        }
        else BlueReady = false;

        if (GreenReady == true)
        {
            SceneManager.LoadScene("PreFireArenaOnOneDevice");
        }
    }
}

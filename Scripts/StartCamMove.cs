using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartCamMove : MonoBehaviour
{
    public Vector3 TargertAngle = new Vector3(63.383f, -90f, 0f);
    private Vector3 CurrentAngle;
    public Transform StartPos, PlayPos;
    public GameObject[] Cameras;
    public int SelectedCamera;
    void Start()
    {
        CurrentAngle = transform.eulerAngles;
        SelectedCamera = PlayerPrefs.GetInt("SelectedCameraPP");
        StartCoroutine(CamCoroutine());
    }

    
    void Update()
    {
        //CameraNormal.transform.Rotate(Quaternion.Lerp(StartPos.rotation, PlayPos.rotation, 1f * Time.deltaTime));
        CurrentAngle = new Vector3(
            Mathf.LerpAngle(CurrentAngle.x, TargertAngle.x, Time.deltaTime *1f ),
            Mathf.LerpAngle(CurrentAngle.y, TargertAngle.y, Time.deltaTime *1f),
            Mathf.LerpAngle(CurrentAngle.z, TargertAngle.z, Time.deltaTime *1f));

        transform.eulerAngles = CurrentAngle;
    }

    public IEnumerator CamCoroutine()
    {
        yield return new WaitForSeconds(3);
        if(SelectedCamera>0)
        {
            Cameras[SelectedCamera].GetComponent<Camera>().enabled = true;
            Cameras[0].GetComponent<Camera>().enabled = false;

        }
    }
}

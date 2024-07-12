using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    private int TriggerCount = 0;
    private bool PickUpT = false;
    private bool PickUp_T = false;
    private bool FallingT = false;
    private bool Part2 = false;
    private bool DeathBlock = false;
    private bool Level3 = false;


    void Start()
    {

    }
    IEnumerator StartPart2()
    {
        yield return new WaitForSeconds(6);
        transform.position = new Vector3(0, 14, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Text4.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text1.SetActive(false);
    }
    IEnumerator StartPart3()
    {
        yield return new WaitForSeconds(4);
        transform.position = new Vector3(0.07f, 27.41f, -21.82f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Text6.SetActive(true);
        Text5.SetActive(false);
        Text4.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text1.SetActive(false);
    }
    IEnumerator GoBackToCameraSelector()
    {
        yield return new WaitForSeconds(10);
        transform.position = new Vector3(0.33f, 39.77f, -21.1f);
        PlayerController PC = GetComponent<PlayerController>();
        PC.SetState("Normal");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    void Update()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        if (!Part2 && PickUpT && PickUp_T && FallingT)
        {
            Part2 = true;
            StartCoroutine(StartPart2());
        }
        if (DeathBlock == true)
        {
            DeathBlock = false;
            StartCoroutine(StartPart3());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "-PickUp")
        {
            PickUp_T = true;
            if (PickUpT == true)
            {
                Text2.SetActive(false);
                Text3.SetActive(false);
            }
            else
            {
                Text1.SetActive(false);
                Text2.SetActive(true);
            }
            Text4.SetActive(false);
        }
        if (other.gameObject.tag == "PickUp" && PickUpT == false)
        {
            PickUpT = true;
            if (PickUp_T == true)
            {
                Text2.SetActive(false);
                Text2.SetActive(true);
                Text3.SetActive(true);
            }
            else
            {
                Text2.SetActive(true);
                Text3.SetActive(true);
            }
            Text1.SetActive(false);
            Text4.SetActive(false);
        }
        if (other.gameObject.tag == "TextTrigger")
        {
            FallingT = true;
            Text4.SetActive(true);
            Text2.SetActive(false);
            Text3.SetActive(false);
        }
        if (other.gameObject.tag == "TextTrigger2")
        {
            PickUp_T = false; 
            Text5.SetActive(true);
            other.gameObject.SetActive(false);
            Text4.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text1.SetActive(false);
        }
        if (other.gameObject.tag == "DeathTrigger")
        {
            DeathBlock = true; 
        }
        if (other.gameObject.tag == "GoToPart4")
        {
            transform.position = new Vector3(0.33f, 39.77f, -21.1f);
        }



        if (other.gameObject.tag == "CameraDownTP")
        {
            transform.position = new Vector3(-78.37f, -9, 124);
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "CameraLeftTP")
        {
            transform.position = new Vector3(-156, -9, 14);
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "CameraFlipTP")
        {
            transform.position = new Vector3(-38, -9, -114);
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "FirstPersonTP")
        {
            transform.position = new Vector3(117, -9, -41);
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "ThirdPersonTP")
        {
            transform.position = new Vector3(66, -9, 102);
            StartCoroutine(GoBackToCameraSelector()); 
        }
        //other.gameObject.SetActive(false);
    }
}
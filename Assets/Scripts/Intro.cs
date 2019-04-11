using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public GameObject letter1;
    public GameObject letter2;

    bool letterSwitch = true;

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0) && letterSwitch == true)
        {
            letter1.SetActive(false);
            //letter2.SetActive(true);
            letterSwitch = false;
        }

        if (Input.GetKey(KeyCode.Mouse0) && letterSwitch == false)
        {
            letter2.SetActive(false);
        }
    }
}

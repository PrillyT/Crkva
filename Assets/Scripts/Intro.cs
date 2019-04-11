using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public GameObject letter;

    public void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            letter.SetActive(false);
        }
    }
}

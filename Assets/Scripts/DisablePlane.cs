using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlane : MonoBehaviour
{

    public GameObject Floor;
    public GameObject CrkvaColliders;

    void OnTriggerEnter (Collider TrapDoorTrigger)
    {
        Floor.SetActive(false);
        CrkvaColliders.SetActive(false);
    }
}

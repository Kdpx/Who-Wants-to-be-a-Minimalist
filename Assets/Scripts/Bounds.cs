using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Having issues with objects going through walls because they are set as Trigger
public class Bounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Drag>().Disable();

        new WaitForSeconds(1);

        other.GetComponent<Drag>().Enable();
    }
}

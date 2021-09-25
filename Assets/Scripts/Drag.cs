using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mOffset;

    private bool isActive = true;

    private float mZCoord;


    void OnMouseDown()

    {
        if (isActive)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {
        if (isActive)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);

            //Might be where i add the reset rotation script
        }

        //Resets Rotation in order to give the player a better view
        if(Input.GetKeyDown(KeyCode.R) == true)
        {
            this.transform.rotation = Quaternion.identity;
        }
    }


    //To make it uninteractable
    public void Disable()
    {
        isActive = false;
    }

    public void Enable()
    {
        isActive = true;
    }


}

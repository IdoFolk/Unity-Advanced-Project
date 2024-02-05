using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimHandler : MonoBehaviour
{
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
        Debug.Log(mousePos);
        transform.LookAt(mousePos);
    }
}

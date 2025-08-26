using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows;

public class Weapon : MonoBehaviour
{

    public Transform FirePoint;

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

    }
}

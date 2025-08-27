using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;

    public PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnFire()
    {
        GameObject bulletInstance = Instantiate(Bullet, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Bullet>().direction = playerMovement._lastDirectionIndex;
    }

}

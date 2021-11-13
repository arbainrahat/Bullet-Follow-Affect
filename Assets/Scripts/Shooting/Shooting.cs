using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletFirePosition;
    RaycastHit hit;
    public BulletFollow bulletFollow;
    public  bool canFollow = false;
    public static Shooting inst;
    public LayerMask targetMask;

    private void Awake()
    {
        inst = this;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward,out hit,50.0f,targetMask)){
            if (hit.transform.CompareTag("Target"))
            {
                if (!bulletFollow.bullet)
                {
                    canFollow = true;
                  //  print("Hit Target"+ canFollow);
                }
                
            }
            
        }
        else
        {

            canFollow = false;
            // print("Noooot Target");

        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, bulletFirePosition.position, bulletFirePosition.rotation);
        }
    }

    
}

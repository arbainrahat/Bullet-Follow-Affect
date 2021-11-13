using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 0.5f;

    private void Start()
    {
        if (Shooting.inst.canFollow)
        {
            Shooting.inst.bulletFollow.bullet = transform;
            Shooting.inst.canFollow = false;
        }
        BulletDestroy();
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Target"))
        {
            Shooting.inst.bulletFollow.bullet = null;
            Shooting.inst.bulletFollow.ResetCamera();
        }
    }

    private void BulletDestroy()
    {
        Destroy(gameObject, 1.5f);
    }
}

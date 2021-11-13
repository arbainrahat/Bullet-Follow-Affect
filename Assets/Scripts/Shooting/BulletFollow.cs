using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    public  Transform bullet;
    [SerializeField] private Vector3 offSet;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (bullet)
        {
            Time.timeScale = 0.2f;
            gameObject.GetComponent<Camera>().depth = 0f;
            transform.position = Vector3.SmoothDamp(transform.position, bullet.transform.position + offSet, ref velocity, smoothTime);
        }
       
    }

    public void ResetCamera()
    {
        gameObject.GetComponent<Camera>().depth = -2f;
        Time.timeScale = 1f;
        transform.position = startPosition;
    }
}

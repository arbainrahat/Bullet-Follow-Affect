using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonPlayermovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float turnSmoothTime = 0.1f;
    public Transform cam;

    float turnSmoothVelcoity;

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelcoity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f,angle,0f);

            //rotate the player with camera;
            Vector3 movDir = Quaternion.Euler(0f, angle, 0f)*Vector3.forward;

            controller.Move(movDir * speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Hit the Object !");

            SceneManager.LoadScene("Level Selection");


        }
    }

}

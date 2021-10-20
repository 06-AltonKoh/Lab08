﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject PlayerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObj.transform.position.y > -3.5 && PlayerObj.transform.position.y < 5.5)
        {
            float verticalInput = Input.GetAxis("Vertical");

            transform.position = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);
        }   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

}

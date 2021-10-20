using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public int PointCount;
    public Text PointTxt;
    public GameObject PlayerObj;
    AudioSource As;
    public AudioClip[] Effects;
    // Start is called before the first frame update
    void Start()
    {
        As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerObj.transform.position.y > -3.5 && PlayerObj.transform.position.y < 5.5)
        {
            float verticalInput = Input.GetAxis("Vertical");

            transform.position = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);
        }   
        if(PointCount == 20)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            PointCount += 1;
            PointTxt.text = "Score: " + PointCount;
            As.PlayOneShot(Effects[0]);
        }
    }

}

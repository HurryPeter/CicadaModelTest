using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public Rigidbody playerRB;
    public Transform playerCam, toy;
    public float speed;
    public SonarSkill SonarSkill;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        SonarSkill = GameObject.Find("HitBox").GetComponent<SonarSkill>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            playerRB.velocity = playerCam.forward * speed;
            SonarSkill.frequency = 0;

        }
        this.gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*2, 0));

        toy.Rotate(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse X"));
        
      
    }

    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerAction : MonoBehaviour
{
    public float DefaultSpeed = 1;
    public Transform Orientation;
    public GameObject prefab;
    Test_SonarBehavior test_SonarBehavior;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;
    // Update is called once per frame

    void Start()
    {
    }
    void Update()
    {
        MyInput();
        if (Input.GetMouseButtonDown(0))
        {
            test_SonarBehavior = prefab.GetComponent<Test_SonarBehavior>();
            Instantiate(prefab, Orientation.position - new Vector3(0, test_SonarBehavior.SonarScale + 1, 0), Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        moveDir=Orientation.forward*verticalInput+Orientation.right*horizontalInput;
        transform.position+=moveDir*DefaultSpeed;
    }
    void MyInput()
    {
        horizontalInput=Input.GetAxisRaw("Horizontal");
        verticalInput=Input.GetAxisRaw("Vertical");
    }
}

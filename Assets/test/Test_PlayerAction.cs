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
    int SonarModeIndex = 0;
    float sonarTimer=0;
    public float freq;
    Vector3 moveDir;
    // Update is called once per frame

    void Start()
    {
        test_SonarBehavior = prefab.GetComponent<Test_SonarBehavior>();
    }
    void Update()
    {
        UserInput();
        switchSonarMode();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        moveDir = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        transform.position += moveDir * DefaultSpeed;
    }
    void UserInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void switchSonarMode()//Change sonar mode to auto spawn sonar by mouse clicked;
    {
        sonarTimer+=Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (SonarModeIndex < 3)
            {
                SonarModeIndex++;
            }
            else
            {
                SonarModeIndex = 0;
            }
        }
        switch (SonarModeIndex)
        {
            case 0: //don't spawn sonar
                Debug.Log("case 0 :" + SonarModeIndex);
                break;

            case 1: //spawn sonar in low freq
                if (sonarTimer>=freq+3)
                {
                    sonarTimer=0;
                    Instantiate(prefab, Orientation.position - new Vector3(0, test_SonarBehavior.SonarScale + 1, 0) , Quaternion.AngleAxis(-90,Vector3.right));
                }
                Debug.Log("case 1 :" + SonarModeIndex);

                break;
            case 2: //spawn sonar in mediium freq
                if (sonarTimer>=freq+1.5f)
                {
                    sonarTimer=0;
                    Instantiate(prefab, Orientation.position - new Vector3(0, test_SonarBehavior.SonarScale + 1, 0), Quaternion.AngleAxis(-90,Vector3.right));
                }
                Debug.Log("case 2 :" + SonarModeIndex);

                break;
            case 3: //spawn sonar in high freq
                if (sonarTimer>=freq+0.5f)
                {
                    sonarTimer=0;
                    Instantiate(prefab, Orientation.position - new Vector3(0, test_SonarBehavior.SonarScale + 1, 0), Quaternion.AngleAxis(-90,Vector3.right));
                }
                Debug.Log("case 3 :" + SonarModeIndex);

                break;
        }
    }

}

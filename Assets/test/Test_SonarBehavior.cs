using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SonarBehavior : MonoBehaviour
{
    public float SonarScale;
    public float Speed;
    float Distance;
    GameObject InstancePoint;
    void Start()
    {
        InstancePoint=GameObject.Find("Player/InstancePoint");
        GameObject.Find("Text").GetComponent<MeshRenderer>().enabled=false;
        transform.localScale *= SonarScale;
    }
    void Update()
    {
        Move();
    }
    void ScaleUp()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(SonarScale, SonarScale, SonarScale), .5f * Time.deltaTime);
        if (transform.localScale.x >= SonarScale - 1)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        Vector3 playerPosition=InstancePoint.transform.position;
        transform.position = new Vector3(playerPosition.x,playerPosition.y+Distance,playerPosition.z);
        transform.position += new Vector3(0,Speed*Time.deltaTime,0);
        Distance += Speed*Time.deltaTime;
        if (Distance >= SonarScale/2)
        {
            Destroy(this.gameObject);
            Distance=0;
        }
    }

}

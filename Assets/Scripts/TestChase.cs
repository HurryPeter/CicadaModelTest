using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestChase : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public float offset, count, curoffset;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count >= 2)
        {
            count = 0;
            offset = Random.Range(-50, 50);
            curoffset = offset;
        }

        else offset = curoffset;
        

        //offset = Random.Range(r1, r2);
        agent.SetDestination(target.position + new Vector3(curoffset,0,0));

        float distance = 0;
        distance = Vector3.Distance(this.transform.position, target.position);
        if(distance<=10)
        {
                transform.LookAt(target);
                agent.SetDestination(target.position);
        }
    }
}

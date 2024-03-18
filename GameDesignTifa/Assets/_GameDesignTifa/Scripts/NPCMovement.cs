using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject theDestination;
    public GameObject finalDestination;
    public GameObject NpcCat;
    public int pivotPoint = 0;
    NavMeshAgent theAgent;


    // Start is called before the first frame update
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        theAgent.SetDestination(theDestination.transform.position);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Destination Cube")
        {
            theAgent.SetDestination(finalDestination.transform.position);
        }
        if (col.gameObject.name == "FinalDestinationCube")
        {
            Destroy(NpcCat);
        }
    }
}

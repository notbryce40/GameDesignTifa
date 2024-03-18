using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject spawnCube;
    public GameObject registerCube;
    public GameObject finalDestinationCube;
    public GameObject NpcCatPrefab;

    private bool orderCompleted = false;
    private NavMeshAgent theAgent;
    private GameObject npcCatInstance;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the NPC from the prefab at the spawnCube's position
        npcCatInstance = Instantiate(NpcCatPrefab, spawnCube.transform.position, Quaternion.identity);
        
        // Get the NavMeshAgent component from the instantiated NPC
        theAgent = npcCatInstance.GetComponent<NavMeshAgent>();
        
        // Set the first destination to the registerCube
        theAgent.SetDestination(registerCube.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance to the registerCube and if the order is not completed
        if (!orderCompleted && Vector3.Distance(npcCatInstance.transform.position, registerCube.transform.position) < 1.0f)
        {
            // Logic to create an order can be added here
            orderCompleted = true;

            // Set the destination to the finalDestinationCube
            theAgent.SetDestination(finalDestinationCube.transform.position);
        }

        // Check if the NPC has reached the finalDestinationCube
        if (orderCompleted && Vector3.Distance(npcCatInstance.transform.position, finalDestinationCube.transform.position) < 1.0f)
        {
            // Despawn the NPC
            Destroy(npcCatInstance);
        }
    }
}

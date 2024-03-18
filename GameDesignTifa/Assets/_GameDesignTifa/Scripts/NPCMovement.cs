using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject spawnCube;
    public GameObject registerCube;
    public GameObject finalDestinationCube;
    public GameObject NpcCatPrefab;

    private NavMeshAgent theAgent;
    private GameObject npcCatInstance;

    //Order System
    public int coinsEarned = 10;
    public bool orderCompleted = false;
    
    public enum OrderItem { Chips, Fish, Coke, Yogurt }
    public OrderItem[] currentOrder; // should have the items stored in the array

    void Start()
    {
        npcCatInstance = Instantiate(NpcCatPrefab, spawnCube.transform.position, Quaternion.identity);
        theAgent = npcCatInstance.GetComponent<NavMeshAgent>();
        theAgent.SetDestination(registerCube.transform.position);

        GenerateRandomOrder();
    }

    void Update()
    {
        if (!orderCompleted && Vector3.Distance(npcCatInstance.transform.position, registerCube.transform.position) < 1.0f)
        {
            
            
            Debug.Log("Order has not been completed yet");

            if (orderCompleted == true)
            {
                Debug.Log("Order completed. Coins earned: " + coinsEarned);
                theAgent.SetDestination(finalDestinationCube.transform.position);
            }
            
    
        }

        if (orderCompleted && Vector3.Distance(npcCatInstance.transform.position, finalDestinationCube.transform.position) < 1.0f)
        {
            Destroy(npcCatInstance);
        }
    }

    public void GenerateRandomOrder() // Generates order of up to size 4
    {
        int orderSize = Random.Range(1, 5);
        currentOrder = new OrderItem[orderSize];

        for (int i = 0; i < orderSize; i++)
        {
            currentOrder[i] = (OrderItem)Random.Range(0, System.Enum.GetValues(typeof(OrderItem)).Length);
        }

        Debug.Log("Generated order: " + string.Join(", ", currentOrder));
    }

    public bool IsOrderFulfilled()
    {
        return currentOrder.Length > 0;
    }
}

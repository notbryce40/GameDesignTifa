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

    private bool orderCompleted = false;
    private int coinsEarned = 10;
    private OrderItem[] currentOrder;
    private enum OrderItem { Chips, Fish, Coke, Yogurt }

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

    private void GenerateRandomOrder()
    {
        int orderSize = Random.Range(1, 5);
        currentOrder = new OrderItem[orderSize];

        for (int i = 0; i < orderSize; i++)
        {
            currentOrder[i] = (OrderItem)Random.Range(0, System.Enum.GetValues(typeof(OrderItem)).Length);
        }

        Debug.Log("Generated order: " + string.Join(", ", currentOrder));
    }

    private bool IsOrderFulfilled()
    {
        return currentOrder.Length > 0;
    }
}

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

    public CoinCounterUI coinCounter; //reference to the coin counter

    //Order System
    public bool orderCompleted = false;
    public bool orderGenerated = false;
    
    public enum OrderItem { Chips, Fish, Coke, Yogurt }
    public OrderItem[] currentOrder; // should have the items stored in the array

    void Start()
    {
        npcCatInstance = Instantiate(NpcCatPrefab, spawnCube.transform.position, Quaternion.identity);
        theAgent = npcCatInstance.GetComponent<NavMeshAgent>();
        theAgent.SetDestination(registerCube.transform.position);
        
        coinCounter = FindObjectOfType<CoinCounterUI>();

       
    }

    void Update()
    {
        if (!orderCompleted && Vector3.Distance(npcCatInstance.transform.position, registerCube.transform.position) < 1.0f)
        {
            if (!orderGenerated)
            {
                GenerateRandomOrder();
                orderGenerated = true;
                Debug.Log("Order generated");
                orderCompleted = true;

            }
            

            if (orderCompleted == true)
            {
               
                Debug.Log("Order completed.");
                coinCounter.UpdateTotalCoins();

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

}

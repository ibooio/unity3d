using UnityEngine;
using UnityEngine.AI;

public class navMeshController : MonoBehaviour
{


    public bool newDestination=false;
    public Vector3 destination;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(newDestination){
            agent.destination = destination;
            newDestination = false;
        }
    }

    public void setDestination(Vector3 d){
        destination=d;
        newDestination= true;
    }

}

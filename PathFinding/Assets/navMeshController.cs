using UnityEngine;
using UnityEngine.AI;

public class navMeshController : MonoBehaviour
{

    public Transform objective;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = objective.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void moveObjective(){
        objective.position = new Vector3(Random.Range(0,5), objective.position.y, objective.position.z);
    }

}

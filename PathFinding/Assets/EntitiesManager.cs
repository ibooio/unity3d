using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesManager : MonoBehaviour
{


    public GameObject buildingsGroup;
    public GameObject personsGroup;

    private List<Transform> buildings;

    private List<Transform> persons;


    // Start is called before the first frame update
    void Start()
    {
        buildings = new List<Transform>();
        persons = new List<Transform>();
        foreach (Transform child in buildingsGroup.transform)
        {
            if( child.name != "Cube" )
                buildings.Add(child);
        }

        foreach (Transform child in personsGroup.transform)
        {
            persons.Add(child);
        }
        this.setObjectives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setObjectives(){
        foreach (Transform p in persons)
        {
            var script = p.GetComponent<navMeshController>();
            Debug.Log(script);
            var randBuilding= buildings[Random.Range(0,buildings.Count)];
            Debug.Log(randBuilding.transform.position);
            script.setDestination(randBuilding.transform.position);
        }

    }
}


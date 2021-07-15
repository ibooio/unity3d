using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PersonsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject person;
    public List<GameObject> persons;


    private Color[] colors= new Color[]{ Color.red, Color.green, Color.magenta, Color.yellow };
    private string[] names= new string[]{ "Ale", "Unla", "Fonce", "Emma" };

    private int velocity;

    void Start()
    {

        velocity = TimeManager.velocity;
        // creamos cuatro personitas
        for (int i = 0; i < 4; i++)
        {
           GameObject newPerson = Instantiate(person, new Vector3(0, 1, 5 + (i*2)), Quaternion.identity);
           newPerson.GetComponent<Renderer>().material.color = colors[i];

           newPerson.GetComponent<Person>().SetData(new PersonData(names[i]));

           persons.Add(newPerson);
        }

        // le pedimos a cada personita que se presente
        foreach(GameObject person in persons) {
            person.GetComponent<Person>().Hello();
            person.GetComponent<NavMeshAgent>().destination = new Vector3(40,1,30);
            person.GetComponent<NavMeshAgent>().speed = 3.5f * velocity;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if( TimeManager.velocity != velocity ){
            velocity = TimeManager.velocity;
            foreach(GameObject person in persons) {
                person.GetComponent<NavMeshAgent>().speed = 3.5f * velocity;
            }
        }
    }
}

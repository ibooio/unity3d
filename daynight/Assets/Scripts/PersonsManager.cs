using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PersonsManager : MonoBehaviour
{
    [SerializeField] private Velocity velocity;
    // Start is called before the first frame update
    public GameObject person;
    public List<GameObject> persons;


    private Color[] colors= new Color[]{ Color.red, Color.green, Color.magenta, Color.yellow };
    private string[] names= new string[]{ "Ale", "Unla", "Fonce", "Emma" };

    void Start()
    {

        velocity.OnVelocityChange += OnVelocityChange;
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
            person.GetComponent<NavMeshAgent>().destination = new Vector3(0,1,-10);
            person.GetComponent<NavMeshAgent>().speed = 3.5f * velocity.GetValue();
        }
    }

    private void OnVelocityChange(object sender, EventArgs e){
        Debug.Log("funsafdsafsaf safsa2a");

        foreach(GameObject person in persons) {
            person.GetComponent<NavMeshAgent>().speed = 3.5f * velocity.GetValue();
        }
    }


}

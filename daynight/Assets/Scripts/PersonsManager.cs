using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject person;
    public List<GameObject> persons;
    void Start()
    {
        List<Color> colors = new List<Color>();
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.magenta);


        List<string> names = new List<string>();
        names.Add("Pepe");
        names.Add("Fulano");
        names.Add("Mengano");


        for (int i = 0; i < 3; i++)
        {
           GameObject newPerson = Instantiate(person, new Vector3(0, 1, 5 + (i*2)), Quaternion.identity);
           newPerson.GetComponent<Renderer>().material.color = colors[i];

           newPerson.GetComponent<Person>().SetData(new PersonData(names[i]));

           persons.Add(newPerson);
        }


        foreach(GameObject person in persons) {
            person.GetComponent<Person>().Hello();
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

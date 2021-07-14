using UnityEngine;

public class PersonData
{
    private string Name;

    public PersonData(string Name){
        this.Name = Name;
    }

    public void Test(){
        Debug.Log("Mi nombre es " + this.Name);
    }

}

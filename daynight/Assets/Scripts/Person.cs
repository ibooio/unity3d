using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    // Start is called before the first frame update
    private PersonData Data;

    public void SetData(PersonData data){
        Data = data;
    }

    public void Hello(){
        Data.Test();
    }
}

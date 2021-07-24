using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Velocity", menuName = "Scriptable objects/Velocity", order = 0)]
public class Velocity : ScriptableObject {

    public event EventHandler OnVelocityChange;

    [SerializeField]    
    private int value;

    public int GetValue(){
        return value;
    }

    public void SetValue(int value){
        this.value = value;
        OnVelocityChange?.Invoke(this, EventArgs.Empty);
    }


}

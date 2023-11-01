using UnityEngine;

public abstract class Conditioner : MonoBehaviour
{  
    public abstract bool CheckCondition(); 
    public abstract void DoEvent();
}
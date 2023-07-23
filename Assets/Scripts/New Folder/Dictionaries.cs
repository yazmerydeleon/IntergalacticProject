using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionaries : MonoBehaviour
{
    Dictionary<string, int> _AnimalJumpAbility;

    [SerializeField] private string key = "Spot";
    // Start is called before the first frame update
    void Start()
    {
        _AnimalJumpAbility = new Dictionary<string, int>();
        AddDataToDictionary();

        string name = "Lima";

        Debug.Log(_AnimalJumpAbility.ContainsKey(name));
    }

    private void AddDataToDictionary()
    {
        _AnimalJumpAbility.Add("Spot", 3);
        _AnimalJumpAbility.Add("Tick", 100);
        _AnimalJumpAbility.Add("Greg", 0);

        //Duplicate key
        _AnimalJumpAbility.Add("Scoot", 3);
    }

    private void CheckIfKeyAvailable()
    {
        if(_AnimalJumpAbility.ContainsKey(key))
        {
            Debug.Log("Contains this key");
        }
        else
        {
            Debug.Log("Does not contain this key!");
        }
    }

    private void RemoveKey()
    {
        _AnimalJumpAbility.Remove("Tick");
    }
}

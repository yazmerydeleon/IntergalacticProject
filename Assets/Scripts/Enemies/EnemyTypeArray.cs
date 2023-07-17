using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeArray
{
    public GameObject[] enemyTypeArray;

   
    public GameObject RandomEnemyType()
    {
        if(enemyTypeArray == null || enemyTypeArray.Length == 0)
        {
            Debug.LogError("No GameObjects in the array!");
            return null;
        }
        
        // Generate a random index within the range of the array
        int randomIndex = Random.Range(0, enemyTypeArray.Length);

        return enemyTypeArray[randomIndex];      
                    

    }

}

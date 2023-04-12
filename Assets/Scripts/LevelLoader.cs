using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    void Start()
    {
        Player player = new Player();

        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();

        Weapon gunWeapon1 = new Weapon();
        Weapon gunWeapon2 = new Weapon("Laser", 100.0f);

        //Enums
        EnemyType enemyType1 = new EnemyType();
        enemyType1 = EnemyType.Melee;

        EnemyType enemyType2 = EnemyType.MachineGunner;

        //Distribute weapons
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();

        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();

        Enemy.SubtractEnemy();

        Debug.Log(Enemy.numberOfEnemies);

        Weapon gun1 = new Weapon();

        EnemyType enemyType1 = new EnemyType();
        enemyType1 = EnemyType.Melee;

        EnemyType enemyType2 = EnemyType.MachineGunner;

        player.weapon= gun1;
    }

}

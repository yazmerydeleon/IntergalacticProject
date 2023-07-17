using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : MeleeEnemy
{
    public override void AttackAnimation()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}

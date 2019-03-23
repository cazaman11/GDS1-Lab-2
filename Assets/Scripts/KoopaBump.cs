using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaBump : MonoBehaviour {

    //This is so koopa troopas can detect collisions through their child objects
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponentInParent<KoopaTroopaMovement>()) {
            GetComponentInParent<KoopaTroopaMovement>().SwitchDirection(collision);
        }
    }
}

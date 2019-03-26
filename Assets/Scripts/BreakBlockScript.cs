using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlockScript : MonoBehaviour {

    bool hit = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && hit && collision.gameObject.name != "Koopa Troopa Body")
        {
            //Debug.Log("Goomba on block");
            //collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<NPCMovement>().Die();
        }
        else if(collision.gameObject.tag == "Enemy" && hit && collision.gameObject.name == "Koopa Troopa Body")
        {
            collision.gameObject.GetComponentInParent<KoopaTroopaMovement>().OnStomp();
        }
        else if (collision.gameObject.tag == "Magic Mushroom" && hit|| collision.gameObject.tag == "1Up" && hit)
        {
            collision.gameObject.GetComponent<MagicMushroomMovement>().SwitchDirection(collision);
            //collision.gameObject.GetComponent<MagicMushroomMovement>().SetDirection(true);
            Debug.Log("Is this calling?");
        }
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mario" && other.gameObject.GetComponent<PlayerController>().currentState != 0) //&& collision.gameObject.GetComponent<PlayerController>().getJump())
        {
            //run animation and call points
            hit = true;
            Break();
        }
        else if (other.gameObject.name == "Mario" && other.gameObject.GetComponent<PlayerController>().currentState == 0)
        {
            hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Mario")
        {
            hit = false;
        }
    }

    private void Break()
    {
        GameObject.Find("GameManager").GetComponent<ScoreManager>().AddPoints(50);
        gameObject.SetActive(false);
    }
}

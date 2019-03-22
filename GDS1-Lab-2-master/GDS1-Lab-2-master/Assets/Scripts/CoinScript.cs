using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
    private AudioSource coinSfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Mario")
        {
           // coinSfx.Play();         
            gameObject.SetActive(false);
            GameObject.Find("GameManager").GetComponent<CoinManager>().IncreaseCoin();
        }
    }
}

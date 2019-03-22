using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPersistanceScript : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

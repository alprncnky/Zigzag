﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCherker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag=="Ball")
        {
            Invoke("FallDown", 0.4f);       //fonksiyonu 0.4 saniye sonra cagir
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);        // 2 saniye sonra dusen platformu sil
    }
}

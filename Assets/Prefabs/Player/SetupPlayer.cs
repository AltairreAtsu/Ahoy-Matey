﻿using UnityEngine;
using UnityEngine.Networking;

public class SetupPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            GetComponent<PlayerController>().enabled = true;
        }
	}
	

}

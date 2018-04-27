using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCheck : MonoBehaviour {

    private Player player;

	void Awake ()
    {
        player = GetComponentInParent<Player>();
	}

    private void OnTriggerEnter(Collider other)
    {
        player.isBlocked = true;
    }

    private void OnTriggerStay(Collider other)
    {
        player.isBlocked = true;
    }

    private void OnTriggerExit(Collider other)
    {
        player.isBlocked = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player;

	void Awake ()
    {
        player = GetComponentInParent<Player>();
	}

    private void OnTriggerEnter(Collider other)
    {
        player.isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        player.isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        player.isGrounded = false;
    }
}

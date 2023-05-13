using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollisions : MonoBehaviour
{
	PlayerHealth health;
	private void Awake()
	{
		health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
	}/*
	private void OnTriggerEnter(Collider col)
	{
		if (col.transform.tag == "PlayerCollider")
		{
			//health.Damage(2);
			
		}
	}*/
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			//collider.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
			health.TakeDamage(20);
			//Player.GetComponent<PlayerHealth>().Revenge(1);
			Debug.Log("aaaaaaaaaa");
		}
	}

}

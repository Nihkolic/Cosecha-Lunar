using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollisions : MonoBehaviour
{
	bool isAttacking;
	private void Awake()
	{
		isAttacking = true; //for now
	}
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			if (isAttacking)
			{
				Attack(collider);
				print("sddddddddddddddddd");
			}/*
			else if (isAttacking)
			{

			}*/
		}
	}
	void Attack(Collider collider)
	{
		collider.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
	}
}
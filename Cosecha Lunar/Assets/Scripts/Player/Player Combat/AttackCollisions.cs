using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisions : MonoBehaviour
{
	[SerializeField] private GameObject Player;

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			collider.transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(30f,true);
			//Player.GetComponent<PlayerHealth>().Revenge(10);
		}
	}
}

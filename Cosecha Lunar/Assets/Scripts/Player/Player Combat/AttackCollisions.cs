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
			collider.transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(60f,true);
			//Player.GetComponent<PlayerHealth>().Revenge(10);
		}
		if (collider.gameObject.layer == LayerMask.NameToLayer("Boss"))
		{
			//GetComponent<Collider>().transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
			collider.transform.gameObject.GetComponent<BossHealth>().DamageEnemy(50);
		}
	}
}

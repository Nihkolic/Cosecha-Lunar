using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisions : MonoBehaviour
{
	[SerializeField] private GameObject Player;

	/*
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Target")
		{
			
			FindObjectOfType<HitStop>().Stop(0.03f);

			//Toggle "isHit" on target object
			collision.transform.gameObject.GetComponent
				<TargetScript>().isHit = true;
			
			collision.transform.gameObject.GetComponent
				<EnemyHitStop>().isHit = true;
		}
	}*/
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Enemy")
		{
			//FindObjectOfType<HitStop>().Stop(0.05f);//0.03f
			/*
			//Toggle "isHit" on target object
			col.transform.gameObject.GetComponent
				<TargetScript>().isHit = true;*/
			/*
			col.transform.gameObject.GetComponent
				<EnemyHitStop>().isHit = true;*/
			collider.transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
			Player.GetComponent<PlayerHealth>().Revenge(1);


		}
		/*
		if (col.transform.tag == "Enemy")
		{

			FindObjectOfType<HitStop>().Stop(0.03f);
			col.transform.gameObject.GetComponent
				<EnemyHitStop>().isHit = true;

		}*/
	}
}

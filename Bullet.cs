using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {



	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bullet")
			return;
		var hit = collision.gameObject;
		var health = hit.GetComponent<ZombieHealth>();
		if (health  != null)
		{
			health.TakeDamage(50);
		}

		Destroy(gameObject);
	}
	
	public void setDamage(int d){
		this.damage = d;
	}
}

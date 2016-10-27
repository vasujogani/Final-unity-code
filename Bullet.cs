using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int damage = 1;

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bullet")
			return;
		Debug.LogError ("The damage of the bullet is: " + damage);
		Destroy(gameObject);
	}

	public void setDamage(int d){
		this.damage = d;
	}
}

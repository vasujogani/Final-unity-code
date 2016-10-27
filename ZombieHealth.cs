using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZombieHealth : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
			gameObject.GetComponent<AISpawn> ().removeMe ();
			Destroy (gameObject);
		}

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}
}
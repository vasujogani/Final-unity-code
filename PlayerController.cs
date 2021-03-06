﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public Camera cam;
	public int speed;

	float timer;

	public Gun[] guns;

	int[] intialBullets;
	int currentGun = 0;

	GunUIUpdate gunUpdater;

	void Start(){
		intialBullets = new int[guns.Length];
		enabled = true;
		intialBullets [0] = 30;
		intialBullets [1] = 20;
		intialBullets [2] = 35;
		gunUpdater = GetComponent<GunUIUpdate> ();
	}

	void Update()
	{
		timer += Time.deltaTime;

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x*speed, 0);
		transform.Translate(0, 0, z*speed);

		if ((Input.GetKey(KeyCode.Space)) && timer >= guns[currentGun].fireRate && guns [currentGun].bullets > 0 && Time.timeScale != 0)
		{
			Debug.LogError ("The amount of bullet is: " + guns [currentGun].bullets);
			CmdFire();
		}
		if (guns [currentGun].bullets <= 0) {
			gunUpdater.ReloadUpdate ();
		}
		if (guns [currentGun].bullets <= 0 && timer > guns[currentGun].reloadTime) {
			guns [currentGun].bullets = intialBullets[currentGun];
			timer = 0;
			gunUpdater.UpdateUI (guns [currentGun].bullets, guns [currentGun].name);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			ChangeGun ();
			gunUpdater.UpdateUI (guns [currentGun].bullets, guns [currentGun].name);
		}
	}

	// This [Command] code is called on the Client …
	// … but it is run on the Server!
	void CmdFire()
	{
		timer = 0;
		guns [currentGun].bullets--;
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

//		bullet.setDamage (guns [currentGun].damage);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);

		gunUpdater.UpdateUI(guns [currentGun].bullets, guns [currentGun].name);
	}

	public Gun getGun(){
		Debug.Log ("The current gun is " + guns [currentGun].name);
		return guns [currentGun];
	}

	void ChangeGun(){
		Debug.LogError ("The gun number was:" + currentGun);
		currentGun = (currentGun + 1) % guns.Length;
		Debug.LogError ("The new gun number is: " + currentGun);
	}
		
}
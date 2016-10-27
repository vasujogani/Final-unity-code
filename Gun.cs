using UnityEngine;
using System.Collections;

[System.Serializable]
public class Gun : ScriptableObject {
	public string weaponName = "Name here";
	public float fireRate = 10;
	public int bullets = 10;
	public int damage = 10;
	public double reloadTime = 10;
}

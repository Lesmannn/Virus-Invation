using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public ObjectPooling BulletPool;
	public Transform Muzzle;

	public int currentAmmo;
	public int maxAmmo;
	public bool infiniteAmmo;

	public float bulletSpeed;
	public float shootRate;
	private float lastShootTime;
	public bool isPlayer;

	void Awake()
	{
		if(GetComponent<Chara>())
		{
			isPlayer = true;
		}
	}
	public bool CanShoot()
	{
		if(Time.time - lastShootTime >= shootRate)
		{
			if(currentAmmo > 0 || infiniteAmmo == true)
			{
				return true;
			}
		}
		return false;
	}
	public void Shoot()
	{
		lastShootTime = Time.time;
		currentAmmo -= 1;

		if(isPlayer)
		{
			UIManager.instance.UpdateAmmoText(currentAmmo, maxAmmo);
		}

		GameObject bullet = BulletPool.GetObject();

		bullet.transform.position = Muzzle.position;


		bullet.GetComponent<Rigidbody2D>().velocity = Muzzle.right * bulletSpeed;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    // Start is called before the first frame update

    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem fx_shot;
    public GameObject fx_BulletFall;

    private Collider2D fireCollider;

    private WaitForSeconds wait_Time = new WaitForSeconds(0.02f);
    private WaitForSeconds fireColliderWait = new WaitForSeconds(0.02f);
    void Start()
    {
        if (!GamePlayController.instance.bullet_and_BulletFX_Created)
        {
            GamePlayController.instance.bullet_and_BulletFX_Created = true;
            if(nameWp != NameWeapon.FIRE && nameWp != NameWeapon.ROCKET)
            {
                SmartPool.instance.CreateBulletAndBulletFall(bulletPrefab, fx_BulletFall, 100);
                Debug.Log("Bullet Created");
            }
        }
        if (!GamePlayController.instance.rocket_Bullet_Created)
        {
            GamePlayController.instance.rocket_Bullet_Created = true;
            if(nameWp == NameWeapon.ROCKET){ 
                SmartPool.instance.CreateRocket(bulletPrefab, 100);
                Debug.Log("Fire from Rocket");
            }

        }
    }

    private void Update()
    {
        Debug.Log(nameWp);
        Debug.Log(GamePlayController.instance.rocket_Bullet_Created);
    }

    public override void ProcessAttack()
    {
        //base.ProcessAttack();

        switch (nameWp)
        {
            case NameWeapon.PISTOL:
                break;
            case NameWeapon.MP5:
                break;
            case NameWeapon.M3:
                break;
            case NameWeapon.ROCKET:
                break;
            case NameWeapon.FIRE:
                break;
            case NameWeapon.AK:
                break;
            case NameWeapon.AWP:
                break;
        }

        //SPAWN BULLET
        if((transform != null) && (nameWp != NameWeapon.FIRE))
        {
            if(nameWp != NameWeapon.ROCKET)
            {
                GameObject bullet_FallFX = SmartPool.instance.SpawnBulletFallFX(
                        spawnPoint.transform.position, Quaternion.identity
                    );

                bullet_FallFX.transform.localScale = (transform.root.eulerAngles.y > 1.0f) ? new Vector3(-1.0f, 1.0f, 1.0f) : new Vector3(1.0f, 1.0f, 1.0f);

                StartCoroutine(WaitforShootEffet());
            }

            SmartPool.instance.SpawnBullet(spawnPoint.transform.position, new Vector3(-transform.root.localScale.x, 0f, 0f), spawnPoint.rotation, nameWp);
        }

        else
        {
            StartCoroutine(ActivateFireCollider());
        }
    }

    IEnumerator WaitforShootEffet()
    {
        yield return wait_Time;
        fx_shot.Play();
    }

    IEnumerator ActivateFireCollider()
    {
        //fireCollider.enabled = true;
        fx_shot.Play();
        yield return fireColliderWait;
        //fireCollider.enabled = false;
    }
}

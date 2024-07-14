using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPool : MonoBehaviour
{
    public static SmartPool instance;

    public List<GameObject> bullet_Fall_FX = new List<GameObject>();
    public List<GameObject> bullet_Prefabs = new List<GameObject>();
    public List<GameObject> rocket_bullet_Prefab = new List<GameObject>();


    // Start is called before the first frame update
    void Awake()
    {
        makeInstance();
    }

    private void OnDisable()
    {
        instance = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void makeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void CreateBulletAndBulletFall(GameObject bullet, GameObject bulletFall, int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject temp_Bullet = Instantiate(bullet);
            GameObject temp_Bullet_Fall = Instantiate(bulletFall);

            bullet_Prefabs.Add(temp_Bullet);
            bullet_Fall_FX.Add(temp_Bullet_Fall);
            bullet_Prefabs[i].SetActive(false);
            bullet_Fall_FX[i].SetActive(false);
        }
    }

    public void CreateRocket(GameObject rocket, int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject temp_Rocket_Bullet = Instantiate(rocket);
            rocket_bullet_Prefab.Add(temp_Rocket_Bullet);
            rocket_bullet_Prefab[i].SetActive(false);
        }
    }

    public GameObject SpawnBulletFallFX(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < bullet_Fall_FX.Count; i++)
        {
            if (!bullet_Fall_FX[i].activeInHierarchy)
            {
                bullet_Fall_FX[i].SetActive(true);
                bullet_Fall_FX[i].transform.position = position;
                bullet_Fall_FX[i].transform.rotation = rotation;

                return bullet_Fall_FX[i];

            }
        }
        return null;
    }

    public void SpawnBullet(Vector3 position, Vector3 direction, Quaternion rotation, NameWeapon weaponName)
    {
        if(weaponName != NameWeapon.ROCKET)
        {
            for (int i = 0; i < bullet_Prefabs.Count; i++)
            {
                if (!bullet_Prefabs[i].activeInHierarchy)
                {
                    bullet_Prefabs[i].SetActive(true);
                    bullet_Prefabs[i].transform.position = position;
                    bullet_Prefabs[i].transform.rotation = rotation;

                    //GET BULLET SCRIPTS
                    bullet_Prefabs[i].GetComponent<BulletController>().setDirection(direction);
                    //SET BULLET DAMAGE
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < rocket_bullet_Prefab.Count; i++)
            {
                if (!rocket_bullet_Prefab[i].activeInHierarchy)
                {
                    rocket_bullet_Prefab[i].SetActive(true);
                    rocket_bullet_Prefab[i].transform.position = position;
                    rocket_bullet_Prefab[i].transform.rotation = rotation;

                    //GET BULLET SCRIPTS
                    rocket_bullet_Prefab[i].GetComponent<BulletController>().setDirection(direction);
                    //SET BULLET DAMAGE
                    break;
                }
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NameWeapon
{
    MELEE,
    PISTOL,
    MP5,
    M3,
    AK,
    AWP,
    FIRE,
    ROCKET
}

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    public DefaultConfig DefaultConfig;
    public NameWeapon nameWp;

    protected PlayerAnimations PlayerAnim;
    protected float LastShot;

    public int gunIndex;
    public int currentBullet;
    public int bulletMax;
    void Awake()
    {
        PlayerAnim = GetComponentInParent<PlayerAnimations>();
        currentBullet = bulletMax;
    }

    public void CallAttack()
    {
        if(Time.time > LastShot + DefaultConfig.FireRate)
        {
            if(currentBullet > 0)
            {
                ProcessAttack();
                PlayerAnim.AttackAnimation();

                LastShot = Time.time;
                currentBullet--;
            }
            else
            {
                //PLAY NO AMMO SOUND
            }
        }
    }//call attack


    public virtual void ProcessAttack()
    {

    }//ProcessAttack

    // Update is called once per frame
    void Update()
    {
        
    }
}

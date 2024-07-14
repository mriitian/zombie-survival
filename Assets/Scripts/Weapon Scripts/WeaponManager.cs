using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<WeaponController> weapon_Unlocked;
    public WeaponController[] total_Weapons;

    [HideInInspector]
    public WeaponController Current_weapon;

    private int current_Weapon_Index;
    private TypeControlAttack current_Type_Control;

    private PlayerArmController[] ArmController;
    private PlayerAnimations playerAnim;

    private bool isShooting;
    void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();
        LoadActiveWeapons();
        current_Weapon_Index = 1;

    }


    private void Start()
    {
        ArmController = GetComponentsInChildren<PlayerArmController>();
        playerAnim.SwitchWeapon((int)weapon_Unlocked[current_Weapon_Index].DefaultConfig.typeWeapon);

        ChangeWeapon(weapon_Unlocked[1]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadActiveWeapons()
    {
        weapon_Unlocked.Add(total_Weapons[0]);
        for (int i = 1; i < total_Weapons.Length; i++)
        {
            weapon_Unlocked.Add(total_Weapons[i]);
        }
    }

    public void SwitchWeapons()
    {
        current_Weapon_Index++;
        current_Weapon_Index = (current_Weapon_Index >= weapon_Unlocked.Count) ? 0 : current_Weapon_Index;
        playerAnim.SwitchWeapon((int)weapon_Unlocked[current_Weapon_Index].DefaultConfig.typeWeapon);

        ChangeWeapon(weapon_Unlocked[current_Weapon_Index]);
    }

        
    public void ChangeWeapon(WeaponController newWeapon)
    {
        if(Current_weapon) Current_weapon.gameObject.SetActive(false);

        Current_weapon = newWeapon;
        current_Type_Control = newWeapon.DefaultConfig.typeControl;

        newWeapon.gameObject.SetActive(true);

        if(newWeapon.DefaultConfig.typeWeapon == TypeWeapon.TwoHand)
        {
            for (int i = 0; i < ArmController.Length; i++)
            {
                ArmController[i].ChangetoTwoHand();
            }
        }
        else
        {
            for (int i = 0; i < ArmController.Length; i++)
            {
                ArmController[i].ChangetoOneHand();
            }
        }
    }

    public void Attack()
    {
        if(current_Type_Control == TypeControlAttack.Hold)
        {
            Current_weapon.CallAttack();
        }
        else if(current_Type_Control == TypeControlAttack.Click)
        {
            if (!isShooting)
            {

                Current_weapon.CallAttack();
                isShooting = true;
            }
        }
    }

    public void ResetAttack()
    {
        isShooting = false;
    }
}


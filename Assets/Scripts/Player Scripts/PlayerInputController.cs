using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    private WeaponManager weaponManager;
    [HideInInspector]
    public bool CanShoot;

    private bool isHoldAttack;
    // Start is called before the first frame update
    void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponManager.SwitchWeapons();
        }
        if (Input.GetKey(KeyCode.T))
        {
            isHoldAttack = true;
        }
        else
        {
            weaponManager.ResetAttack();
            isHoldAttack=false;
        }

        if(isHoldAttack && CanShoot)
        {
            weaponManager.Attack();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerRunAnim(bool run)
    {
        anim.SetBool("Run", run);
    }

    public void AttackAnimation()
    {
        anim.SetTrigger("Attack");
    }

    public void SwitchWeapon(int typeWeapon)
    {
        anim.SetInteger("TypeWeapon", typeWeapon);
        anim.SetTrigger("Switch");
    }

    public void Hurt()
    {
        anim.SetTrigger("GetHurt");
    }

    public void Dead()
    {
        anim.SetTrigger("Dead");
    }
}

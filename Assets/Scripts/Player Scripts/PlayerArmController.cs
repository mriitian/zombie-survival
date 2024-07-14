using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite one_Hand_Sprite, two_Hand_Sprite;
    private SpriteRenderer sr;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangetoOneHand()
    {
        sr.sprite = one_Hand_Sprite;
    }

    public void ChangetoTwoHand()
    {
        sr.sprite = two_Hand_Sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

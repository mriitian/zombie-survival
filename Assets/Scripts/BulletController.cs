using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int Damage;
    private float speed = 60f;
    private float defalut_Life_Time = 2f;
    private IEnumerator coroutineDeactivate;
    private Vector3 direction;

    public GameObject RocketExplosion;

    void Start()
    {
        if(this.tag == "RocketMissile")
        {
            speed = 8f;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        coroutineDeactivate = WaitForDeactivate();
        StartCoroutine(coroutineDeactivate);
    }
    private void OnDisable()
    {
        if(coroutineDeactivate != null)
        {
            StopCoroutine(coroutineDeactivate);
        }
    }


    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    IEnumerator WaitForDeactivate()
    {
        yield return new WaitForSeconds(defalut_Life_Time);
        gameObject.SetActive(false);
    }
}

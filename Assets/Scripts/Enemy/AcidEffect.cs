using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class AcidEffect : MonoBehaviour
{
    private void Start()
    {
       Destroy(this.gameObject,5.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.right * 3.0f * Time.deltaTime);      
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamageable Hit = other.GetComponent<IDamageable>();
            if(Hit != null )
            {
                Hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }


    IEnumerator DestroyAcid()
    {
        yield return new WaitForSeconds(5);
    }
}

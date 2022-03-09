using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPMine : MonoBehaviour
{
    public GameObject StunEffect;


   
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemyCollided = other.GetComponent<Enemy>();
        if (enemyCollided)
        {
            GameObject stunEffect = Instantiate(StunEffect);
            stunEffect.transform.parent = enemyCollided.gameObject.transform;
            stunEffect.GetComponent<Stun>().targetUnit = enemyCollided.gameObject;
            stunEffect.GetComponent<Stun>().ActivateStatusEffect(enemyCollided.gameObject);
            Debug.Log("Stunned by EMPMine");
            Destroy(this.gameObject, 3f);   

        }
    }
}

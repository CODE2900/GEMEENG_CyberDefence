using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EMP : MonoBehaviour
{
    public float Duration;
    public int SpeedDebuff;
    public GameObject status;


    //    public List<GameObject> Enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Duration -= Time.deltaTime;
        if (Duration <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Enemy>() /*&& !other.gameObject.GetComponentInParent<Enemy>().IsPoisoned*/)
        {
            GameObject stunStatusEffect = Instantiate(status);
            stunStatusEffect.transform.parent = other.gameObject.transform;
            stunStatusEffect.GetComponent<Stun>().targetUnit = other.gameObject;
            stunStatusEffect.GetComponent<Stun>().ActivateStatusEffect(other.gameObject);
            Debug.Log("Stun");

        }
    }
}

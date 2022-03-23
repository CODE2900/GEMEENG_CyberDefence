using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInfo : MonoBehaviour
{
    public GameObject Parent;

    private void Awake()
    {
        if (Parent == null)
        {
            Parent = this.transform.parent.gameObject;
        }
    }

}

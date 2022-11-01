using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.flagContainer.Add(gameObject, this);
    }
}

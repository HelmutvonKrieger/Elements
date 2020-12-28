using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MasterControl.Instance.ModifyPlayerHealth(-1);
        Destroy(gameObject);
    }
}

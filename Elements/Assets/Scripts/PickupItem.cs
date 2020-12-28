using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<LevelManager>().RemainingItemCount--;
        Debug.LogWarning($"x = {transform.position.x}, y = {transform.position.y}");
        Destroy(gameObject);
    }
}

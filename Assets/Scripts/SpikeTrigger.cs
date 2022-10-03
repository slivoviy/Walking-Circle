using System;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("spike");
        Destroy(other.gameObject);
        GameManager.Singleton.GameOver(false);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int coinsCollected;

    [SerializeField] private int coinsAmount;
    [SerializeField] private float speed;

    private void Update() {
        if (PathTracker.Singleton.points.Count == 0) return;

        if (Vector3.Distance(transform.position, PathTracker.Singleton.points[0].position) == 0) {
            var point = PathTracker.Singleton.points[0];
            PathTracker.Singleton.points.Remove(point);
            Destroy(point.gameObject);
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, PathTracker.Singleton.points[0].position,
                speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "Coin":
                AddCoin();
                Destroy(other.gameObject);
                break;
            case "Spike":
                UIManager.Singleton.GameOver(false);
                break;
        }
    }

    private void AddCoin() {
        ++coinsCollected;
        if (coinsCollected == coinsAmount) {
            UIManager.Singleton.AddCoin(coinsCollected);
            UIManager.Singleton.GameOver(true);
        }
        else {
            UIManager.Singleton.AddCoin(coinsCollected);
        }
    }
}
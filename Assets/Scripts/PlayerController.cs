using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
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
}
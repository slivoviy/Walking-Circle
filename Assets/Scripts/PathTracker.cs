using System.Collections.Generic;
using UnityEngine;

public class PathTracker : MonoBehaviour {
    public static PathTracker Singleton;
    public List<Transform> points = new List<Transform>();
    
    [SerializeField] private Transform playerPosition;

    private LineRenderer lr;
    private bool touched;

    private void Awake() {
        Singleton = this;
        lr = GetComponent<LineRenderer>();
    }

    private void Update() {
        if (GameManager.Singleton.gameOver) {
            for (var i = 0; i < points.Count; ++i) {
                var point = points[0];
                points.Remove(point);
                Destroy(point.gameObject);
            }
            lr.positionCount = 0;
            return;
        }
        
        if (Input.touchCount == 0) {
            touched = false;
        }
        else if(!touched) {
            touched = true;
            var fingerPos = Input.GetTouch(0).position;
            Vector3 pos = fingerPos;
            pos.z = 10;
            var realWorldPos = Camera.main.ScreenToWorldPoint(pos);

            AddPoint(realWorldPos);
        }
        
        lr.positionCount = points.Count + 1;
        var pointVectors = new Vector3[points.Count + 1];
        pointVectors[0] = playerPosition.position;
        for (var i = 0; i < points.Count; ++i) {
            pointVectors[i + 1] = points[i].position;
        }
        
        if (points.Count > 0) {
            lr.SetPositions(pointVectors);
        }
    }

    private void AddPoint(Vector3 point) {
        lr.positionCount++;

        var pointGO = Instantiate(Resources.Load<GameObject>("Prefabs/Point"), point, Quaternion.identity);
        points.Add(pointGO.transform);
    }
}
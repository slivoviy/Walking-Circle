using UnityEngine;

public class CoinTrigger : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("coin");
        GameManager.Singleton.AddCoin();
        Destroy(gameObject);
    }
}
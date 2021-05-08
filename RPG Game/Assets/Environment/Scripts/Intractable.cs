using UnityEngine;

public class Intractable : MonoBehaviour
{
    public float radius = 3f;
    public bool isFocus = false;
    public Transform player;
    public bool hasIntrected = false;

    void Update()
    {
        if (isFocus && !hasIntrected ) {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius) {
                Debug.Log("Intrecting");
                hasIntrected = true;
            }
        }
        
    }

    public void OnFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasIntrected = false;
    }

    public void OnDefocused() {
        isFocus = false;
        player = null;
        hasIntrected = false;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }

}

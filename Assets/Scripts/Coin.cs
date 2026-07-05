using UnityEngine;

public class Coin : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<Player>() != null) Destroy(gameObject);
    }
}

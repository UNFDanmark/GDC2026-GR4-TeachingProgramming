using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public string tagToDestry;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(tagToDestry))
        {
            other.gameObject.GetComponent<Killable>().die();
            Destroy(gameObject);
        }
    }
}

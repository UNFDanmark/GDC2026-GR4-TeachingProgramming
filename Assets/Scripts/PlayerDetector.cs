using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] float shootDistance;
    
    public bool CanShoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, shootDistance))
        {
            return hit.collider.gameObject.CompareTag("Player");
        }

        return false;
    }
}

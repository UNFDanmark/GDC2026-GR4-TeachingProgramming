using UnityEngine;

public abstract class Killable : MonoBehaviour
{
    public virtual void die()
    {
        Destroy(gameObject);
    }
}

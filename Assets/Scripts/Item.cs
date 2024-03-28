using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void ApplyEffect();

    public virtual void Start()
    {
        Destroy(gameObject, 3);
    }

}

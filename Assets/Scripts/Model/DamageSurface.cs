using UnityEngine;

namespace Model
{
    public class DamageSurface : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out Character character))
            {
                character.TakeDamage();
            }
        }
    }
}
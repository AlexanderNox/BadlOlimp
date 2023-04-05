using UnityEngine;

namespace Model
{
    public class LevelPiece : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        public void FixedUpdate()
        {
            _lifeTime -= Time.fixedDeltaTime;
            if (_lifeTime <= 0)
                Destroy(gameObject);

            transform.position = new Vector2
                (transform.position.x - _speed * Time.fixedDeltaTime, transform.position.y);
            
            // SetPosition(new Vector2(Position.x - _speed * Time.fixedDeltaTime, Position.y));
        }
    }
}
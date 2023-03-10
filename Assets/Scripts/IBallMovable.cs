using UnityEngine;
namespace Gameplay.Ball
{
    public interface IBallMovable
    {
        public void Move();
        public void SetDirection(Vector3 dir);
    }
}

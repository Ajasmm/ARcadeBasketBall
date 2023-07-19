using UnityEngine;

namespace Game.Framework
{
    public abstract class LevelManager : MonoBehaviour
    {
        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }


        private void Start()
        {
            OnStart();
        }
        private void Update()
        {
            OnUpdate();
        }
        private void FixedUpdate()
        {
            OnFixedUpdate();
        }
    }
}
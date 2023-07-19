using UnityEngine;

namespace Game.Framework
{
    public abstract class GameplayMode : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Play();
        public abstract void Pause();
        public abstract void Resume();
        public abstract void Stop();
        public virtual void Win() { }
        public virtual void Fail() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }

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

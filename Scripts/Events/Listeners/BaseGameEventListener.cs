using UnityEngine;
using UnityEngine.Events;

namespace ISuckAtGameDev.Events
{
    public abstract class BaseGameEventListener<T, TE, TUer> : MonoBehaviour, 
        IGameEventListener<T> where  TE : BaseGameEvent<T> where TUer : UnityEvent<T>
    {
        [SerializeField] private TE gameEvent;
        public TE GameEvent
        {
            get => gameEvent;
            set => gameEvent = value;
        }

        [SerializeField] private TUer unityEventResponse;

        private void OnEnable()
        {
            if (gameEvent == null)
            {
                return;
            }

            GameEvent.RegisterListener(this);
        }
    
        private void OnDisable()
        {
            if (gameEvent == null)
            {
                return;
            }

            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            unityEventResponse?.Invoke(item);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ISuckAtGameDev.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        // This is a list of listeners that are attached to game objects to fire off
        // the specific event.
        readonly List<IGameEventListener<T>> _eventListeners = new();
        
        // This is a Unity Event, that can be added to Scriptable Objects or non MonoBehaviours.
        public UnityEvent<T> EventHandler = new();

        public void Raise(T item)
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(item);
            }
            
            EventHandler.Invoke(item);
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
    }
}

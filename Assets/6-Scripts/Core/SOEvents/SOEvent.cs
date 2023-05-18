using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Events
{
    [CreateAssetMenu(fileName = nameof(SOEvent), menuName = "SOEvents/" + nameof(SOEvent))]
    public class SOEvent : ScriptableObject
    {
        private UnityAction eventCallback;
        
        public void AddListener(UnityAction action)
        {
            eventCallback += action;
        }
        
        public void RemoveListener(UnityAction action)
        {
            eventCallback -= action;
        }

        public void Invoke()
        {
            eventCallback?.Invoke();
        }
        
        private void OnEnable()
        {
            eventCallback = null;
        }
        
        private void OnDisable()
        {
            eventCallback = null;
        }
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(SOEvent))]
    public class SOEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Invoke"))
            {
                var SOEvent = (SOEvent)target;
                SOEvent.Invoke();
            }
        }
    }
#endif
}

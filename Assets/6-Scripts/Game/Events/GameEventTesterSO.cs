using Game.Events;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = nameof(GameEventTesterSO), fileName = nameof(GameEventTesterSO))]
public class GameEventTesterSO : ScriptableObject
{
    
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameEventTesterSO))]
public class GameEventTesterSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("PlayerGameOver"))
        {
            GameEvents.PlayGame?.Invoke();
        }
        if (GUILayout.Button("PlayerWin"))
        {
            GameEvents.GoToMenu?.Invoke();
        }
        if (GUILayout.Button("PlayerReset"))
        {
            GameEvents.BootingFinished?.Invoke();
        }
    }
}
#endif
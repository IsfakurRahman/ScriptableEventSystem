using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName = "Game Event Container")]
public class GameEventContainer : ScriptableObject
{
	[SerializeField] private GameEvent m_GameEvent;
	[SerializeField] private GameEventListener m_GameEventListener;

	public static implicit operator GameEvent(GameEventContainer gameEventContainer) => gameEventContainer.m_GameEvent;
	public static implicit operator GameEventListener(GameEventContainer gameEventContainer) => gameEventContainer.m_GameEventListener;

	[ContextMenu("Init")]
	public void Init()
	{
		if(m_GameEvent && m_GameEventListener ) return;
		
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		GameEventContainer containerAsset = AssetDatabase.LoadAssetAtPath<GameEventContainer>(path);
		if (!containerAsset.m_GameEvent)
		{
			GameEvent gameEvent = AssetDatabase.LoadAssetAtPath<GameEvent>(path);
			if (!gameEvent)
			{
				gameEvent = CreateInstance<GameEvent>();
				containerAsset.m_GameEvent = gameEvent;
				AssetDatabase.AddObjectToAsset(gameEvent, containerAsset);
			}
		}
		
		if (!containerAsset.m_GameEventListener)
		{
			GameEventListener gameEventListener = AssetDatabase.LoadAssetAtPath<GameEventListener>(path);
			if (!gameEventListener)
			{
				gameEventListener = CreateInstance<GameEventListener>();
				containerAsset.m_GameEventListener = gameEventListener;
				AssetDatabase.AddObjectToAsset(gameEventListener, containerAsset);
			}
		}
		AssetDatabase.SaveAssets();
	}
}

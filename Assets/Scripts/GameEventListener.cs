using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameEventListener : ScriptableObject
{
	[SerializeField] private GameEvent m_GameEvent;

	private readonly List<Action> _responses = new ();

	[ContextMenu("Init")]
	public void Init()
	{
		string path = AssetDatabase.GetAssetPath(GetInstanceID());
		GameEvent gameEventAsset = AssetDatabase.LoadAssetAtPath<GameEvent>(path);
		m_GameEvent = gameEventAsset;
		AssetDatabase.SaveAssets();
	}
	private void OnEnable()
	{
		if(m_GameEvent)
			m_GameEvent.OnEvent += Respond;
	}

	private void OnDisable()
	{
		if(m_GameEvent)
			m_GameEvent.OnEvent -= Respond;
	}

	private void Respond() 
	{
		for (int i = 0; i < _responses.Count; i++) _responses[i]?.Invoke();
	}

	public void AddResponse(Action response) => _responses.Add(response);
	public void RemoveResponse(Action response) => _responses.Remove(response);
}

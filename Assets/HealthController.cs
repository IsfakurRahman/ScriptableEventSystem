using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	[SerializeReference] private GameEvent m_HealthEvent;

	[SerializeField] private int m_Health;
	
	public void AddHealth()
	{
		GameEvent healthEvent = m_HealthEvent;
		healthEvent.Raise();
	}
}

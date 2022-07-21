using UnityEngine;

public class HealthUI : MonoBehaviour
{
	[SerializeField] private GameEventListener m_HealthEventListener;

	private void Start()
	{
		m_HealthEventListener.AddResponse(UpdateHealthUI);
	}

	private void UpdateHealthUI()
	{
		Debug.Log("Health Updated");
	}
}

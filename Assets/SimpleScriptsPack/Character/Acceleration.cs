using SimpleFPS;
using UnityEngine;

namespace SimpleScripts
{

    public class Acceleration : MonoBehaviour
	{
		[SerializeField] private float power;
		[SerializeField] private float jumpBonus;

		void OnTriggerEnter(Collider col)
		{
			FirstPersonController fps = col.GetComponent<FirstPersonController>();

			if (fps == null) return;

			fps.m_WalkSpeed += power;
			fps.m_RunSpeed += power;
			fps.m_JumpSpeed += jumpBonus;

		}

		void OnTriggerExit(Collider col)
		{
			FirstPersonController fps = col.GetComponent<FirstPersonController>();

			if (fps == null) return;

			fps.m_WalkSpeed -= power;
			fps.m_RunSpeed -= power;
			fps.m_JumpSpeed -= jumpBonus;
		}
	}
}

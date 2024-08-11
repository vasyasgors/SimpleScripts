using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
    public class SpringPlatform : MonoBehaviour
    {
        [SerializeField] private int jumpForce;

        private float previusJumpForce;

        private void OnTriggerEnter(Collider other)
        {
            FirstPersonController fps = other.GetComponent<FirstPersonController>();

            if (fps != null)
            {
                previusJumpForce = fps.m_JumpSpeed;

                fps.m_JumpSpeed += jumpForce;
                fps.m_Jump = true;

            }
        }

        private void OnTriggerExit(Collider other)
        {
            FirstPersonController fps = other.GetComponent<FirstPersonController>();

            if (fps != null)
            {
                fps.m_JumpSpeed = previusJumpForce;
            }
        }
    }
}

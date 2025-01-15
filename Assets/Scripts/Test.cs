using System;
using UnityEngine;

namespace DefaultNamespace.Timeline
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            transform.Rotate(0f, 90f * Time.deltaTime, 0f);
        }
    }
}
using UnityEngine;

namespace _Project.Develop.Runtime.Domain.Shared.Services
{
    public class TimeService
    {
        public float DeltaTime => Time.deltaTime;
        public float TimeSinceStartup => Time.realtimeSinceStartup;
    }
}
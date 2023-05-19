using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.UpdateSystem
{
    public class Updater : MonoBehaviour, IService
    {
        private List<IUpdatible> _updatibles;
        
        public bool IsEnableToUpdate { get; set;}

        public void Register(IUpdatible updatible)
        {
            _updatibles.Add(updatible);
        }

        private void Update()
        {
            if(IsEnableToUpdate)
            {
                foreach (var updatible in _updatibles)
                {
                    updatible.OnUpdate();
                }
            }
        }
    }
}
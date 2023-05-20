using Infrastructure.Services;
using UnityEngine;

namespace Data
{
    public class AssetsProvider : IService
    {
        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        public GameObject Instantiate(string path, bool active)
        {
            var prefab = Resources.Load<GameObject>(path);
            prefab.SetActive(active);
            return Object.Instantiate(prefab);
        }
    }
}
using UnityEngine;

namespace Infrastructure
{
    public static class ComponentExtensions
    {
        public static void Activate(this Component component)
        {
            component.gameObject.SetActive(true);
        }
        
        public static void InActivate(this Component component)
        {
            component.gameObject.SetActive(false);
        }
    }
}
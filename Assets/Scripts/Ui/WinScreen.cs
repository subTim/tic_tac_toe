using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class WinScreen : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI WinFrom { get; set; }
        [field: SerializeField] public Button RestartButton { get; set; }
    }
}
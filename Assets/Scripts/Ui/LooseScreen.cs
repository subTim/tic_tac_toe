using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LooseScreen : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI LooseFrom { get; set; }
        [field: SerializeField] public Button RestartButton { get; set; }
    }
}
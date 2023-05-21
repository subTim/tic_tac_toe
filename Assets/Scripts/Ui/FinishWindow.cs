using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class FinishWindow : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Caption { get; set; }
        [field: SerializeField] public Button RestartButton { get; set; }
    }
}
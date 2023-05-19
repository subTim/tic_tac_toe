using Infrastructure.Services.Cells;
using TMPro;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameCell : MonoBehaviour
    {
        private CellType _status;
        public bool IsEngaded => _status == CellType.Empty;
    }
}
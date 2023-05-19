using System;
using Infrastructure.Services.Cells;
using Infrastructure.Services.UpdateSystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public class InputService : IService, IUpdatible
    {
        public Action<GameCell> OnCellTap;

        private RaycastHit[] _cells = new RaycastHit[1];

        public void OnUpdate()
        {
            TrackInput();
        }

        private void TrackInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(GetCell(out GameCell cell))
                    OnCellTap?.Invoke(cell);
            }
        }

        private bool GetCell(out GameCell gameCell)
        {
            gameCell = null;
            Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.RaycastNonAlloc(ray, _cells) > 0)
            {
                _cells[0].transform.TryGetComponent(out gameCell);
            }

            return gameCell == null;
        }
    }
}
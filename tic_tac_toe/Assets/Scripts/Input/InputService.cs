using System;
using System.Collections.Generic;
using Infrastructure.Services.UpdateSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Infrastructure.Services
{
    public class InputService : IService, IUpdatible
    {
        public Action<GameCell> OnCellTap;

        private List<RaycastResult> _results;
        private GraphicRaycaster _raycaster;
        private PointerEventData _pointerData;

        public void Construct(GraphicRaycaster raycaster)
        {
            _raycaster = raycaster;
            _pointerData = new PointerEventData(EventSystem.current);
        }
        
        public void OnUpdate()
        {
            TrackInput();
        }

        private void TrackInput()
        {
            if (IsTapping() && GetCell(out GameCell cell))
                OnCellTap?.Invoke(cell);
        }

        private bool GetCell(out GameCell gameCell)
        {
            gameCell = null;
            _results = new List<RaycastResult>(1);
            
            _pointerData.position = UnityEngine.Input.mousePosition;
            _raycaster.Raycast(_pointerData, _results);
            
            return _results.Count > 0 && _results[0].gameObject.TryGetComponent(out gameCell);
        }

        private bool IsTapping()
        {
            return UnityEngine.Input.GetMouseButtonDown(0);
        }
    }
}
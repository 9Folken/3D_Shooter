using System.Collections;
using UnityEngine;

namespace Geekbrains
{
	public class FlashLightController : BaseController
	{
		private FlashLightModel _flashLight;
		private FlashLightUiText _flashLightUi;
		
		public FlashLightController()
		{
			
			_flashLight = MonoBehaviour.FindObjectOfType<FlashLightModel>();
			_flashLightUi = MonoBehaviour.FindObjectOfType<FlashLightUiText>();
			Off();
		}

		public override void OnUpdate()
		{
			if (!IsActive) return;

			if (_flashLight == null)return;
			_flashLight.Rotation();
			if (_flashLight.EditBatteryCharge())
			{
				_flashLightUi.Text = _flashLight.BatteryChargeCurrent;
				
			}
			else
			{
				Off();
			}
		}

		public override void On()
		{
			if (IsActive)return;
			
				
			base.On();
			_flashLight.Switch(true);
			//_flashLightUi.SetActive(true);
		}

		public sealed override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_flashLight.Switch(false);
			//_flashLightUi.SetActive(false);
		}

		
	}
}
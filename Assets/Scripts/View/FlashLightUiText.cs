using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public class FlashLightUiText : MonoBehaviour
	{
		private Text _text;
		private FlashLightModel _flashLight;
		public Image Indicator;

		private void Start()
		{
			_text = GetComponent<Text>();
			_flashLight = FindObjectOfType<FlashLightModel>();

		}

		public float Text
		{
			set
			{
				_text.text = $"{value:0.0}";
			}
		}

		//public void SetActive(bool value)
		//{
		//	_text.gameObject.SetActive(value);
		//}

		void Update()
		{
			Indicator.fillAmount = _flashLight.BatteryChargeCurrent;
		}
	}
}
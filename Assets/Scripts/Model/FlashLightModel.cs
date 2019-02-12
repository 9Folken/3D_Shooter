using System.Collections;
using UnityEngine;

namespace Geekbrains
{
	public sealed class FlashLightModel : BaseObjectScene
	{
		private Light _light;
		private Transform _goFollow;
		private Vector3 _vecOffset;
		public float BatteryChargeCurrent { get; private set; }
		
		public float _drainMult = 3f;
		
		public float _rechargeTime = 10f;
		[SerializeField] private float _speed = 10;
		public float _batteryChargeMax;

		protected override void Awake()
		{
			base.Awake();
			_light = GetComponent<Light>();
			_goFollow = Camera.main.transform;
			_vecOffset = transform.position - _goFollow.position;
			BatteryChargeCurrent = _batteryChargeMax;
		}

		public void Switch(bool value)
		{
			
			_light.enabled = value;
			if (!value)
			{
				//StopAllCoroutines();
				return;
			}
				
			transform.position = _goFollow.position + _vecOffset;
			transform.rotation = _goFollow.rotation;
			StartCoroutine(ChangeFill());


		}

		public void Rotation()
		{
			if (!_light) return;
			transform.position = _goFollow.position + _vecOffset;
			transform.rotation = Quaternion.Lerp(transform.rotation,
				_goFollow.rotation, _speed * Time.deltaTime);
		}

		public bool EditBatteryCharge()
		{
			if (BatteryChargeCurrent > 0)
			{
				//BatteryChargeCurrent -= Time.deltaTime;
				return true;
			}
			return false;
		}

		private IEnumerator ChangeFill()
		{
			while (true)
			{
				yield return new WaitForSeconds(0.5f);
				if (_light.enabled == true)
				{
					BatteryChargeCurrent = Mathf.Clamp01(BatteryChargeCurrent - (_batteryChargeMax / (_rechargeTime * _drainMult) * 0.5f));
					//BatteryChargeCurrent = Mathf.Clamp01(BatteryChargeCurrent -= Time.deltaTime);
					if (BatteryChargeCurrent <= 0f)
						Switch(false);
				}
				else
				{
					//BatteryChargeCurrent = Mathf.Clamp01(BatteryChargeCurrent *= _drainMult * Time.deltaTime);
					BatteryChargeCurrent = Mathf.Clamp01(BatteryChargeCurrent + (_batteryChargeMax / _rechargeTime * 0.5f));
				}
				Debug.Log(BatteryChargeCurrent);
			}
		}
	}
}
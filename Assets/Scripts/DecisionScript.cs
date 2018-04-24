using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
	class DecisionScript
	{
		public float DecisionDuration = 10.0f;
		public bool durationPassed = false;

		void Start()
		{
			
		}

		void Update()
		{
			this.DecisionDuration -= Time.deltaTime;
			if (this.DecisionDuration <= 0)
				this.durationPassed = true;
		}

	}
}

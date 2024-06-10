using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
	public class MonoBehaviorSingletonPersistent<T> : MonoBehaviour
		where T : Component
	{
		public static T Instance { get; private set; }

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = this as T;
				DontDestroyOnLoad(this);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}

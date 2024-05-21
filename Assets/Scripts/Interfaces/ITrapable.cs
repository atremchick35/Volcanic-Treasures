using System;
using UnityEngine;

namespace Interfaces
{
	public interface ITrapable
	{
		void OnTriggerEnter2D(Collider2D other);
	}
}

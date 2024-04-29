using System;
using UnityEngine;

namespace Interfaces
{
	public interface IEffectable
	{
		void OnTriggerEnter2D(Collider2D other);
	
		void OnTriggerExit2D(Collider2D other);
	
		void KillPlayer();
	}
}

using UnityEngine;

namespace CC.Runtime
{
	public interface IModule
	{
		
		bool IsActive {get; set;}
		int MenuId{ set; get; }
		RectTransform rectTransform{get;}

		void SetParameter(object obj);


		void Enter();
		void Exit();
		void DestroyModule();

		void OnBack ();
		void OnExit();
		void CheckOnExit();

		void Back();

	}
}

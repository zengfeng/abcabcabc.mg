using UnityEngine;
using System.Collections;
using CC.Runtime;
using System.Collections.Generic;

namespace Games.Guides
{
	public class GuideMoveToPanel : MonoBehaviour
	{
		public enum ViewType
		{
			Send,
			Drag,
			DragCircle,
		}

		public int count = 0;
		public GameObject moveTo_Send;
		public GameObject moveTo_Drag;
		public GameObject moveTo_DragCircle;
		public Dictionary<int, AbstractMoveToView> moveDict = new Dictionary<int, AbstractMoveToView>();

		void Start()
		{
			CheckVisiable();
		}

		private GameObject GetViewPrefab(ViewType viewType)
		{
			switch(viewType)
			{
			case ViewType.Send:
				return moveTo_Send;
				break;
			case ViewType.DragCircle:
				return moveTo_DragCircle;
				break;
			default:
				return moveTo_Drag;
				break;
			}
		}

		public AbstractMoveToView GetMoveToView(int id,  ViewType viewType)
		{
			AbstractMoveToView mt;
			if(!moveDict.TryGetValue(id, out mt))
			{
				GameObject go = GameObject.Instantiate(GetViewPrefab(viewType));
				go.transform.SetParent(transform, false);
				go.SetActive(true);
				
				mt = go.GetComponent<AbstractMoveToView>();
				moveDict.Add(id, mt);
				count ++;
				CheckVisiable();
			}

			return mt;
			
		}

		public AbstractMoveToView MoveWorld(int id, Vector3 from, Vector3 to)
		{
			return MoveWorld(id, from, to, ViewType.Drag);
		}


		public AbstractMoveToView MoveWorld(int id, Vector3 from, Vector3 to, ViewType viewType)
		{
			AbstractMoveToView mt = GetMoveToView(id, viewType);
			mt.MoveWorld(from, to);
			return mt;

		}
		
		public AbstractMoveToView Move(int id, Vector3 from, Vector3 to)
		{
			return Move(id, from, to);
		}


		public AbstractMoveToView Move(int id, Vector3 from, Vector3 to, float radius, ViewType viewType)
		{
			MoveToView_DragCircle mt = (MoveToView_DragCircle) Move (id, from, to, viewType);
			mt.SetRadius (radius);

			return mt;
		}

		public AbstractMoveToView Move(int id, Vector3 from, Vector3 to, ViewType viewType)
		{
			AbstractMoveToView mt = GetMoveToView(id, viewType);
			mt.Move(from, to);
			return mt;
		}

		public void CloseMoveTo(int id)
		{
			AbstractMoveToView mt;
			if(moveDict.TryGetValue(id, out mt))
			{
				moveDict.Remove(id);
				if(mt != null && mt.gameObject != null) Destroy(mt.gameObject);
				count --;
				CheckVisiable();
			}
		}

		public void CheckVisiable()
		{
			if(count > 0)
			{
				if(gameObject != null && gameObject.activeSelf == false) gameObject.SetActive(true);
			}
			else
			{
				if(gameObject != null && gameObject.activeSelf) gameObject.SetActive(false);
			}
		}

	}
}
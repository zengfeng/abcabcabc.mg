using UnityEngine;
using System.Collections;
using System;

namespace Games.Module.Wars
{
	public class TurretProjectile : MonoBehaviour 
	{
		public Action<object> OnCompleteHandler;
		public object completeArg;

		public GameObject explosionPrefab;

    	public float progress;
    	public float duration;
    	public bool autoRotate;

		public Transform targetTransform;
    	private Vector3 targetPosition;
		private Vector3 launchPosition;
		public Vector3 launchPositionOffset;
		public Vector3 targetPositionOffset;


    	public ProjectType curveType = ProjectType.Parabolic;

    	public bool isAvatar = false;
    	private Avatar avatar;
    	public Vector3 velocity;
    	private float angle = 0;
    	public float hitHeight = 0.5f;
		public float gravity{ get{return War.config.ProjectileGravity;} }
    	// Use this for initialization
		void Awake() {
		}

    	void Start () {

			
			if(targetTransform == null || targetTransform.gameObject.activeSelf == false)
			{
				
				Destroy(gameObject);
				return;
			}

    		progress = 0;
    		avatar = GetComponent<Avatar>();
    		velocity = getACurveAttackVeocity();
			launchPosition = transform.position;
    		
			Update();
		}

    	Vector3 getACurveAttackVeocity()
    	{
    		float archer_vx = 0;
    		float archer_vy = 0;
    		float archer_vz = 0;
    		float change_t = 0;
    		
    		float deltaX = 0;
    		float deltaZ = 0;
    		float deltaS = 0f;
    		
    		
    		Vector3 velocity;
    		Vector3 targetPoint;

			transform.position += launchPositionOffset;

//    		if(caster.unitType == UnitType.Solider)
//    		{
//    			float gather = gatherVlaue > 1?1:(gatherVlaue < 0?0:gatherVlaue);
//    			Transform myformation = caster.formationTransform;
//    			Vector3 forward = (caster.transform.position - myformation.position).normalized;
//    			float dis = Vector3.Distance(caster.transform.position,myformation.transform.position);
//    			Transform targetTroop = caster.attackTarget.formationTransform;
//    			targetPoint = targetTroop.position + forward*(dis*gather);
//				deltaS = 1f;
//    		}
//    		else
//    		{
				targetPoint = targetTransform.position;
				deltaS = 0f;
//    		}




    		float s = Mathf.Sqrt(Mathf.Pow(targetPoint.x - transform.position.x,2) + Mathf.Pow(targetPoint.z - transform.position.z,2)+Mathf.Pow(targetPoint.y - transform.position.y,2));
    		

			deltaX=(targetPoint.x-transform.position.x)*deltaS/s;
    		deltaZ=(targetPoint.z-transform.position.z)*deltaS/s;
    		s-=deltaS;
    		
    		float h = (1-Mathf.Cos(Mathf.Deg2Rad * 30))*s;
			float t = Mathf.Sqrt(2*h/gravity);
			archer_vy = gravity*t;
    		archer_vx = (targetPoint.x - transform.position.x - 2*deltaX)/(2*t);
    		archer_vz = (targetPoint.z - transform.position.z - 2*deltaZ)/(2*t);
    		
    		velocity = new Vector3(archer_vx, archer_vy , archer_vz);



    		return velocity;
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		if(curveType == ProjectType.Parabolic)
    		{
    			CurveAttack();
    		}
    		else if(curveType == ProjectType.Line)
    		{
    			StraightAttack();
    		}

    	}

    	void CurveAttack()
    	{
    		if (transform.position.y < hitHeight && velocity.y <= hitHeight)
    		{
    			AttackComplete();
    		}
    		else
    		{
    			if(float.IsNaN(velocity.x))return;
    			transform.position += velocity * Time.deltaTime;
    			velocity.y -= gravity * Time.deltaTime;
    		}

    		if(isAvatar == false){
    			transform.forward = velocity.normalized;
    		}else{
//    			float angle = 0;
//    			Vector3 direction = Camera.main.transform.InverseTransformDirection(velocity.normalized);
//    			angle = Mathf.Atan2 (direction.x, direction.y)*(180/Mathf.PI);
//    			float dir = Vector3.Dot (direction, Vector3.right);
//    			
//    			
//    			if (dir > 0)
//    				avatar.angle = Mathf.Abs(angle);
//    			else
//    				avatar.angle = 360 - Mathf.Abs(angle);
    		}


    	}

    	void StraightAttack()
    	{
    		progress += Time.deltaTime / duration;
    		if (progress > 1)
    		{
    			AttackComplete();
    			return;
    		}

			if(targetTransform != null) targetPosition = targetTransform.position + targetPositionOffset;
			transform.position = Vector3.Lerp(launchPosition, targetPosition, progress);
    		 
    		if (autoRotate)
    			transform.LookAt(targetPosition);
    	}

    	void AttackComplete()
    	{
			if(OnCompleteHandler != null) OnCompleteHandler(completeArg);

			if(explosionPrefab != null)
			{
				GameObject go = GameObject.Instantiate<GameObject>(explosionPrefab);
				go.transform.position = transform.position;
			}

			Destroy(gameObject);
    	}
    }
}
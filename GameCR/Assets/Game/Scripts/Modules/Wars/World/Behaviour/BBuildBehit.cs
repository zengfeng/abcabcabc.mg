using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.Manager;

namespace Games.Module.Wars
{
	public class BBuildBehit : EBehaviour
	{
        //public GameObject effect_fire;//中火
		public GameObject effect_beattack;

		protected override void OnStart ()
		{
			base.OnStart ();

            //Coo.assetManager.Load(WarRes.Effect_Fire_2, OnLoadRes);
			OnLoadRes(WarRes.Effect_Beattack, WarRes.GetPrefab(WarRes.Effect_Beattack));
		}
		
		protected void OnLoadRes(string name, System.Object obj)
		{
			GameObject go = (GameObject)GameObject.Instantiate(obj as UnityEngine.Object);
			go.name = go.name.Replace(" (Clone)", "");
			go.SetActive(false);
			go.transform.SetParent(unitAnchor.GetAnchor(UnitAnchorName.EffectFire));
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
            
            if (name == WarRes.Effect_Beattack) {
				effect_beattack = go;
			} else {
				//effect_fire = go;
			}			
		}
        //private void setFireDisappear()
        //{
        //    effect_fire.SetActive(false);
        //    effect_fire.GetComponent<EffectParticleScale>().setNomal();

        //}

        //private void setFireShow(bool isShow)
        //{
        //    if (isShow == false)//火焰消失
        //    {
        //        effect_fire.GetComponent<EffectParticleScale>().setDisappear();
        //        Invoke("setFireDisappear", 3.0f);
        //        //setFireDisappear();
        //        return ;
        //    }
        //    effect_fire.SetActive(true);
        //}
		
		private bool _beattack = false;
		private bool _changeTeaming = false;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			
			if(unitData.behit)
			{
				unitData.behitTime -= Time.deltaTime;
			}

			if(_beattack != unitData.beattack)
			{
				_beattack = unitData.beattack;
				effect_beattack.SetActive(_beattack);
                //setFireShow(_beattack);
                if(_beattack == true)
                {
					Coo.soundManager.PlaySound("effect_fighting");
					//TODO NEW SKILL
//                    if (unitData.hasHero)
//                    {
//                        if (unitData.heroData.belongState == HeroBelongState.Normal)
//                        {
//                            MonoBehaviour mb = War.scene.rootSkillBar.GetSkillButtonController(unitData.heroData.unit);
//                            if (mb != null)
//                            {
//                                Coo.plotTalkManager.showTalkTips(War.sceneData.stageConfig.id,
//                                                                                                unitData.heroData.heroId,
//                                                                                                heroTalkType.tpHited,
//                                                                                                mb.transform);
//                            }
//                        }
//                    }
                }
			}

			if(unitData.beattack)
			{
				unitData.beattackTime -= Time.deltaTime;
			}

			//----------------------
			if(unitData.changeTeaming)
			{
				unitData.changeLegionTime -= Time.deltaTime;
			}

			if(_changeTeaming != unitData.changeTeaming)
			{
				_changeTeaming = unitData.changeTeaming;

//				if(War.config.CasernEnableUplevel)
//				{
//					if(unitData.level > 1) unitData.level -= 1;
//				}
			}
		}

	}
}

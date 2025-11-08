using TPT.Core;
using TPT.Core.Core.HeroData.SkillData;
using UnityEngine;

namespace TPT.Gameplay.Player.GlueCode
{
    public class UnitAtt : MonoBehaviour
    {
       public SkillData skillData;
       public int currentATT;
       
           void Start()
           {
               currentATT = skillData.Power;
       
           }
       
           // Appelée quand le joueur choisit Attaquer
           public void Attack(Unit target)
           {
               Debug.Log(name + " attaque " + target.name + " !");
               target.TakeDamage(currentATT);
           }
       
           // Exemple : une compétence spéciale
           public void EFF(Unit target)
           {
               Debug.Log(name + " utilise une compétence sur " + target.name + " !");
               target.TakeDamage(currentATT * 2);
           }
    }
}

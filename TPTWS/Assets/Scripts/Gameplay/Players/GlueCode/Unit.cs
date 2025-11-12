using TPT.Core;
using TPT.Core.Data;
using UnityEngine;

/*
namespace TPT.Gameplay.Player.GlueCode
{
    public class Unit : MonoBehaviour
    {
      public HeroData data;
      public SkillData skillData;
      public SkillData skillDataSpecial;

      private int currentHP;

      private void Start()
      {
         currentHP = data.MaxHealth;
      }

      public void TakeDamage(int amount)
      {
         if (amount <= 0) return;

         currentHP -= amount;
         currentHP = Mathf.Max(currentHP, 0);

         Debug.Log(name + " prend " + amount + " dégâts.");
         Debug.Log(name +" il te reste "+ currentHP+" HP");

         if (currentHP <= 0)
            Die(); 
      }
      
      public void Die()
      {
         Debug.Log(data.Name + " est mort");
         TurnManager.TurnManager.Instance.RemoveUnit(this);
         Destroy(gameObject);
      }
      
      // Appelée quand le joueur choisit Attaquer
      public void Attack(Unit target)
      {
         Debug.Log(name + " attaque " + target.name + " !");
         target.TakeDamage(skillData.Power);
      }
      
      // Exemple : une compétence spéciale
      public void EFF(Unit target)
      {
         Debug.Log(name + " utilise une compétence sur " + target.name + " !");
         target.TakeDamage(skillDataSpecial.Power);
      }
    }
}
*/

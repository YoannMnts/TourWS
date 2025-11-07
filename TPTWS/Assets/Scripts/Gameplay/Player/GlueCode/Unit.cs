using TPT.Core;
using TPT.Core.Core.HeroData;
using UnityEngine;

namespace TPT.Gameplay.Player.GlueCode
{
    public class Unit : MonoBehaviour
    {
      public HeroData data;
      public int currentHP;

      private void Start()
      {
         currentHP = data.MaxHealth;
      }

      public void TakeDamage(int amount)
      {
         if (amount <= 0) return;

         currentHP -= amount;
         currentHP = Mathf.Max(currentHP, 0);

         Debug.Log(name + " prend " + amount + " dégâts. HP = " + currentHP + "/" + data.MaxHealth);

         if (currentHP <= 0)
            Die(); 
      }
      public void Die()
      {
         Debug.Log(data.Name + " est mort");
         TurnManager.TurnManager.Instance.RemoveUnit(this);
         Destroy(gameObject);
      }
    }
}

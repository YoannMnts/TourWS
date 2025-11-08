using TMPro;
using UnityEngine;

namespace TPT.Gameplay
{
        public class ChatBubble : MonoBehaviour
        {
                [SerializeField] private SpriteRenderer backGround;
                [SerializeField]  private TextMeshPro textMeshp ;
                 [SerializeField] private string texte;
                 [SerializeField] private float Longeur = 7f;
                 [SerializeField] private float Hauteur = 5f;

                private void Awake()
                {
                        backGround = transform.Find("BG").GetComponent<SpriteRenderer>();
                        textMeshp = transform.Find("Text").GetComponent<TextMeshPro>();
                        
                }

                private void Start()
                {
                        Setup(texte);
                        Hide();
                }

                private void Setup(string text)
                {
                        textMeshp.SetText(text);
                        textMeshp.ForceMeshUpdate();
                        Vector2 textSize = textMeshp.GetRenderedValues(false);
                        Vector2 size = new Vector2(Longeur,Hauteur);
                        
                        backGround.size = textSize +  size;
                        
                }
                public void Show()
                {
                        gameObject.SetActive(true);
                }
                public void Hide()
                {
                        gameObject.SetActive(false);
                }
        }
}

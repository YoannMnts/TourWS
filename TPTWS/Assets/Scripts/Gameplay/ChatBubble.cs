using TMPro;
using UnityEngine;
using System.Collections;

namespace TPT.Gameplay
{
        public class ChatBubble : MonoBehaviour
        {
                [SerializeField] private SpriteRenderer backGround;
                [SerializeField]  private TextMeshPro textMeshp ;
                  private string texte;
                 [SerializeField] private float Longeur = 7f;
                 [SerializeField] private float Hauteur = 5f;
                 
                 [SerializeField] private float typingSpeed = 0.03f;
                 private Coroutine typingCoroutine;

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
                public void Show(string text)
                {
                        gameObject.SetActive(true);
                        if (typingCoroutine != null)
                                StopCoroutine(typingCoroutine);

                        typingCoroutine = StartCoroutine(TypeText(text));
                }
                public void Hide()
                {
                        gameObject.SetActive(false);
                }

                private IEnumerator TypeText(string text)
                {
                        Setup(text);

                        textMeshp.maxVisibleCharacters = 0;

                        for (int i = 0; i <= text.Length; i++)
                        {
                                textMeshp.maxVisibleCharacters = i;
                                yield return new WaitForSeconds(typingSpeed);
                        }
                }
        }
}

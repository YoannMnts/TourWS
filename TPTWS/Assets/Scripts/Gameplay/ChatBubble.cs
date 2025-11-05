using UnityEngine;
using UnityEngine.Events ;
using UnityEngine.EventSystems ;
using UnityEngine.UI;
using TMPro;

namespace TPT.Core.Core.UI
{
        public class ChatBubble : MonoBehaviour
        {
                [SerializeField] private SpriteRenderer backGround;
                [SerializeField]  private SpriteRenderer IconE;
                [SerializeField]  private TextMeshPro textMeshp ;
                [SerializeField]  private string texte;

                private void Awake()
                {
                        backGround = transform.Find("BG").GetComponent<SpriteRenderer>();
                        IconE = transform.Find("icon").GetComponent<SpriteRenderer>();
                        textMeshp = transform.Find("Text").GetComponent<TextMeshPro>();
                }

                private void Start()
                {
                        Setup(texte);
                }

                private void Setup(string text)
                {
                        textMeshp.SetText(text);
                        textMeshp.ForceMeshUpdate();
                        Vector2 textSize = textMeshp.GetRenderedValues(false);
                        Vector2 size = new Vector2(7f,5f);
                        
                        backGround.size = textSize +  size;
                        
                }

                public static void Create(Transform parent, Vector3 localPosition, string texte)
                {
                        Transform ChatBubble = Instantiate(Resources.Load("Prefabs/ChatBubble")) as Transform;
                        ChatBubble.localPosition = localPosition;
                        ChatBubble.GetComponent<ChatBubble>().Setup(texte);
                }
        }
}

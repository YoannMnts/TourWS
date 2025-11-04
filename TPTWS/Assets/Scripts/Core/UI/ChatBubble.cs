using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

namespace TPT.Core.Core.UI
{
        public class ChatBubble : MonoBehaviour
        {
                private SpriteRenderer backGround;
                private SpriteRenderer IconE;
                private TextMeshPro textMesh;

                private void Awake()
                {
                        backGround = transform.Find("BG").GetComponent<SpriteRenderer>();
                        IconE = transform.Find("icon").GetComponent<SpriteRenderer>();
                        textMesh = transform.Find("Text").GetComponent<TextMeshPro>();
                }

                private void Start()
                {
                        Setup("hello");
                }

                private void Setup(string text)
                {
                        textMesh.SetText(text);
                }
        }
}

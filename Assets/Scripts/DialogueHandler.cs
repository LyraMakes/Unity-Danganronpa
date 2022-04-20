using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DialogueHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text _dialogueText;

        private Queue<DialogueLine> _lines;
        
        private void Start()
        {
            _lines = new Queue<DialogueLine>();
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"Assets/Resources/Dialogue/Debug-Dialogue.xml");
            XmlNodeList dialogueNodes = xmlDoc.SelectNodes("/dialogue/text");
            if (dialogueNodes == null) throw new InvalidXmlException("Dialogue file is invalid");
            foreach (XmlNode node in dialogueNodes)
            {
                if (node.Attributes == null) continue;
            
                string character = node.Attributes["character"].Value;
                string expression = node.Attributes["expression"].Value;
                string text = node.InnerText;
                bool isFocused = node.Attributes["focus"] != null;
                
                _lines.Enqueue(new DialogueLine(character, text, isFocused));
            }
        }

        private void NextLine()
        {
            if (_lines.Count == 0)
            {
                Debug.Log("End of dialogue");
                return;
            }
        
            DialogueLine line = _lines.Dequeue();
            _dialogueText.text = $"<b>{line.Name}</b>\n{line.Text}";
        }
        
        
    }
}
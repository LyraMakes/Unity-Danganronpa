using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DialogueHandler : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;
        
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _dialogueText;
        
        private Queue<DialogueLine> _lines;
        private CharacterMapping _characterMapping;
        
        private void Start()
        {
            _characterMapping = new CharacterMapping();
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

            _inputHandler.OnButtonPressed += HandleButtonPressed;
        }

        private void HandleButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button == Buttons.CROSS)
                NextLine();
        }

        private void NextLine()
        {
            if (_lines.Count == 0)
            {
                Debug.Log("End of dialogue");
                return;
            }
        
            DialogueLine line = _lines.Dequeue();
            _nameText.text = _characterMapping.GetCharacterName(line.Name);
            _dialogueText.text = line.Text;
        }
        
        
    }
}
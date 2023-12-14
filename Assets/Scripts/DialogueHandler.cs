using System;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DialogueHandler : MonoBehaviour
    {
        [SerializeField] private TrialCircleController _circleController;
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


                XmlAttribute nameAttr = node.Attributes["hide-name"];
                bool showName = nameAttr is null || nameAttr.Value.ToLower().Equals("false");

                XmlAttribute focusAttr = node.Attributes["focus"];
                bool isFocused = focusAttr is not null && focusAttr.Value.ToLower().Equals("true");
                
                _lines.Enqueue(new DialogueLine(character, text, expression, showName, isFocused));
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
            // Set Text
            _nameText.text = (line.ShowName) ? _characterMapping.GetCharacterName(line.Name) : "";
            _dialogueText.text = line.Text;

            // Set Expression / Effects

            if (line.Focus)
            {
                _circleController.SetExpression(line.Name, line.Expression);
                _circleController.SetFocusTarget(line.Name);
            }
        }


    }
}
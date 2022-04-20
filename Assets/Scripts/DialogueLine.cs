namespace DefaultNamespace
{
    public class DialogueLine
    {
        public string Name { get; }
        public string Text { get; }
        
        public bool ShowName { get; }

        public DialogueLine(string name, string text, bool showName)
        {
            Name = name;
            Text = text;
            ShowName = showName;
        }
    }
}
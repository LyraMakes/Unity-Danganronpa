namespace DefaultNamespace
{
    public class DialogueLine
    {
        public string Name { get; }
        public string Text { get; }
        
        public string Expression { get; }
        
        public bool ShowName { get; }
        
        public bool Focus { get;  }

        public DialogueLine(string name, string text, string expression, bool showName, bool focus)
        {
            Name = name;
            Text = text;
            Expression = expression;
            ShowName = showName;
            Focus = focus;
        }
    }
}
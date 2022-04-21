namespace DefaultNamespace
{
    public class DialogueLine
    {
        public string Name { get; }
        public string Text { get; }
        
        public string Expression { get; }
        
        public bool ShowName { get; }

        public DialogueLine(string name, string text, string expression, bool showName)
        {
            Name = name;
            Text = text;
            Expression = expression;
            ShowName = showName;
        }
    }
}
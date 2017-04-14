using System;

namespace TextMenu
{
    public class MenuItem
    {
        public Action OnSelect;
        public string Text;

        public MenuItem(string text, Action onSelect)
        {
            Text = text;
            OnSelect = onSelect;
        }
    }
}
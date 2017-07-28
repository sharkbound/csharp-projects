using System;

namespace ConsoleMenuSystem.Data
{
    interface IMenu
    {
        void Show();
        void Action(ConsoleKeyInfo key, StoredInfo stored);
    }
}

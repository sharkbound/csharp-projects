using System.Collections.Generic;
using System.Linq;
using ConsoleMenuSystem.Menus;

namespace ConsoleMenuSystem.Data
{
    class StoredInfo
    {
        public double TotalCost;
        public bool Close;
        public List<IMenu> Menus;
        public StoredInfo()
        {
            TotalCost = 0d;
            Close = false;
            Menus = new List<IMenu> { new BaseMenu() };
        }

        public IMenu CurrentMenu => Menus.Last();
        public void SetCurrentMenu(IMenu m) => Menus.Add(m);
        public void GotoPreviousMenu()
        {
            if (Menus.Count > 1)
                Menus.RemoveAt(Menus.Count - 1);
        }
    }
}

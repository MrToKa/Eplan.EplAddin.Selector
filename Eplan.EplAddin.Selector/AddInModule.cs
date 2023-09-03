using Eplan.EplApi.ApplicationFramework;

namespace Eplan.EplAddin.Selector
{
    public class AddInModule : IEplAddIn
    {
        public bool OnRegister(ref System.Boolean bLoadOnStart)
        {
            bLoadOnStart = true;
            return true;
        }
        public bool OnUnregister()
        {
            return true;
        }
        public bool OnInit()
        {
            return true;
        }
        public bool OnInitGui()
        {
            return true;
        }
        public bool OnExit()
        {
            return true;
        }
    }
}

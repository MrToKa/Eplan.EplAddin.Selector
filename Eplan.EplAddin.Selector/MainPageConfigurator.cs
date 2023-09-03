using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.HEServices;

namespace Eplan.EplAddin.Selector
{
    public class Selector
    {
        internal class SelectorAction : IEplAction
        {
            public bool Execute(ActionCallingContext ctx)
            {
                



                SelectionSet selectionSet = new SelectionSet();
                StorableObject[] storableObjects = selectionSet.Selection;

                StorableObject[] devices = storableObjects;
                List<Function> functions = new List<Function>();

                for (int i = 0; i < devices.Length; i++)
                {
                    if (devices[i] is Function)
                    {
                        Function func = (Function)devices[i];
                        functions.Add(func);
                    }
                }


                if (functions.Count == 0)
                {
                    MessageBox.Show("No current selection!");
                }
                else
                {
                    StringBuilder result = new StringBuilder();
                    result.AppendLine("Current selection contains of:");
                    foreach (Function so in functions)
                    {
                        if (so.Category == Function.Enums.Category.Cable)
                        {
                            result.AppendLine("Cable name: " + so.Name);
                            result.AppendLine("Cable designation: " + so.Properties.FUNC_CABLE_DESIGNATION
                                .ToMultiLangString().GetString(ISOCode.Language.L_en_US));
                            result.AppendLine("Cable length: " + so.Properties.FUNC_CABLELENGTH);
                            result.AppendLine("Cable article number: " + so.Properties.FUNC_ARTICLE_PARTNR[1]);
                        }

                        //result.AppendLine("Object type: " + so.GetTypeName().ToString());
                    }

                    MessageBox.Show(result.ToString());
                }

                return true;
            }

            public bool OnRegister(ref string Name, ref int Ordinal)
            {
                Name = "Selector";
                Ordinal = 20;
                return true;
            }

            public void GetActionProperties(ref ActionProperties actionProperties)
            {
            }
        }
    }
}
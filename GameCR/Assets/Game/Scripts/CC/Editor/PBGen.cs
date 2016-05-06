using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using ProtoBuf;
using System.IO;

public class PBGen {

    [MenuItem("CC/Tool/PbGen")]
    public static void ProtoGen()
    {
        var c = new List<Type>();
        var s = new List<Type>();
		var tt = new List<Type>();
		var rr = new List<Type>();
        var tie = typeof(IExtensible);
        var rgx = new Regex(@"^[C|S|T|R]_\w+_0[x|X][0-9A-Fa-f]+$");
        Assembly[] ass = System.AppDomain.CurrentDomain.GetAssemblies();
        foreach (var oas in ass) {
            Type[] t = oas.GetTypes();
            foreach (var typ in t) {
                if (tie.IsAssignableFrom(typ)) {
                    var name = typ.Name;
                    if (rgx.IsMatch(name)) {
						switch(name[0]){
						case 'C':
							c.Add(typ);
							break;
						case 'S':
							s.Add(typ);
							break;
						case 'T':
							tt.Add(typ);
							break;
						case 'R':
							rr.Add(typ);
							break;
						default:
							break;
						}
                        Debug.Log(name);
                    }
                }
            }
        }

        //generate s file
        var nsc = c.Concat(s).Select(t => t.Namespace).Distinct();

		using(StreamWriter sw = new StreamWriter(Application.dataPath + "/Game/Scripts/CC/Runtime/Services/PacketManager_PB.cs",false))
        {
            sw.WriteLine("using System;");
            sw.WriteLine("using System.Collections;");
            sw.WriteLine("using System.Collections.Generic;");
            foreach (var ns in nsc)
            {
                sw.WriteLine("using " + ns + ";");
            }

			sw.WriteLine("namespace CC.Runtime\n{");

            sw.WriteLine("\tpublic partial class PacketManager\n\t{");

            sw.WriteLine("\t\tprivate void InitialCS()\n\t\t{");

            foreach (var cc in c)
            {
                string n = cc.Name;
                sw.WriteLine("\t\t\tRegisterCS<" + n + ">();");
            }

            sw.WriteLine("\t\t}");

            sw.WriteLine("\t\tprivate void InitialSC()\n\t\t{");

            foreach (var cc in s)
            {
                string n = cc.Name;
                sw.WriteLine("\t\t\tRegisterSC<" + n + ">();");
            }

            sw.WriteLine("\t\t}");

			sw.WriteLine("\t\tprivate void InitialTR()\n\t\t{");
			
			foreach (var ttt in tt)
			{
				string n = ttt.Name;
				sw.WriteLine("\t\t\tRegisterTR<" + n + ">();");
			}
			
			sw.WriteLine("\t\t}");


			sw.WriteLine("\t\tprivate void InitialRT()\n\t\t{");
			
			foreach (var rrr in rr)
			{
				string n = rrr.Name;
				sw.WriteLine("\t\t\tRegisterRT<" + n + ">();");
			}
			
			sw.WriteLine("\t\t}");


            sw.WriteLine("\t}");

            sw.WriteLine("}");
        }
    }
}

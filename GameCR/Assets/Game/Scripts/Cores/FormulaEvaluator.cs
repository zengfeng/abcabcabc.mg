using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Reflection;
using System.CodeDom.Compiler;

namespace Games.Module.Formulas
{
	public class FormulaEvaluator
	{
		object _Compiled = null;
		private const string staticMethodName = "__foo";

		public FormulaEvaluator(FormulaEvaluatorItem[] items) {
			ConstuctFormulaEvaluator (items);
		}

		public FormulaEvaluator(FormulaEvaluatorItem item) {
			FormulaEvaluatorItem[] items = { item };
			ConstuctFormulaEvaluator (items);
		}

		public void ConstuctFormulaEvaluator(FormulaEvaluatorItem[] items) {
			/* 构建c#编译器 
			CodeDomProvider provider = CodeDomProvider.CreateProvider("c#");
			CompilerParameters cp = new CompilerParameters ();
			cp.ReferencedAssemblies.Add("system.dll");
			// cp.ReferencedAssemblies.Add ("system.data.dll");
			// cp.ReferencedAssemblies.Add ("system.xml.dll");
			cp.GenerateExecutable = false;
			cp.GenerateInMemory = true;

			// 构建执行c#代码 
			StringBuilder code = new StringBuilder ();

			code.Append ("using System;\n");
			//code.Append ("using System.Data\n");
			//code.Append ("using System.Xml;\n");

			code.Append ("public class _Evaluator { \n");
			foreach (FormulaEvaluatorItem item in items) {
				code.AppendFormat ("public {0} {1}()", item.ReturnType.Name, item.Name);
				code.Append ("{\n");
				code.AppendFormat ("return ({0});\n", item.Expression);
				code.Append ("}\n");
			}
			code.Append("}\n");

			Debug.Log (code.ToString());

			// 得到c#代码执行结果  
			CompilerResults result = provider.CompileAssemblyFromSource (cp, code.ToString ());
			if (result.Errors.HasErrors) {
				StringBuilder error = new StringBuilder ();
				error.Append ("Error exist in formula expression:\n");
				foreach (CompilerError err in result.Errors) {
					error.AppendFormat("{0}\n", err.ErrorText)  ;
				}
				throw new Exception ("Compiler error: " + error.ToString ());
			}

			Assembly a = result.CompiledAssembly;
			_Compiled = a.CreateInstance("_Evaluator");*/
		}

		public object Evaluate(string name) {
			MethodInfo mi = _Compiled.GetType ().GetMethod (name);  
			return mi.Invoke (_Compiled, null);
		}

		public int EvaluatorInt(string name) {
			return (int)Evaluate (name);
		}

		public double EvaluatorDouble(string name) {
			return (double)Evaluate (name);
		}

		public long EvaluatorLong(string name) {
			return (long)Evaluate (name);
		}

		public string EvaluatorString(string name) {
			return (string)Evaluate (name);
		}

		public bool EvaluatorBool(string name) {
			return (bool)Evaluate (name);
		}

		static public int EvaluatorExpressionToInt(string expression) {
			FormulaEvaluator eval = new FormulaEvaluator (new FormulaEvaluatorItem (typeof(int), expression, staticMethodName));
			return eval.EvaluatorInt (staticMethodName);
		}

		static public double EvaluatorExpressionToDouble(string expression) {
			FormulaEvaluator eval = new FormulaEvaluator (new FormulaEvaluatorItem (typeof(double), expression, staticMethodName));
			return eval.EvaluatorDouble (staticMethodName);
		}

		static public long EvaluatorExpressionToLong(string expression) {
			FormulaEvaluator eval = new FormulaEvaluator (new FormulaEvaluatorItem (typeof(long), expression, staticMethodName));
			return eval.EvaluatorLong (staticMethodName);
		}

		static public string EvaluatorExpressionToString(string expression) {
			FormulaEvaluator eval = new FormulaEvaluator (new FormulaEvaluatorItem (typeof(string), expression, staticMethodName));
			return eval.EvaluatorString(staticMethodName);
		}

		static public bool EvaluatorExpressionToBool(string expression) {
			FormulaEvaluator eval = new FormulaEvaluator (new FormulaEvaluatorItem (typeof(bool), expression, staticMethodName));
			return eval.EvaluatorBool(staticMethodName);
		}
	}

	public class FormulaEvaluatorItem {
		/* 公式返回类型 */
		public Type ReturnType;
		/* 公式表达式 */
		public string Expression;
		/* 公式名称 */
		public string Name;

		public FormulaEvaluatorItem(Type returnType, string expression, string name) {
			this.ReturnType = returnType;
			this.Expression = expression;
			this.Name = name;
		}
	}
}


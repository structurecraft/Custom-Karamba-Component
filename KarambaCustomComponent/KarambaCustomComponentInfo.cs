using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace KarambaCustomComponent
{
	public class KarambaCustomComponentInfo : GH_AssemblyInfo
	{
		public override string Name
		{
			get
			{
				return "KarambaCustomComponent";
			}
		}
		public override Guid Id
		{
			get
			{
				return new Guid("d9038217-b265-4f6c-8b3d-28cc39b4bea3");
			}
		}
	}
}

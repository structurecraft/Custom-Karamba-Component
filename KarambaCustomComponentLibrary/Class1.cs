using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karamba.CrossSections;
using Karamba.Utilities;
using Karamba.Geometry;
using Karamba;

using Rhino.Geometry;

using Grasshopper.Kernel;


namespace KarambaCustomComponentLibrary
{
    public static class Convert
    {
		public static Karamba.Geometry.Point3 RNPoint3d_to_Karamba_Point3(Point3d point)
		{
			Point3 kPoint = new Point3(point.X, point.Y, point.Z);

			return kPoint;
		}

		public static bool CreateBeams(IGH_DataAccess DA)
		{
			Point3d rnstart = Point3d.Unset;
			Point3d rnend = Point3d.Unset;
			if (!DA.GetData<Point3d>(0, ref rnstart)) return false;
			if (!DA.GetData<Point3d>(1, ref rnend)) return false;

			var info = new MessageLogger();
			var k3d = new KarambaCommon.Toolkit();

			Point3 start = RNPoint3d_to_Karamba_Point3(rnstart);
			Point3 end = RNPoint3d_to_Karamba_Point3(rnend);
			Line3 curve1 = new Line3(start, end);

			CroSec crosSec = k3d.CroSec.Box();

			List<Point3> outNodes = new List<Point3>();

			List<Karamba.Elements.BuilderBeam> elems = k3d.Part.LineToBeam(new List<Karamba.Geometry.Line3> { curve1 },
				new List<string> { "Thingy" },
				new List<CroSec> { crosSec },
				info,
				out outNodes);

			var gh_elems = Karamba.GHopper.Utilities.ToGH.Values(elems);

			DA.SetData(0, gh_elems);

			return true;
		}
    }
}

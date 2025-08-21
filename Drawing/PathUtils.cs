using Neurotec.Surveillance;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Neurotec.Samples.Drawing
{
	public static class PathUtils
	{
		#region Private static methods

		private static GraphicsPath MovePathToZeroCoordinates(GraphicsPath gp)
		{
			var bounds = gp.GetBounds();
			var m = new Matrix();
			m.Translate(-bounds.X, -bounds.Y);
			gp.Transform(m);
			return gp;
		}

		#endregion

		#region Public static methods

		public static GraphicsPath Translate(this GraphicsPath gp, float dx, float dy)
		{
			using (var m = new Matrix())
			{
				m.Translate(dx, dy);
				gp.Transform(m);
			}
			return gp;
		}

		public static GraphicsPath RotateAtCenter(this GraphicsPath gp, float angle)
		{
			var bounds = gp.GetBounds();
			var center = new PointF(bounds.Width / 2.0f, bounds.Height / 2.0f);
			using (var m = new Matrix())
			{
				m.RotateAt(angle, center);
				gp.Transform(m);
			}
			return gp;
		}

		public static GraphicsPath CreateArrowPath(float scale = 1)
		{
			GraphicsPath gp = new GraphicsPath();
			gp.AddLines(new Point[]
				{
					new Point(0, 60),
					new Point(60, 0), new Point(60, 40), new Point(160, 40),
					new Point(160, 80), new Point(60, 80), new Point(60, 120),
					new Point(0, 60),
				});
			gp.CloseFigure();

			if (scale != 1)
			{
				var m = new Matrix();
				m.Scale(scale, scale);
				gp.Transform(m);
			}

			return gp;
		}

		public static GraphicsPath CreateWestPath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(42f, 22f),
				new PointF(32.553333f, 22f), new PointF(23.106667f, 22f), new PointF(13.66f, 22f),
				new PointF(16.05f, 19.61f), new PointF(18.44f, 17.22f), new PointF(20.83f, 14.83f),
				new PointF(19.886667f, 13.886667f), new PointF(18.943333f, 12.943333f), new PointF(18f, 12f),
				new PointF(14f, 16f), new PointF(10f, 20f), new PointF(6f, 24f),
				new PointF(10f, 28f), new PointF(14f, 32f), new PointF(18f, 36f),
				new PointF(18.943333f, 35.056667f), new PointF(19.886667f, 34.113333f), new PointF(20.83f, 33.17f),
				new PointF(18.44f, 30.78f), new PointF(16.05f, 28.39f), new PointF(13.66f, 26f),
				new PointF(23.106667f, 26f), new PointF(32.553333f, 26f), new PointF(42f, 26f),
				new PointF(42f, 24.666667f), new PointF(42f, 23.333333f), new PointF(42f, 22f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateNorthWestPath()
		{
			return MovePathToZeroCoordinates(CreateWestPath().RotateAtCenter(45));
		}

		public static GraphicsPath CreateNorthPath()
		{
			return MovePathToZeroCoordinates(CreateWestPath().RotateAtCenter(90));
		}

		public static GraphicsPath CreateNorthEastPath()
		{
			return MovePathToZeroCoordinates(CreateWestPath().RotateAtCenter(135));
		}

		public static GraphicsPath CreateEastPath()
		{
			return MovePathToZeroCoordinates(CreateWestPath().RotateAtCenter(180));
		}

		public static GraphicsPath CreateSouthEastPath()
		{
			return MovePathToZeroCoordinates(CreateWestPath().RotateAtCenter(225));
		}

		public static GraphicsPath CreateSouthPath()
		{
			return MovePathToZeroCoordinates(CreateWestPath().RotateAtCenter(270));
		}

		public static GraphicsPath CreateSouthWestPath()
		{
			return MovePathToZeroCoordinates(CreateWestPath().RotateAtCenter(315));
		}

		public static GraphicsPath CreateCarPath()
		{
			var gp = new GraphicsPath();

			gp.AddBeziers(new PointF[]
			{
				new PointF(37.84f, 12.02f),
				new PointF(37.367657f, 10.498854f), new PointF(35.711187f, 9.8209203f), new PointF(34.229338f, 10f),
				new PointF(27.071866f, 10.006476f), new PointF(19.913877f, 9.987044f), new PointF(12.756729f, 10.009722f),
				new PointF(11.207168f, 10.076228f), new PointF(10.19984f, 11.442382f), new PointF(9.8755986f, 12.839021f),
				new PointF(8.5943077f, 16.593242f), new PointF(7.2286095f, 20.333225f), new PointF(6f, 24.096333f),
				new PointF(6.006929f, 29.465379f), new PointF(5.9861495f, 34.83513f), new PointF(6.010376f, 40.203735f),
				new PointF(6.1053805f, 41.519888f), new PointF(7.4865764f, 42.186351f), new PointF(8.6743293f, 42f),
				new PointF(9.8401993f, 42.03331f), new PointF(11.343233f, 42.124715f), new PointF(11.843594f, 40.776562f),
				new PointF(12.131765f, 39.884075f), new PointF(11.947766f, 38.92419f), new PointF(12f, 38f),
				new PointF(20f, 38f), new PointF(28f, 38f), new PointF(36f, 38f),
				new PointF(36.076587f, 39.303669f), new PointF(35.617725f, 41.00602f), new PointF(37.048706f, 41.75769f),
				new PointF(38.037176f, 42.185178f), new PointF(39.155625f, 41.939984f), new PointF(40.205383f, 41.989624f),
				new PointF(41.523918f, 41.897675f), new PointF(42.185857f, 40.512854f), new PointF(42f, 39.325671f),
				new PointF(42f, 34.217114f), new PointF(42f, 29.108557f), new PointF(42f, 24f),
				new PointF(40.613333f, 20.006667f), new PointF(39.226667f, 16.013333f), new PointF(37.84f, 12.02f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(13f, 32f),
				new PointF(10.688332f, 32.115508f), new PointF(9.129051f, 29.173576f), new PointF(10.511523f, 27.321289f),
				new PointF(11.700402f, 25.36421f), new PointF(14.974718f, 25.680707f), new PointF(15.764688f, 27.830937f),
				new PointF(16.628578f, 29.736756f), new PointF(15.097243f, 32.058346f), new PointF(13f, 32f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(35f, 32f),
				new PointF(32.688332f, 32.115508f), new PointF(31.129051f, 29.173576f), new PointF(32.511523f, 27.321289f),
				new PointF(33.700402f, 25.36421f), new PointF(36.974718f, 25.680707f), new PointF(37.764688f, 27.830937f),
				new PointF(38.628578f, 29.736756f), new PointF(37.097243f, 32.058346f), new PointF(35f, 32f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(10f, 22f),
				new PointF(11f, 19f), new PointF(12f, 16f), new PointF(13f, 13f),
				new PointF(20.333333f, 13f), new PointF(27.666667f, 13f), new PointF(35f, 13f),
				new PointF(36f, 16f), new PointF(37f, 19f), new PointF(38f, 22f),
				new PointF(28.666667f, 22f), new PointF(19.333333f, 22f), new PointF(10f, 22f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateTruckPath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(40f, 16f),
				new PointF(38f, 16f), new PointF(36f, 16f), new PointF(34f, 16f),
				new PointF(34f, 13.333333f), new PointF(34f, 10.666667f), new PointF(34f, 8f),
				new PointF(24.530466f, 8.0137143f), new PointF(15.059548f, 7.9725401f), new PointF(5.5908813f, 8.0206421f),
				new PointF(3.2591107f, 8.1855993f), new PointF(1.7020991f, 10.541053f), new PointF(2f, 12.761682f),
				new PointF(2f, 19.841122f), new PointF(2f, 26.920561f), new PointF(2f, 34f),
				new PointF(3.3333333f, 34f), new PointF(4.6666667f, 34f), new PointF(6f, 34f),
				new PointF(5.8766744f, 37.659931f), new PointF(9.6464198f, 40.736618f), new PointF(13.208145f, 39.877949f),
				new PointF(15.927834f, 39.367144f), new PointF(18.052852f, 36.769439f), new PointF(18f, 34f),
				new PointF(22f, 34f), new PointF(26f, 34f), new PointF(30f, 34f),
				new PointF(29.876674f, 37.659931f), new PointF(33.64642f, 40.736618f), new PointF(37.208145f, 39.877949f),
				new PointF(39.927834f, 39.367144f), new PointF(42.052852f, 36.769439f), new PointF(42f, 34f),
				new PointF(43.333333f, 34f), new PointF(44.666667f, 34f), new PointF(46f, 34f),
				new PointF(46f, 30.666667f), new PointF(46f, 27.333333f), new PointF(46f, 24f),
				new PointF(44f, 21.333333f), new PointF(42f, 18.666667f), new PointF(40f, 16f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(12f, 37f),
				new PointF(9.6883317f, 37.115508f), new PointF(8.129051f, 34.173576f), new PointF(9.5115234f, 32.321289f),
				new PointF(10.761252f, 30.249715f), new PointF(14.264541f, 30.761512f), new PointF(14.865396f, 33.106724f),
				new PointF(15.502109f, 34.966466f), new PointF(13.968085f, 37.058829f), new PointF(12f, 37f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(39f, 19f),
				new PointF(40.31f, 20.666667f), new PointF(41.62f, 22.333333f), new PointF(42.93f, 24f),
				new PointF(39.953333f, 24f), new PointF(36.976667f, 24f), new PointF(34f, 24f),
				new PointF(34f, 22.333333f), new PointF(34f, 20.666667f), new PointF(34f, 19f),
				new PointF(35.666667f, 19f), new PointF(37.333333f, 19f), new PointF(39f, 19f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(36f, 37f),
				new PointF(33.688332f, 37.115508f), new PointF(32.129051f, 34.173576f), new PointF(33.511523f, 32.321289f),
				new PointF(34.761252f, 30.249715f), new PointF(38.264541f, 30.761512f), new PointF(38.865396f, 33.106724f),
				new PointF(39.502109f, 34.966466f), new PointF(37.968085f, 37.058829f), new PointF(36f, 37f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreatePersonPath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(28f, 7.6f),
				new PointF(30.620012f, 7.7170208f), new PointF(32.521581f, 4.5314446f), new PointF(31.163843f, 2.2832397f),
				new PointF(30.025059f, -0.05273598f), new PointF(26.371308f, -0.23199927f), new PointF(25.014355f, 1.9864258f),
				new PointF(23.375169f, 4.2699247f), new PointF(25.18422f, 7.684214f), new PointF(28f, 7.6f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(28.24f, 20f),
				new PointF(31.493333f, 20f), new PointF(34.746667f, 20f), new PointF(38f, 20f),
				new PointF(38f, 18.8f), new PointF(38f, 17.6f), new PointF(38f, 16.4f),
				new PointF(35.583333f, 16.4f), new PointF(33.166667f, 16.4f), new PointF(30.75f, 16.4f),
				new PointF(29.276013f, 14.014239f), new PointF(27.920132f, 11.547449f), new PointF(26.367698f, 9.2154687f),
				new PointF(25.290783f, 7.9178779f), new PointF(23.427794f, 7.8644304f), new PointF(21.977603f, 8.4917697f),
				new PointF(18.651735f, 9.5278465f), new PointF(15.325868f, 10.563923f), new PointF(12f, 11.6f),
				new PointF(12f, 15.066667f), new PointF(12f, 18.533333f), new PointF(12f, 22f),
				new PointF(13.2f, 22f), new PointF(14.4f, 22f), new PointF(15.6f, 22f),
				new PointF(15.6f, 19.556667f), new PointF(15.6f, 17.113333f), new PointF(15.6f, 14.67f),
				new PointF(17.003333f, 14.233333f), new PointF(18.406667f, 13.796667f), new PointF(19.81f, 13.36f),
				new PointF(17.206667f, 23.573333f), new PointF(14.603333f, 33.786667f), new PointF(12f, 44f),
				new PointF(13.2f, 44f), new PointF(14.4f, 44f), new PointF(15.6f, 44f),
				new PointF(17.513333f, 38.593333f), new PointF(19.426667f, 33.186667f), new PointF(21.34f, 27.78f),
				new PointF(22.893333f, 29.853333f), new PointF(24.446667f, 31.926667f), new PointF(26f, 34f),
				new PointF(26f, 37.333333f), new PointF(26f, 40.666667f), new PointF(26f, 44f),
				new PointF(27.2f, 44f), new PointF(28.4f, 44f), new PointF(29.6f, 44f),
				new PointF(29.6f, 39.73f), new PointF(29.6f, 35.46f), new PointF(29.6f, 31.19f),
				new PointF(27.94f, 28.163333f), new PointF(26.28f, 25.136667f), new PointF(24.62f, 22.11f),
				new PointF(25.11f, 20.196667f), new PointF(25.6f, 18.283333f), new PointF(26.09f, 16.37f),
				new PointF(26.806667f, 17.58f), new PointF(27.523333f, 18.79f), new PointF(28.24f, 20f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateBikePath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(32f, 9.6f),
				new PointF(34.768638f, 9.7331591f), new PointF(36.648541f, 6.2070841f), new PointF(34.983008f, 3.9864258f),
				new PointF(33.5555f, 1.637922f), new PointF(29.631044f, 2.0178062f), new PointF(28.682656f, 4.5979687f),
				new PointF(27.645108f, 6.8840531f), new PointF(29.485628f, 9.668869f), new PointF(32f, 9.6f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(38f, 24f),
				new PointF(32.466705f, 23.842661f), new PointF(27.576287f, 29.000787f), new PointF(28.01302f, 34.514348f),
				new PointF(28.138206f, 40.050688f), new PointF(33.543098f, 44.658733f), new PointF(39.021973f, 43.94834f),
				new PointF(44.355969f, 43.543488f), new PointF(48.624473f, 38.273106f), new PointF(47.94834f, 32.978027f),
				new PointF(47.518693f, 27.988369f), new PointF(43.010639f, 23.91608f), new PointF(38f, 24f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(38f, 41f),
				new PointF(33.724498f, 41.149375f), new PointF(30.138472f, 36.745755f), new PointF(31.142051f, 32.588105f),
				new PointF(31.859288f, 28.387625f), new PointF(36.858898f, 25.763311f), new PointF(40.726406f, 27.549531f),
				new PointF(44.694837f, 29.073649f), new PointF(46.296618f, 34.471973f), new PointF(43.805566f, 37.915527f),
				new PointF(42.535647f, 39.824006f), new PointF(40.294145f, 41.020062f), new PointF(38f, 41f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(29.6f, 20f),
				new PointF(32.4f, 20f), new PointF(35.2f, 20f), new PointF(38f, 20f),
				new PointF(38f, 18.8f), new PointF(38f, 17.6f), new PointF(38f, 16.4f),
				new PointF(35.866667f, 16.4f), new PointF(33.733333f, 16.4f), new PointF(31.6f, 16.4f),
				new PointF(30.113703f, 14.009413f), new PointF(28.829809f, 11.475902f), new PointF(27.199063f, 9.1871875f),
				new PointF(25.701308f, 7.595794f),new PointF(23.079787f, 8.073148f), new PointF(21.860666f, 9.7386052f),
				new PointF(19.448357f, 12.203337f), new PointF(16.916804f, 14.562195f), new PointF(14.582188f, 17.095937f),
				new PointF(13.288102f, 18.88164f), new PointF(14.284584f, 21.46256f), new PointF(16.243228f, 22.26918f),
				new PointF(18.295485f, 23.512787f), new PointF(20.347743f, 24.756393f), new PointF(22.4f, 26f),
				new PointF(22.4f, 29.333333f), new PointF(22.4f, 32.666667f), new PointF(22.4f, 36f),
				new PointF(23.6f, 36f), new PointF(24.8f, 36f), new PointF(26f, 36f),
				new PointF(26f, 31.68f), new PointF(26f, 27.36f), new PointF(26f, 23.04f),
				new PointF(24.5f, 21.926667f), new PointF(23f, 20.813333f), new PointF(21.5f, 19.7f),
				new PointF(23.046667f, 18.146667f), new PointF(24.593333f, 16.593333f), new PointF(26.14f, 15.04f),
				new PointF(27.293333f, 16.693333f), new PointF(28.446667f, 18.346667f), new PointF(29.6f, 20f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(10f, 24f),
				new PointF(4.4667045f, 23.842661f), new PointF(-0.42371278f, 29.000787f), new PointF(0.01302002f, 34.514348f),
				new PointF(0.13820604f, 40.050688f), new PointF(5.5430978f, 44.658733f), new PointF(11.021973f, 43.94834f),
				new PointF(16.355969f, 43.543488f), new PointF(20.624473f, 38.273106f), new PointF(19.94834f, 32.978027f),
				new PointF(19.518693f, 27.988369f), new PointF(15.010639f, 23.91608f), new PointF(10f, 24f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(10f, 41f),
				new PointF(5.7244978f, 41.149375f), new PointF(2.138472f, 36.745755f), new PointF(3.1420508f, 32.588105f),
				new PointF(3.8592877f, 28.387625f), new PointF(8.8588978f, 25.763311f), new PointF(12.726406f, 27.549531f),
				new PointF(16.694837f, 29.073649f), new PointF(18.296618f, 34.471973f), new PointF(15.805566f, 37.915527f),
				new PointF(14.535647f, 39.824006f), new PointF(12.294145f, 41.020062f), new PointF(10f, 41f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateBusPath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(8f, 32f),
				new PointF(7.8209537f, 33.854819f), new PointF(9.1639893f, 35.374795f), new PointF(10f, 36.738074f),
				new PointF(10.068229f, 38.081759f), new PointF(9.8423776f, 39.46508f), new PointF(10.157812f, 40.776562f),
				new PointF(10.791151f, 42.33312f), new PointF(12.562762f, 41.958019f), new PointF(13.887801f, 42f),
				new PointF(15.358829f, 42.120863f), new PointF(16.211612f, 40.609362f), new PointF(16f, 39.304494f),
				new PointF(16.119353f, 38.823419f), new PointF(15.646152f, 37.74979f), new PointF(16.49679f, 38f),
				new PointF(21.664526f, 38f), new PointF(26.832263f, 38f), new PointF(32f, 38f),
				new PointF(32.084708f, 39.255177f), new PointF(31.634743f, 40.817807f), new PointF(32.879395f, 41.657227f),
				new PointF(33.88911f, 42.22781f), new PointF(35.094001f, 41.932803f), new PointF(36.203735f, 41.989624f),
				new PointF(37.727836f, 41.879088f), new PointF(38.150862f, 40.272311f), new PointF(38f, 39.006421f),
				new PointF(38f, 38.150947f), new PointF(38f, 37.295474f), new PointF(38f, 36.44f),
				new PointF(39.650516f, 35.06357f), new PointF(40.142998f, 32.86229f), new PointF(40f, 30.807705f),
				new PointF(39.986423f, 24.325665f), new PointF(40.027348f, 17.842505f), new PointF(39.979191f, 11.361176f),
				new PointF(39.944462f, 8.5861256f), new PointF(37.885182f, 6.2224281f),new PointF(35.315f, 5.375f),
				new PointF(30.787138f, 3.7873057f), new PointF(25.897967f, 3.992525f), new PointF(21.166838f, 4.0424309f),
				new PointF(17.393563f, 4.2529197f), new PointF(13.195793f, 4.3867285f), new PointF(10.119069f, 6.8707237f),
				new PointF(8.2110748f, 8.4196383f), new PointF(7.8829712f, 10.988958f),new PointF(8f, 13.291653f),
				new PointF(8f, 19.527769f), new PointF(8f, 25.763884f), new PointF(8f, 32f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(15f, 34f),
				new PointF(12.688332f, 34.115508f), new PointF(11.129051f, 31.173576f), new PointF(12.511523f, 29.321289f),
				new PointF(13.700402f, 27.36421f), new PointF(16.974718f, 27.680707f), new PointF(17.764688f, 29.830937f),
				new PointF(18.628578f, 31.736756f), new PointF(17.097243f, 34.058346f), new PointF(15f, 34f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(33f, 34f),
				new PointF(30.688332f, 34.115508f), new PointF(29.129051f, 31.173576f), new PointF(30.511523f, 29.321289f),
				new PointF(31.700402f, 27.36421f), new PointF(34.974718f, 27.680707f), new PointF(35.764688f, 29.830937f),
				new PointF(36.628578f, 31.736756f), new PointF(35.097243f, 34.058346f), new PointF(33f, 34f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(36f, 22f),
				new PointF(28f, 22f), new PointF(20f, 22f), new PointF(12f, 22f),
				new PointF(12f, 18.666667f), new PointF(12f, 15.333333f), new PointF(12f, 12f),
				new PointF(20f, 12f), new PointF(28f, 12f), new PointF(36f, 12f),
				new PointF(36f, 15.333333f), new PointF(36f, 18.666667f), new PointF(36f, 22f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateMaskPath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(26.426734f, 7.3712407f),
				new PointF(20.094835f, 7.3228699f), new PointF(13.255776f, 9.9187356f), new PointF(9.8365982f, 15.542366f),
				new PointF(7.0327602f, 20.270853f), new PointF(7.2236506f, 26.255277f), new PointF(8.9888149f, 31.317577f),
				new PointF(10.598759f, 37.321846f), new PointF(15.920294f, 41.795764f), new PointF(21.670851f, 43.32368f),
				new PointF(27.080433f, 44.804627f), new PointF(33.524592f, 43.34159f), new PointF(37.851321f, 39.647498f),
				new PointF(42.761335f, 35.69229f), new PointF(45.597338f, 29.297933f), new PointF(45.534023f, 22.99972f),
				new PointF(45.496496f, 18.350516f), new PointF(42.98189f, 13.931797f), new PointF(39.158382f, 11.365701f),
				new PointF(35.453032f, 8.7809786f), new PointF(30.917981f, 7.4490529f), new PointF(26.426734f, 7.3712407f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(27.672666f, 10.538905f),
				new PointF(32.102783f, 10.972167f), new PointF(37.138689f, 11.731603f), new PointF(40.097106f, 15.459122f),
				new PointF(42.084313f, 18.002298f), new PointF(42.969491f, 21.359494f), new PointF(42.636238f, 24.555675f),
				new PointF(42.360079f, 25.856714f), new PointF(40.878694f, 25.336607f), new PointF(39.93669f, 25.43557f),
				new PointF(30.72242f, 23.938407f), new PointF(20.635001f, 24.535998f), new PointF(10.478686f, 25.298878f),
				new PointF(10.28657f, 20.866961f), new PointF(11.621888f, 15.926788f), new PointF(15.473331f, 13.343597f),
				new PointF(19.022969f, 10.846219f), new PointF(23.500987f, 10.670313f), new PointF(27.672666f, 10.538905f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(20.477738f, 15.733223f),
				new PointF(18.232983f, 15.259543f), new PointF(15.825032f, 18.341772f), new PointF(17.786769f, 20.104886f),
				new PointF(19.57745f, 21.888206f), new PointF(23.291922f, 20.650708f), new PointF(23.232379f, 17.973713f),
				new PointF(23.107074f, 16.633465f), new PointF(21.707116f, 15.804934f), new PointF(20.477738f, 15.733223f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(35.15537f, 15.733223f),
				new PointF(32.910302f, 15.25945f), new PointF(30.505076f, 18.3432f), new PointF(32.466991f, 20.105145f),
				new PointF(34.257983f, 21.888514f), new PointF(37.972843f, 20.650088f), new PointF(37.912282f, 17.972763f),
				new PointF(37.786252f, 16.632043f), new PointF(36.384911f, 15.804848f), new PointF(35.15537f, 15.733223f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateDarkGlassesPath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(30.602054f, 252.86823f),
				new PointF(24.843367f, 252.61263f), new PointF(19.537293f, 256.7229f), new PointF(17.510627f, 261.97647f),
				new PointF(16.260404f, 265.03284f), new PointF(16.237507f, 268.53045f), new PointF(17.40851f, 271.61444f),
				new PointF(19.364038f, 277.68373f), new PointF(26.022713f, 281.4354f), new PointF(32.233268f, 280.79965f),
				new PointF(35.750037f, 280.49233f), new PointF(38.998774f, 278.58359f), new PointF(41.317646f, 275.97748f),
				new PointF(45.968555f, 270.51248f), new PointF(45.601161f, 261.34471f), new PointF(40.127591f, 256.56234f),
				new PointF(37.522732f, 254.24276f), new PointF(34.107175f, 252.84211f), new PointF(30.602054f, 252.86823f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(74.167035f, 252.86823f),
				new PointF(65.088198f, 252.52373f), new PointF(57.791277f, 262.44259f), new PointF(60.792763f, 271.00569f),
				new PointF(63.148304f, 279.77484f), new PointF(74.77566f, 283.83031f), new PointF(82.072061f, 278.42288f),
				new PointF(89.756874f, 273.58113f), new PointF(90.192838f, 261.27519f), new PointF(82.869901f, 255.90177f),
				new PointF(80.420396f, 253.94763f), new PointF(77.300074f, 252.86039f), new PointF(74.167035f, 252.86823f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(43.219862f, 262.01857f),
				new PointF(46.488624f, 259.32803f), new PointF(51.037248f, 258.20223f), new PointF(55.162851f, 259.24226f),
				new PointF(57.278582f, 259.75273f), new PointF(59.252225f, 260.75498f), new PointF(61.015252f, 262.01857f),
				new PointF(61.015252f, 263.50517f), new PointF(61.015252f, 264.99176f), new PointF(61.015252f, 266.47836f),
				new PointF(58.630066f, 265.18469f), new PointF(56.162485f, 263.96078f), new PointF(53.512147f, 263.31839f),
				new PointF(52.239008f, 262.97918f), new PointF(50.899028f, 263.14005f), new PointF(49.661141f, 263.54405f),
				new PointF(47.403903f, 264.25308f), new PointF(45.276061f, 265.31987f), new PointF(43.219862f, 266.47836f),
				new PointF(43.219862f, 264.99176f), new PointF(43.219862f, 263.50517f), new PointF(43.219862f, 262.01857f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(10.543715f, 247.9924f),
				new PointF(13.981317f, 250.93105f), new PointF(17.418918f, 253.8697f), new PointF(20.85652f, 256.80835f),
				new PointF(19.815774f, 258.24591f), new PointF(18.775029f, 259.68347f), new PointF(17.734283f, 261.12103f),
				new PointF(14.304324f, 258.09329f), new PointF(10.874364f, 255.06554f), new PointF(7.4444052f, 252.0378f),
				new PointF(8.4775085f, 250.68933f), new PointF(9.5106117f, 249.34087f), new PointF(10.543715f, 247.9924f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(61.214078f, 243.06492f),
				new PointF(66.398231f, 246.61419f), new PointF(71.582385f, 250.16347f), new PointF(76.766538f, 253.71274f),
				new PointF(75.368743f, 255.07664f), new PointF(73.970948f, 256.44053f), new PointF(72.573153f, 257.80443f),
				new PointF(67.154779f, 254.40519f), new PointF(61.736407f, 251.00593f), new PointF(56.318034f, 247.60669f),
				new PointF(57.950049f, 246.09277f), new PointF(59.582063f, 244.57885f), new PointF(61.214078f, 243.06492f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateGlassesPath()
		{
			var gp = new GraphicsPath();

			gp.AddBeziers(new PointF[]
			{
				new PointF(30.602054f,252.86823f),
				new PointF(21.523217f,252.52373f), new PointF(14.226296f,262.44259f), new PointF(17.227782f,271.00569f),
				new PointF(19.583324f,279.77484f), new PointF(31.210679f,283.83031f), new PointF(38.50708f,278.42288f),
				new PointF(46.191894f,273.58113f), new PointF(46.627859f,261.27519f), new PointF(39.304921f,255.90177f),
				new PointF(36.855416f,253.94763f), new PointF(33.735093f,252.86039f), new PointF(30.602054f,252.86823f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(30.602054f,256.86799f),
				new PointF(37.087354f,256.62147f), new PointF(42.299803f,263.70678f), new PointF(40.155811f,269.82362f),
				new PointF(38.473282f,276.08766f), new PointF(30.167492f,278.98426f), new PointF(24.955646f,275.12162f),
				new PointF(19.466679f,271.6631f), new PointF(19.155285f,262.87329f), new PointF(24.385711f,259.03499f),
				new PointF(26.135336f,257.63911f), new PointF(28.364144f,256.86244f), new PointF(30.602054f,256.86799f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(74.167035f,252.86823f),
				new PointF(65.088198f,252.52373f), new PointF(57.791277f,262.44259f), new PointF(60.792763f,271.00569f),
				new PointF(63.148304f,279.77484f), new PointF(74.77566f,283.83031f), new PointF(82.072061f,278.42288f),
				new PointF(89.756874f,273.58113f), new PointF(90.192838f,261.27519f), new PointF(82.869901f,255.90177f),
				new PointF(80.420396f,253.94763f), new PointF(77.300074f,252.86039f), new PointF(74.167035f,252.86823f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(74.167035f,256.86798f),
				new PointF(80.65234f,256.62146f), new PointF(85.864786f,263.70677f), new PointF(83.720792f,269.82362f),
				new PointF(82.038263f,276.08766f), new PointF(73.732473f,278.98426f), new PointF(68.520627f,275.12162f),
				new PointF(63.031662f,271.6631f), new PointF(62.720265f,262.87329f), new PointF(67.950685f,259.03498f),
				new PointF(69.70031f,257.6391f), new PointF(71.929122f,256.86243f), new PointF(74.167035f,256.86798f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(43.219862f,262.01857f),
				new PointF(46.488624f,259.32803f), new PointF(51.037248f,258.20223f), new PointF(55.162851f,259.24226f),
				new PointF(57.278582f,259.75273f), new PointF(59.252225f,260.75498f), new PointF(61.015252f,262.01857f),
				new PointF(61.015252f,263.50517f), new PointF(61.015252f,264.99176f), new PointF(61.015252f,266.47836f),
				new PointF(58.630066f,265.18469f), new PointF(56.162485f,263.96078f), new PointF(53.512147f,263.31839f),
				new PointF(52.239008f,262.97918f), new PointF(50.899028f,263.14005f), new PointF(49.661141f,263.54405f),
				new PointF(47.403903f,264.25308f), new PointF(45.276061f,265.31987f), new PointF(43.219862f,266.47836f),
				new PointF(43.219862f,264.99176f), new PointF(43.219862f,263.50517f), new PointF(43.219862f,262.01857f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(10.543715f,247.9924f),
				new PointF(13.981317f,250.93105f), new PointF(17.418918f,253.8697f), new PointF(20.85652f,256.80835f),
				new PointF(19.815774f,258.24591f), new PointF(18.775029f,259.68347f), new PointF(17.734283f,261.12103f),
				new PointF(14.304324f,258.09329f), new PointF(10.874364f,255.06554f), new PointF(7.4444052f,252.0378f),
				new PointF(8.4775085f,250.68933f), new PointF(9.5106117f,249.34087f), new PointF(10.543715f,247.9924f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(61.214078f,243.06492f),
				new PointF(66.398231f,246.61419f), new PointF(71.582385f,250.16347f), new PointF(76.766538f,253.71274f),
				new PointF(75.368743f,255.07664f), new PointF(73.970948f,256.44053f), new PointF(72.573153f,257.80443f),
				new PointF(67.154779f,254.40519f), new PointF(61.736407f,251.00593f), new PointF(56.318034f,247.60669f),
				new PointF(57.950049f,246.09277f), new PointF(59.582063f,244.57885f), new PointF(61.214078f,243.06492f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateMustachePath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(113.72484f,174.12374f),
				new PointF(109.11565f,176.76192f), new PointF(103.59246f,182.28676f), new PointF(98.406006f,177.24766f),
				new PointF(93.433517f,173.76622f), new PointF(86.715265f,173.13744f), new PointF(81.678763f,176.80314f),
				new PointF(73.338997f,181.3371f), new PointF(68.118504f,190.12624f), new PointF(59.478298f,194.13621f),
				new PointF(54.708431f,196.11329f), new PointF(47.553102f,195.26289f), new PointF(45.451329f,189.9387f),
				new PointF(43.446546f,184.32552f), new PointF(53.698631f,183.14946f), new PointF(53.534158f,180.6399f),
				new PointF(48.775622f,177.97953f), new PointF(42.845202f,178.95407f), new PointF(39.292634f,183.08165f),
				new PointF(33.248192f,188.43194f), new PointF(32.372085f,198.71955f), new PointF(38.213375f,204.56623f),
				new PointF(46.724228f,213.49521f), new PointF(60.43512f,214.48445f), new PointF(71.879908f,212.0217f),
				new PointF(82.97861f,209.5452f), new PointF(93.495f,202.87096f), new PointF(99.307687f,192.96588f),
				new PointF(104.35065f,189.14907f), new PointF(105.78425f,197.84753f), new PointF(109.27437f,200.03081f),
				new PointF(121.08522f,211.72727f), new PointF(139.58731f,215.95985f), new PointF(155.44585f,211.29533f),
				new PointF(162.65192f,209.38533f), new PointF(168.77565f,203.35046f), new PointF(169.64267f,195.78236f),
				new PointF(170.93229f,186.93496f), new PointF(162.40982f,177.11656f), new PointF(153.2069f,179.51027f),
				new PointF(146.54955f,181.6758f), new PointF(154.82767f,183.58434f), new PointF(157.16672f,185.15602f),
				new PointF(161.63051f,190.59966f), new PointF(153.29536f,196.99117f), new PointF(147.91299f,194.82647f),
				new PointF(141.64618f,194.06998f), new PointF(137.20327f,189.44809f), new PointF(133.11319f,185.1189f),
				new PointF(127.74147f,179.98555f), new PointF(121.50091f,174.58574f), new PointF(113.72484f,174.12374f)
			});

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateMalePath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(21.409546f,-44.653088f),
				new PointF(21.409546f,-42.319725f), new PointF(21.409546f,-39.986362f), new PointF(21.409546f,-37.652999f),
				new PointF(25.280111f,-37.652999f), new PointF(29.150675f,-37.652999f), new PointF(33.02124f,-37.652999f),
				new PointF(28.283545f,-32.915304f), new PointF(23.545849f,-28.177609f), new PointF(18.808154f,-23.439913f),
				new PointF(17.292276f,-24.593693f), new PointF(12.940242f,-27.48675f), new PointF(9.8734873f,-28.326582f),
				new PointF(0.63416962f,-31.589003f), new PointF(-10.284484f,-30.245298f), new PointF(-17.968112f,-23.976953f),
				new PointF(-27.797514f,-16.446685f), new PointF(-32.941646f,-2.5682327f), new PointF(-28.53835f,9.3041916f),
				new PointF(-24.562061f,23.360514f), new PointF(-8.8663154f,31.952025f), new PointF(5.22196f,29.631947f),
				new PointF(13.250016f,28.326627f), new PointF(20.610713f,23.370368f), new PointF(25.096387f,16.632991f),
				new PointF(31.836381f,6.1342753f), new PointF(31.493018f,-8.6056882f), new PointF(23.78046f,-18.513082f),
				new PointF(28.490079f,-23.222699f), new PointF(33.199694f,-27.932316f), new PointF(37.909314f,-32.641934f),
				new PointF(37.909314f,-28.812365f), new PointF(37.909314f,-24.982798f), new PointF(37.909314f,-21.153231f),
				new PointF(40.242677f,-21.153231f), new PointF(42.57604f,-21.153231f), new PointF(44.909403f,-21.153231f),
				new PointF(44.906673f,-29.009475f), new PointF(44.91393f,-36.862086f), new PointF(44.909403f,-44.653088f),
				new PointF(37.076118f,-44.653088f), new PointF(29.242832f,-44.653088f), new PointF(21.409546f,-44.653088f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(0.66662595f,-22.013643f),
				new PointF(14.527637f,-22.177893f), new PointF(25.733227f,-6.565901f), new PointF(21.017838f,6.501412f),
				new PointF(17.538079f,19.955599f), new PointF(-0.53255145f,26.504921f), new PointF(-11.879601f,18.54501f),
				new PointF(-23.109164f,11.987232f), new PointF(-25.216161f,-5.0975484f), new PointF(-16.591331f,-14.589567f),
				new PointF(-12.221857f,-19.371623f), new PointF(-5.8325985f,-22.206391f), new PointF(0.66662595f,-22.013643f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateFemalePath()
		{
			var gp = new GraphicsPath();

			gp.AddBeziers(new PointF[]
			{
				new PointF(29.223538f, 236.84859f),
				new PointF(10.955556f, 236.66462f), new PointF(-4.010453f, 256.50502f), new PointF(0.94086512f, 274.03208f),
				new PointF(3.0173863f, 283.52461f), new PointF(10.295164f, 291.39213f), new PointF(19.349854f, 294.72178f),
				new PointF(21.11909f, 296.08626f), new PointF(26.645811f, 295.79075f), new PointF(26.132255f, 297.05308f),
				new PointF(26.132255f, 302.79694f), new PointF(26.132255f, 308.54083f), new PointF(26.132255f, 314.2847f),
				new PointF(20.841105f, 314.2847f), new PointF(15.549955f, 314.2847f), new PointF(10.258805f, 314.2847f),
				new PointF(10.258805f, 316.95138f), new PointF(10.258805f, 319.61804f), new PointF(10.258805f, 322.28472f),
				new PointF(15.549955f, 322.28472f), new PointF(20.841105f, 322.28472f), new PointF(26.132255f, 322.28472f),
				new PointF(26.132255f, 327.05169f), new PointF(26.132255f, 331.81869f), new PointF(26.132255f, 336.58566f),
				new PointF(28.798932f, 336.58566f), new PointF(31.465607f, 336.58566f), new PointF(34.132284f, 336.58566f),
				new PointF(34.132284f, 331.81869f), new PointF(34.132284f, 327.05169f), new PointF(34.132284f, 322.28472f),
				new PointF(39.507665f, 322.28472f), new PointF(44.883048f, 322.28472f), new PointF(50.258429f, 322.28472f),
				new PointF(50.258429f, 319.61804f), new PointF(50.258429f, 316.95138f), new PointF(50.258429f, 314.2847f),
				new PointF(44.883048f, 314.2847f), new PointF(39.507665f, 314.2847f), new PointF(34.132284f, 314.2847f),
				new PointF(34.132284f, 308.41185f), new PointF(34.132284f, 302.53897f), new PointF(34.132284f, 296.66612f),
				new PointF(46.392208f, 295.25515f), new PointF(57.250933f, 285.37217f), new PointF(59.377537f, 273.13178f),
				new PointF(61.894817f, 261.44203f), new PointF(57.150534f, 248.21761f), new PointF(46.748056f, 241.88535f),
				new PointF(41.606208f, 238.44236f), new PointF(35.399228f, 236.71929f), new PointF(29.223538f, 236.84859f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(30.799153f, 244.85378f),
				new PointF(44.660163f, 244.68954f), new PointF(55.865751f, 260.30153f), new PointF(51.150366f, 273.36885f),
				new PointF(47.6706f, 286.82301f), new PointF(29.599977f, 293.37235f), new PointF(18.252926f, 285.41244f),
				new PointF(6.6170526f, 278.63768f), new PointF(4.8218431f, 260.56984f), new PointF(14.441892f, 251.33977f),
				new PointF(18.778494f, 247.13182f), new PointF(24.732903f, 244.67249f), new PointF(30.799153f, 244.85378f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateBeardPath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(17.773348f,155.21335f),
				new PointF(16.172881f,163.69451f), new PointF(14.96519f,172.42005f), new PointF(16.009754f,181.04632f),
				new PointF(16.471763f,185.56853f), new PointF(18.739602f,189.78562f), new PointF(22.168692f,192.75449f),
				new PointF(26.32942f,196.3986f), new PointF(31.44897f,199.02185f), new PointF(36.854791f,200.19708f),
				new PointF(41.717325f,201.18126f), new PointF(46.659063f,199.71634f), new PointF(50.908048f,197.37181f),
				new PointF(56.684162f,194.31443f), new PointF(62.029857f,189.22206f), new PointF(63.098448f,182.50397f),
				new PointF(64.45611f,174.38353f), new PointF(63.415407f,166.09011f), new PointF(62.133361f,158.02892f),
				new PointF(61.86542f,156.64299f), new PointF(62.060085f,154.61101f), new PointF(60.14504f,155.27187f),
				new PointF(58.953728f,155.27299f), new PointF(57.531779f,155.08933f), new PointF(58.678604f,156.78093f),
				new PointF(59.916239f,161.78492f), new PointF(61.142759f,167.10955f), new PointF(59.875868f,172.22613f),
				new PointF(59.261469f,174.9848f), new PointF(56.421932f,176.79779f), new PointF(53.652814f,176.38667f),
				new PointF(48.847727f,175.93133f), new PointF(44.477878f,173.14921f), new PointF(39.555611f,173.4778f),
				new PointF(34.288572f,173.05508f), new PointF(29.71909f,176.62645f), new PointF(24.499207f,176.41503f),
				new PointF(21.489571f,176.27295f), new PointF(19.718402f,173.31534f), new PointF(19.514904f,170.58209f),
				new PointF(18.966267f,165.47758f), new PointF(20.119343f,160.36466f), new PointF(21.515239f,155.48103f),
				new PointF(20.267942f,155.3918f), new PointF(19.020645f,155.30258f), new PointF(17.773348f,155.21335f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(44.502466f,179.46716f),
				new PointF(42.598879f,180.60111f), new PointF(40.561656f,183.73959f), new PointF(38.658069f,184.87354f),
				new PointF(36.725026f,183.74527f), new PointF(34.925617f,180.61249f), new PointF(32.992574f,179.48422f),
				new PointF(36.829205f,179.47853f), new PointF(40.665835f,179.47285f), new PointF(44.502466f,179.46716f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateSmilePath()
		{
			var gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
			{
				new PointF(56.749507f,79.123851f),
				new PointF(35.295686f,78.964583f), new PointF(16.159503f,95.439705f), new PointF(10.161518f,115.54083f),
				new PointF(6.7891969f,125.97498f), new PointF(7.6582655f,137.38682f), new PointF(11.632041f,147.52294f),
				new PointF(20.800026f,172.87558f), new PointF(52.862059f,185.97497f), new PointF(77.454815f,175.56797f),
				new PointF(89.087258f,170.42745f), new PointF(99.313197f,161.31924f), new PointF(104.04797f,149.31744f),
				new PointF(112.35772f,129.68809f), new PointF(107.72158f,104.33469f), new PointF(90.551113f,90.905802f),
				new PointF(81.152046f,83.055671f), new PointF(68.992421f,78.818728f), new PointF(56.749507f,79.123851f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(59.628402f,84.126646f),
				new PointF(80.275908f,83.984443f), new PointF(98.429883f,100.8703f), new PointF(102.52218f,120.63625f),
				new PointF(105.09054f,132.22797f), new PointF(102.11164f,144.66106f), new PointF(95.689802f,154.49821f),
				new PointF(82.848063f,173.35638f), new PointF(54.597109f,180.34589f), new PointF(35.094044f,167.83565f),
				new PointF(25.544432f,162.27402f), new PointF(18.242463f,153.05869f), new PointF(15.328945f,142.36778f),
				new PointF(10.243029f,125.22281f), new PointF(15.470662f,104.6348f), new PointF(30.292206f,93.904862f),
				new PointF(38.523145f,87.303045f), new PointF(49.103242f,83.891598f), new PointF(59.628402f,84.126646f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(74.51328f,102.89863f),
				new PointF(67.48523f,102.48105f), new PointF(63.764434f,112.39534f), new PointF(69.084983f,116.85462f),
				new PointF(73.992326f,121.88368f), new PointF(83.651954f,117.04711f), new PointF(82.493127f,110.09742f),
				new PointF(82.182151f,106.11685f), new PointF(78.451452f,102.90564f), new PointF(74.51328f,102.89863f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(41.251229f,103.27638f),
				new PointF(34.223184f,102.85979f), new PointF(30.502725f,112.77349f), new PointF(35.823443f,117.23289f),
				new PointF(40.730736f,122.26201f), new PointF(50.390014f,117.42523f), new PointF(49.231073f,110.47568f),
				new PointF(48.920069f,106.49509f), new PointF(45.189552f,103.28346f), new PointF(41.251229f,103.27638f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(30.157848f,142.22129f),
				new PointF(26.822638f,143.9145f), new PointF(33.94592f,148.92783f), new PointF(35.507808f,151.07682f),
				new PointF(47.526021f,161.89267f), new PointF(66.964186f,163.16099f), new PointF(80.091567f,153.59168f),
				new PointF(84.133041f,150.7306f), new PointF(87.548018f,146.92265f), new PointF(89.71132f,142.45125f),
				new PointF(84.907254f,142.80768f), new PointF(80.471411f,141.63303f), new PointF(77.372302f,146.12307f),
				new PointF(65.278198f,155.08221f), new PointF(46.536096f,153.93958f), new PointF(36.136812f,142.84709f),
				new PointF(34.124034f,142.92085f), new PointF(32.164763f,142.26602f), new PointF(30.157848f,142.22129f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateBlinkPath()
		{
			GraphicsPath gp = new GraphicsPath();
			gp.AddBeziers(new PointF[]
				{
					new PointF(435.85713f, 829.28988f),
					new PointF(435.85713f, 826.14134f), new PointF(435.85713f, 822.99279f), new PointF(435.85713f, 819.84425f),
					new PointF(431.52818f, 819.40493f), new PointF(427.2124f, 818.65847f), new PointF(422.85713f, 818.61225f),
					new PointF(420.07381f, 823.2792f), new PointF(419.55592f, 829.21363f), new PointF(415.81523f, 833.2958f),
					new PointF(411.88195f, 832.96632f), new PointF(402.56019f, 832.2983f), new PointF(403.59168f, 826.82747f),
					new PointF(404.49412f, 822.06959f), new PointF(407.38289f, 817.62303f), new PointF(407.23492f, 812.74024f),
					new PointF(403.97397f, 810.47656f), new PointF(400.43818f, 808.64918f), new PointF(397.01142f, 806.65399f),
					new PointF(393.40481f, 810.75036f), new PointF(390.50368f, 815.74657f), new PointF(385.74505f, 818.59108f),
					new PointF(381.53086f, 816.45821f), new PointF(371.30273f, 811.69373f), new PointF(377.16061f, 806.33105f),
					new PointF(379.68245f, 802.38916f), new PointF(387.71098f, 797.5141f), new PointF(381.91398f, 792.84178f),
					new PointF(379.33556f, 788.89088f), new PointF(373.92253f, 785.09903f), new PointF(374.27125f, 780.28926f),
					new PointF(378.67829f, 776.95361f), new PointF(384.55646f, 773.59246f), new PointF(390.26417f, 775.09226f),
					new PointF(397.24491f, 778.82048f), new PointF(401.76433f, 785.81843f), new PointF(408.41041f, 790.09015f),
					new PointF(424.88655f, 801.96214f), new PointF(447.55374f, 803.93538f), new PointF(466.25184f, 796.46734f),
					new PointF(476.00331f, 792.64778f), new PointF(483.5214f, 785.18173f), new PointF(491.17644f, 778.33114f),
					new PointF(495.00098f, 774.23975f), new PointF(501.2108f, 773.54521f), new PointF(505.75694f, 776.89247f),
					new PointF(510.64456f, 778.33781f), new PointF(513.78144f, 782.54911f), new PointF(508.97685f, 786.32591f),
					new PointF(506.39681f, 789.80997f), new PointF(503.5728f, 793.10166f), new PointF(500.83072f, 796.45699f),
					new PointF(504.57117f, 801.05482f), new PointF(508.90555f, 805.26143f), new PointF(511.85713f, 810.42573f),
					new PointF(508.73325f, 813.98587f), new PointF(502.37734f, 823.35014f), new PointF(498.04955f, 816.79531f),
					new PointF(494.57914f, 813.95975f), new PointF(492.73279f, 806.66381f), new PointF(487.41682f, 807.78358f),
					new PointF(482.55765f, 810.13083f), new PointF(475.96485f, 813.63492f), new PointF(480.85493f, 819.58648f),
					new PointF(482.7528f, 823.71135f), new PointF(486.27353f, 830.95944f), new PointF(479.19952f, 832.07128f),
					new PointF(475.2306f, 833.59222f), new PointF(469.68497f, 836.70712f), new PointF(468.77703f, 830.32197f),
					new PointF(466.1358f, 826.89057f), new PointF(466.61264f, 818.27641f), new PointF(461.63576f, 818.56925f),
					new PointF(458.07069f, 819.02156f), new PointF(454.49876f, 819.41691f), new PointF(450.92969f, 819.83583f),
					new PointF(450.73884f, 825.93985f), new PointF(450.54798f, 832.04386f), new PointF(450.35713f, 838.14788f),
					new PointF(445.5238f, 838.34375f), new PointF(440.69046f, 838.53963f), new PointF(435.85713f, 838.7355f),
					new PointF(435.85713f, 835.58696f), new PointF(435.85713f, 832.43842f), new PointF(435.85713f, 829.28988f),
				});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateMouthOpenPath()
		{
			var gp = new GraphicsPath();

			gp.AddBeziers(new PointF[]
			{
				new PointF(50.132339f, 196.86757f),
				new PointF(17.707621f, 195.63639f), new PointF(-8.3534707f, 231.06069f), new PointF(2.3654555f, 261.64363f),
				new PointF(10.777555f, 292.96325f), new PointF(52.305407f, 307.44747f), new PointF(78.364471f, 288.13447f),
				new PointF(105.81014f, 270.84202f), new PointF(107.36658f, 226.89186f), new PointF(81.212922f, 207.70125f),
				new PointF(72.464919f, 200.72256f), new PointF(61.321357f, 196.83972f), new PointF(50.132339f, 196.86757f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(50.132339f, 201.86778f),
				new PointF(79.314375f, 200.75985f), new PointF(102.76936f, 232.64153f), new PointF(93.122273f, 260.16602f),
				new PointF(85.551316f, 288.35347f), new PointF(48.176439f, 301.38931f), new PointF(24.723457f, 284.00748f),
				new PointF(0.02248843f, 268.44424f), new PointF(-1.378153f, 228.88931f), new PointF(22.160181f, 211.61797f),
				new PointF(30.033306f, 205.33726f), new PointF(40.062361f, 201.84276f), new PointF(50.132339f, 201.86778f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(66.385095f, 220.63563f),
				new PointF(60.204818f, 220.33422f), new PointF(56.045337f, 228.22332f), new PointF(59.782365f, 233.1528f),
				new PointF(63.023583f, 238.4266f), new PointF(71.882465f, 237.40354f), new PointF(73.841424f, 231.53457f),
				new PointF(75.956543f, 226.48162f), new PointF(71.876398f, 220.49337f), new PointF(66.385095f, 220.63563f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(33.12356f, 221.01338f),
				new PointF(26.943282f, 220.71197f), new PointF(22.783802f, 228.60107f), new PointF(26.52083f, 233.53055f),
				new PointF(29.762045f, 238.80435f), new PointF(38.62093f, 237.7813f), new PointF(40.579889f, 231.91232f),
				new PointF(42.695008f, 226.85938f), new PointF(38.614865f, 220.87113f), new PointF(33.12356f, 221.01338f),
			});
			gp.CloseFigure();

			gp.AddBeziers(new PointF[]
			{
				new PointF(51.349319f, 249.68811f),
				new PointF(40.750577f, 249.82492f), new PointF(34.886767f, 262.35097f), new PointF(37.694991f, 271.63228f),
				new PointF(39.290572f, 281.16035f), new PointF(51.658218f, 287.587f), new PointF(59.419534f, 280.60663f),
				new PointF(69.102895f, 272.88765f), new PointF(67.282752f, 254.57156f), new PointF(55.172731f, 250.30541f),
				new PointF(53.941704f, 249.89942f), new PointF(52.645391f, 249.68756f), new PointF(51.349319f, 249.68811f),
			});
			gp.CloseFigure();

			return MovePathToZeroCoordinates(gp);
		}

		public static GraphicsPath CreateCirclePath()
		{
			var gp = new GraphicsPath();
			gp.AddEllipse(0, 0, 100, 100);

			var bounds = gp.GetBounds();
			var m = new Matrix();
			m.Translate(-bounds.X, -bounds.Y);
			gp.Transform(m);

			return gp;
		}

		public static void PaintAttribute(Graphics g, Control target, GraphicsPath path, Brush brush, Pen pen = null)
		{
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = SmoothingMode.AntiAlias;

			var w = target.Width - 1;
			var h = target.Height - 1;

			var bounds = path.GetBounds();
			var scaleY = w / bounds.Height;
			var scaleX = h / bounds.Width;
			var scale = Math.Min(scaleX, scaleY);
			var dx = (target.Width - bounds.Width * scale) / 2;
			var dy = (target.Height - bounds.Height * scale) / 2;
			var m = new Matrix();
			m.Translate(dx, dy);
			m.Scale(scale, scale);
			path.Transform(m);

			g.FillPath(brush, path);
			if (pen != null)
				g.DrawPath(pen, path);
		}

		public static Brush GetColorBrush(Control target, NSurveillanceObjectColorDetails colorDetails, NSurveillanceObjectColor flag)
		{
			var color = Color.Transparent;
			switch (flag)
			{
				case NSurveillanceObjectColor.Red:
					color = Color.Red;
					break;
				case NSurveillanceObjectColor.Orange:
					color = Color.Orange;
					break;
				case NSurveillanceObjectColor.Yellow:
					color = Color.Yellow;
					break;
				case NSurveillanceObjectColor.Green:
					color = Color.Green;
					break;
				case NSurveillanceObjectColor.Blue:
					color = Color.Blue;
					break;
				case NSurveillanceObjectColor.Silver:
					color = Color.Silver;
					break;
				case NSurveillanceObjectColor.White:
					color = Color.White;
					break;
				case NSurveillanceObjectColor.Black:
					color = Color.Black;
					break;
				case NSurveillanceObjectColor.Brown:
					color = Color.Brown;
					break;
				case NSurveillanceObjectColor.Gray:
					color = Color.Gray;
					break;
				default:
					break;
			}

			if ((colorDetails.Color & flag) == flag)
			{
				return new SolidBrush(color);
			}
			else
			{
				return GetGradientBrush(target.ClientRectangle, color, color != Color.White ? Color.White : Color.LightGray);
			}
		}

		public static Brush GetGradientBrush(Rectangle clientRect, Color baseColor, Color secondaryColor)
		{
			var brush = new LinearGradientBrush(clientRect, baseColor, secondaryColor, 90);
			var cb = new ColorBlend
			{
				Positions = new[] { 0, 1.0f },
				Colors = new[] { baseColor, secondaryColor }
			};
			brush.InterpolationColors = cb;
			return brush;
		}

		#endregion
	}
}

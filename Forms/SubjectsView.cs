using Neurotec.Biometrics;
using Neurotec.Samples.Code;
using Neurotec.Samples.Config;
using Neurotec.Samples.Drawing;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class SubjectsView : UserControl, INotifyPropertyChanged
	{
		#region Private types

		private class ObjectNode : IDisposable
		{
			#region Nested types

			public class TextAndRect
			{
				public string Text;
				public RectangleF TextRect;
				public string Hint;

				public virtual bool TestHit(Point position)
				{
					return TextRect.Contains(position);
				}
			}

			public class TextAndIcon<T> : TextAndRect
			{
				public T Value;
				public float Conf;
				public RectangleF IconRect;

				public override bool TestHit(Point position)
				{
					return base.TestHit(position) || IconRect.Contains(position);
				}
			}

			public class AnalyticEventTextAndIcon : TextAndIcon<long>
			{
				public bool IsTripwire { get; set; }

				public AnalyticEventTextAndIcon(long eventId)
				{
					Value = eventId;
				}
			}

			public class AttributeIcon : TextAndIcon<object>
			{
				public bool Set { get; set; }
			}

			public class TypeTextAndIcon : TextAndIcon<NSurveillanceObjectType>
			{
			}

			public class DirectionTextAndIcon : TextAndIcon<NSurveillanceObjectDirection>
			{
			}

			public class ColorTextAndIcon : TextAndIcon<NSurveillanceObjectColor>
			{
				public Color GetColorValue()
				{
					switch (Value)
					{
						case NSurveillanceObjectColor.Red: return Color.Red;
						case NSurveillanceObjectColor.Orange: return Color.Orange;
						case NSurveillanceObjectColor.Yellow: return Color.Yellow;
						case NSurveillanceObjectColor.Green: return Color.Green;
						case NSurveillanceObjectColor.Blue: return Color.Blue;
						case NSurveillanceObjectColor.Silver: return Color.Silver;
						case NSurveillanceObjectColor.White: return Color.White;
						case NSurveillanceObjectColor.Black: return Color.Black;
						case NSurveillanceObjectColor.Brown: return Color.Brown;
						case NSurveillanceObjectColor.Gray: return Color.Gray;
						default:
							return Color.Transparent;
					}
				}
			}

			#endregion

			#region Public constructor

			public ObjectNode(SubjectInfo si)
			{
				Info = si;
			}

			#endregion

			#region Public properties

			public bool IsSelected { get; set; }
			public SubjectInfo Info { get; set; }

			public Size Size { get; set; }
			public bool Show { get; set; }

			public TextAndRect FaceStatus { get; set; } = new TextAndRect();
			public TextAndRect FaceQuality { get; set; } = new TextAndRect();
			public AttributeIcon[] FaceProperties { get; set; } = new AttributeIcon[0];

			public TextAndRect Header { get; set; } = new TextAndRect();
			public RectangleF ProbeRect { get; set; }
			public RectangleF GalleryRect { get; set; }
			public TextAndRect DetectionConf { get; set; } = new TextAndRect();
			public RectangleF LicenseThumbRect { get; set; }
			public TextAndRect LicensePlateWatchlistRect { get; set; } = new TextAndRect();
			public TextAndRect LicensePlate { get; set; } = new TextAndRect();
			public TextAndRect LicenseOrigin { get; set; } = new TextAndRect();
			public TextAndRect VehicleMake { get; set; } = new TextAndRect();
			public TextAndRect VehicleModel { get; set; } = new TextAndRect();
			public TextAndRect Tags { get; set; } = new TextAndRect();
			public TypeTextAndIcon[] Types { get; set; } = new TypeTextAndIcon[0];
			public DirectionTextAndIcon[] Directions { get; set; } = new DirectionTextAndIcon[0];
			public TextAndRect AgeGroup { get; set; } = new TextAndRect();

			public ColorTextAndIcon[] Colors { get; set; } = new ColorTextAndIcon[0];

			public AnalyticEventTextAndIcon AnalyticEvent { get; set; }
			public Color? AnalyticEventBorder { get; set; }
			public Point Offset { get; set; }

			#endregion

			#region Public methods

			public IEnumerable<TextAndRect> GetNodes()
			{
				yield return FaceStatus;
				yield return FaceQuality;
				foreach (var n in FaceProperties)
				{
					yield return n;
				}
				yield return Header;
				yield return DetectionConf;
				yield return LicensePlate;
				yield return LicenseOrigin;
				yield return VehicleMake;
				yield return VehicleModel;
				yield return Tags;
				foreach (var n in Types)
				{
					yield return n;
				}
				foreach (var n in Directions)
				{
					yield return n;
				}
				yield return AgeGroup;
				foreach (var n in Colors)
				{
					yield return n;
				}
				yield return AnalyticEvent;
			}

			public TextAndRect ReMeasureTextAndAdvance(int margin, Graphics g, Font font, int width, string newText, TextAndRect current, ref int y)
			{
				if (newText != current.Text)
				{
					var size = g.MeasureString(newText, font);
					var offset = (width - size.Width) / 2;
					var height = Math.Max(size.Height, IconSize);
					var rect = new RectangleF(offset, y, size.Width, height);
					var r = new TextAndRect { Text = newText, TextRect = rect };
					y += (int)Math.Ceiling(height) + margin;
					return r;
				}
				else
				{
					var offset = (width - current.TextRect.Width) / 2;
					var rect = current.TextRect;
					rect.Y = y;
					rect.X = offset;
					var height = Math.Max(rect.Height, IconSize);
					y += (int)Math.Ceiling(height) + margin;
					return new TextAndRect { Text = newText, TextRect = rect };
				}
			}

			public void MeasureTextWithIcon<T>(TextAndIcon<T> target, Graphics g, Font font, string text, int margin)
			{
				SizeF textSize = target.Text != text ? g.MeasureString(text, font) : new SizeF(target.TextRect.Width, target.TextRect.Height);
				textSize.Height = Math.Max(textSize.Height, IconSize);

				var totalSize = textSize.Width + IconSize + margin;
				target.Text = text;
				target.TextRect = new RectangleF(IconSize + margin, 0, textSize.Width, textSize.Height);
				target.IconRect = new RectangleF(0, 0, IconSize, textSize.Height);
			}

			public void PositionLine<T>(ref int y, int width, int margin, params TextAndIcon<T>[] values)
			{
				if (values?.Any() == true)
				{
					var total = values.Select(x => x.IconRect.Width + margin + x.TextRect.Width).Sum() + (values.Length - 1) * margin;
					var offset = (width - total) / 2.0f;
					var maxY = 0.0f;
					foreach (var value in values)
					{
						if (!value.IconRect.IsEmpty)
						{
							value.IconRect.Y = y;
							value.IconRect.X = offset;
							offset += value.IconRect.Width + margin;
						}
						value.TextRect.Y = y;
						value.TextRect.X = offset;
						offset += value.TextRect.Width + margin;

						if (maxY < value.TextRect.Height)
							maxY = value.TextRect.Height;
					}

					foreach (var value in values)
					{
						if (!value.IconRect.IsEmpty)
							value.IconRect.Height = maxY;
						value.TextRect.Height = maxY;
					}

					y += (int)Math.Ceiling(maxY) + margin;
				}
			}

			#endregion

			#region IDisposable

			public void Dispose()
			{
				Info?.Dispose();
			}

			#endregion
		}

		#endregion

		#region Private constants

		private const int IconSize = 16;

		#endregion

		#region Private fields

		private Filter _filter = new Filter();
		private DetailsFilter _detailsFilter = new DetailsFilter();
		private SortedDictionary<long, ObjectNode> _nodes = new SortedDictionary<long, ObjectNode>();
		private SortedDictionary<long, ObjectNode> _shownNodes = new SortedDictionary<long, ObjectNode>();
		private ObjectNode _selectedNode;
		private SubjectInfo _selected;
		private Size _autoScrollMinSize = new Size(0, 0);
		private bool _measure = false;
		private Graphics _graphics = null;
		private Font _boldFont = null;

		private string _toolTipText;
		private Point _toolTipPosition;
		private ObjectNode _mouseOver;
		private Orientation _orientation = Orientation.Vertical;
		private readonly GraphicsPath _carPath = PathUtils.CreateCarPath();
		private readonly GraphicsPath _personPath = PathUtils.CreatePersonPath();
		private readonly GraphicsPath _truckPath = PathUtils.CreateTruckPath();
		private readonly GraphicsPath _bikePath = PathUtils.CreateBikePath();
		private readonly GraphicsPath _busPath = PathUtils.CreateBusPath();
		private readonly GraphicsPath _northPath = PathUtils.CreateNorthPath();
		private readonly GraphicsPath _northEastPath = PathUtils.CreateNorthEastPath();
		private readonly GraphicsPath _eastPath = PathUtils.CreateEastPath();
		private readonly GraphicsPath _southEastPath = PathUtils.CreateSouthEastPath();
		private readonly GraphicsPath _southPath = PathUtils.CreateSouthPath();
		private readonly GraphicsPath _southWestPath = PathUtils.CreateSouthWestPath();
		private readonly GraphicsPath _westPath = PathUtils.CreateWestPath();
		private readonly GraphicsPath _northWestPath = PathUtils.CreateNorthWestPath();
		private readonly GraphicsPath _glassesPath = PathUtils.CreateGlassesPath();
		private readonly GraphicsPath _mustachePath = PathUtils.CreateMustachePath();
		private readonly GraphicsPath _beardPath = PathUtils.CreateBeardPath();
		private readonly GraphicsPath _darkGlassesPath = PathUtils.CreateDarkGlassesPath();
		private readonly GraphicsPath _maskPath = PathUtils.CreateMaskPath();
		private readonly GraphicsPath _malePath = PathUtils.CreateMalePath();
		private readonly GraphicsPath _femalePath = PathUtils.CreateFemalePath();

		#endregion

		#region Public constructor

		public SubjectsView()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		#endregion

		#region Public events

		public event EventHandler<SubjectInfo> SubjectDoubleClick;

		#endregion

		#region Public properties

		public int MaxNodes { get; set; } = 100;

		public int MaxImageHeight { get; set; } = 60;

		public int MaxLicensePlateHeight { get; set; } = 30;
		public int HorizontalSize { get; set; } = 260;

		public SubjectInfo Selected
		{
			get { return _selected; }
			private set { SetProperty(ref _selected, value); }
		}

		public int SubjectsMargin { get; set; } = 5;

		public bool AutoScrollToEnd { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DetailsFilter DetailsFilter
		{
			get => _detailsFilter;
			set
			{
				_detailsFilter = value ?? throw new ArgumentNullException(nameof(value));
				_measure = true;
				Invalidate();
			}
		}

		public Filter Filter
		{
			get { return _filter; }
			set
			{
				if (value != _filter)
				{
					_filter = value;
					_shownNodes.Clear();
					_measure = true;
					if (_filter == null)
					{
						foreach (var n in _nodes)
						{
							_shownNodes.Add(n.Key, n.Value);
						}
					}
					else
					{
						foreach (var n in _nodes.Where(x => ShouldShow(x.Value)))
						{
							_shownNodes.Add(n.Key, n.Value);
						}
					}
					_mouseOver = null;
					_toolTipText = null;
					_toolTipPosition = Point.Empty;
					toolTip.Hide(this);
					Invalidate();
					SelectNode(null);
				}
			}
		}

		public Orientation Orientation
		{
			get { return _orientation; }
			set
			{
				if (SetProperty(ref _orientation, value))
				{
					_orientation = value;
					OnOrientationChanged();
				}
			}
		}

		#endregion

		#region Public methods

		public void AddSubject(SubjectInfo si)
		{
			AddSubjects(new[] { si });
		}

		public void AddSubjects(IEnumerable<SubjectInfo> infos, bool redraw = true)
		{
			var nodes = infos.Select(x => new ObjectNode(x));
			var width = GetTargetSize();
			var g = GetGraphicsObject();

			bool vertical = Orientation == Orientation.Vertical;
			var maxSize = 0;
			var totalSize = 0;
			foreach (var node in nodes)
			{
				_nodes.Add(node.Info.TraceIndex, node);
				if (ShouldShow(node))
				{
					_shownNodes.Add(node.Info.TraceIndex, node);
					var sz = Measure(g, width, node);
					totalSize += MeasureViewSize(vertical, sz, ref maxSize);
				}
			}

			if (vertical)
			{
				_autoScrollMinSize.Height += totalSize;
				_autoScrollMinSize.Width = maxSize;
			}
			else
			{
				_autoScrollMinSize.Height = maxSize;
				_autoScrollMinSize.Width += totalSize;
			}

			AutoScrollMinSize = _autoScrollMinSize;
			if (AutoScrollToEnd)
			{
				AutoScrollPosition = new Point(vertical ? 0 : _autoScrollMinSize.Width, vertical ? _autoScrollMinSize.Height : 0);
			}

			LimitNodeCount(MaxNodes);

			Invalidate();
			if (redraw)
				Update();
		}

		public void UpdateSubjects(IEnumerable<SubjectInfo> infos)
		{
			var size = GetTargetSize();
			var nodes = infos.Select(x => _nodes[x.TraceIndex]);
			var g = GetGraphicsObject();
			var vertical = Orientation == Orientation.Vertical;

			int diff = 0;
			int maxSize = 0;
			foreach (var node in nodes)
			{
				var previousSize = node.Size;
				var sz = Measure(g, size, node);
				var wasShown = node.Show;
				if (ShouldShow(node))
				{
					if (vertical)
					{
						diff += wasShown ? sz.Height - previousSize.Height : sz.Height + SubjectsMargin;
						maxSize = Math.Max(maxSize, sz.Width);
					}
					else
					{
						diff += wasShown ? sz.Width - previousSize.Width : sz.Width + SubjectsMargin;
						maxSize = Math.Max(maxSize, sz.Height);
					}

					if (!wasShown)
					{
						_shownNodes.Add(node.Info.TraceIndex, node);
					}
				}
				else if (wasShown)
				{
					_shownNodes.Remove(node.Info.TraceIndex);
					if (vertical)
					{
						diff -= node.Size.Height + SubjectsMargin;
					}
					else
					{
						diff -= node.Size.Width + SubjectsMargin;
					}

					if (_selectedNode == node)
					{
						SelectNode(null, false);
					}
				}
			}

			if (vertical)
			{
				_autoScrollMinSize.Width = maxSize;
				_autoScrollMinSize.Height += diff;
			}
			else
			{
				_autoScrollMinSize.Width += diff;
				_autoScrollMinSize.Height = maxSize;
			}
			AutoScrollMinSize = _autoScrollMinSize;

			if (AutoScrollToEnd && diff > 0)
			{
				AutoScrollPosition = new Point(vertical ? 0 : _autoScrollMinSize.Width, vertical ? _autoScrollMinSize.Height : 0);
			}

			Invalidate();
			if (diff > 0)
			{
				Update();
			}
		}

		public void DeleteSubjects(IEnumerable<SubjectInfo> infos)
		{
			var nodes = infos.Select(info => _nodes[info.TraceIndex]).ToArray();
			if (nodes.Any())
			{
				RemoveNodes(nodes);
			}
		}

		public void UpdateSubject(SubjectInfo si)
		{
			UpdateSubjects(new[] { si });
		}

		public SubjectInfo GetSubject(int traceIndex)
		{
			return _nodes.TryGetValue(traceIndex, out var value) ? value.Info : null;
		}

		public IEnumerable<SubjectInfo> GetSubjects()
		{
			return _nodes.Values.Select(x => x.Info);
		}

		public void Clear()
		{
			SelectNode(null);
			LimitNodeCount(0);
		}

		public void ClearAll()
		{
			SelectNode(null);
			LimitNodeCount(0);
		}

		public bool TrySelectNext(out SubjectInfo next)
		{
			next = null;
			if (_selectedNode != null)
			{
				var node = GetPreviousNode(_selectedNode.Info.TraceIndex, _shownNodes.Values.Reverse());
				if (node != null)
				{
					SelectNode(node, true);
					next = node.Info;
				}

			}
			return next != null;
		}

		public bool TrySelectPrevious(out SubjectInfo previous)
		{
			previous = null;
			if (_selectedNode != null)
			{
				var node = GetPreviousNode(_selectedNode.Info.TraceIndex, _shownNodes.Values);
				if (node != null)
				{
					SelectNode(node, true);
					previous = node.Info;
				}

			}
			return previous != null;
		}

		#endregion

		#region Protected methods

		protected override void OnPaint(PaintEventArgs e)
		{
			var g = e.Graphics;
			bool vertical = Orientation == Orientation.Vertical;

			ReMeasureIfNeeded(g);
			if (vertical)
				e.Graphics.TranslateTransform(0, -VerticalScroll.Value);
			else
				e.Graphics.TranslateTransform(-HorizontalScroll.Value, 0);
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.SmoothingMode = SmoothingMode.AntiAlias;

			var y = SubjectsMargin;
			var x = SubjectsMargin;
			foreach (var node in _shownNodes.Values)
			{
				node.Offset = new Point(x, y);
				PaintNode(g, x, y, node);
				if (vertical)
					y += node.Size.Height + SubjectsMargin;
				else
					x += node.Size.Width + SubjectsMargin;
			}

			base.OnPaint(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);

			Invalidate();
			Update();
		}

		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);
			Invalidate();
			Update();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			_measure = true;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			Focus();

			SelectNode(FindNode(e));
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			var node = FindNode(e);
			if (node != null)
			{
				var hit = new Point(e.X + HorizontalScroll.Value - node.Offset.X, e.Y + VerticalScroll.Value - node.Offset.Y);
				var pos = e.Location + new Size(10, 10);
				var text = string.Empty;
				foreach (var n in node.GetNodes())
				{
					if (n.TestHit(hit))
					{
						text = n.Hint;
						break;
					}
				}

				if (text == string.Empty)
				{
					_toolTipText = null;
					_toolTipPosition = Point.Empty;
					toolTip.Hide(this);
				}
				else if (text != _toolTipText || _toolTipPosition != pos)
				{
					toolTip.Show(text, this, pos);
					_toolTipText = text;
					_toolTipPosition = pos;
				}
			}
			else if (!string.IsNullOrEmpty(_toolTipText))
			{
				_toolTipText = null;
				_toolTipPosition = Point.Empty;
				toolTip.Hide(this);
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);

			Focus();

			var node = FindNode(e);
			if (node != null)
			{
				SubjectDoubleClick?.Invoke(this, node.Info);
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (_selectedNode != null)
			{
				if ((keyData & Keys.Enter) == Keys.Enter)
				{
					if (Selected != null)
					{
						SubjectDoubleClick?.Invoke(this, Selected);
					}
					return true;
				}

				var keyValue = (int)keyData & 0xFFFF;
				bool vertical = Orientation == Orientation.Vertical;
				if ((vertical && keyValue == (int)Keys.Up) || (!vertical && keyValue == (int)Keys.Left))
				{
					var prevNode = GetPreviousNode(_selectedNode.Info.TraceIndex, _shownNodes.Values);
					if (prevNode != null)
					{
						var node = SelectNode(prevNode);
						if (vertical)
						{
							var top = VerticalScroll.Value;
							if (node.Offset.Y < top)
							{
								SetDisplayRectLocation(0, -node.Offset.Y + ClientRectangle.Top);
								AdjustFormScrollbars(true);
							}
						}
						else
						{
							var left = HorizontalScroll.Value;
							if (node.Offset.X < left)
							{
								SetDisplayRectLocation(-node.Offset.X + ClientRectangle.Left, 0);
								AdjustFormScrollbars(true);
							}
						}
					}
					return true;
				}
				if ((vertical && keyValue == (int)Keys.Down) || (!vertical && keyValue == (int)Keys.Right))
				{
					var nextNode = GetPreviousNode(_selectedNode.Info.TraceIndex, _shownNodes.Values.Reverse());
					if (nextNode != null)
					{
						var node = SelectNode(nextNode);
						if (vertical)
						{
							var bottom = VerticalScroll.Value + ClientSize.Height;
							if (node.Offset.Y + node.Size.Height > bottom)
							{
								SetDisplayRectLocation(0, -(node.Offset.Y + node.Size.Height) + ClientRectangle.Bottom);
								AdjustFormScrollbars(true);
							}
						}
						else
						{
							var right = HorizontalScroll.Value + ClientSize.Width;
							if (node.Offset.X + node.Size.Width > right)
							{
								SetDisplayRectLocation(-(node.Offset.X + node.Size.Width) + ClientRectangle.Right, 0);
								AdjustFormScrollbars(true);
							}
						}
					}
					return true;
				}
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion

		#region Private methods

		private int MeasureViewSize(bool vertical, Size sz, ref int maxSize)
		{
			if (vertical && sz.Width > maxSize)
				maxSize = sz.Width;
			else if (!vertical && sz.Height > maxSize)
				maxSize = sz.Height;
			return (vertical ? sz.Height : sz.Width) + SubjectsMargin;
		}

		private ObjectNode GetPreviousNode(long currentTraceIndex, IEnumerable<ObjectNode> nodes)
		{
			ObjectNode prev = null;
			foreach (var n in nodes)
			{
				if (n.Info.TraceIndex == currentTraceIndex)
				{
					return prev;
				}
				prev = n;
			}
			return null;
		}

		private void OnOrientationChanged()
		{
			HorizontalScroll.Visible = _orientation == Orientation.Vertical;
			VerticalScroll.Visible = _orientation == Orientation.Vertical;
			if (IsHandleCreated)
			{
				Update();
			}
		}

		private bool ShouldShow(ObjectNode node)
		{
			var info = node.Info;

			if (Filter.MustHaveFace && info.Face.IsEmpty)
			{
				node.Show = false;
				return false;
			}
			if (Filter.MustHaveLicensePlate && info.LicensePlate.IsEmpty)
			{
				node.Show = false;
				return false;
			}
			if (Filter.WatchlistFilter != null)
			{
				bool isInWatchlist = info.LicensePlate.Watchlist != null
					|| info.Face.SubjectId != null;
				node.Show = isInWatchlist == Filter.WatchlistFilter;
				if (node.Show == false)
					return false;
			}

			if (Filter.WithTriggersOnly)
			{
				bool IsExpectedName(NAnalyticEvent e) => e.GetTriggerName() == Filter.TriggerName;
				node.Show = string.IsNullOrWhiteSpace(Filter.TriggerName) ? info.HasEvents : info.Events.Any(IsExpectedName);
				if (node.Show == false)
					return false;

				if (Filter.AnalyticEventType != NAnalyticEventType.All)
				{
					node.Show = info.Events.Any(e => Filter.AnalyticEventType.HasFlag(e.EventType));
					if (node.Show == false)
						return false;
				}
			}

			if (Filter.Color > NSurveillanceObjectColor.None)
			{
				var flags = GetColorFlags(info.Object.ColorDetails);
				bool any = flags.Any(f => Filter.Color.HasFlag(f.value) && f.conf >= Filter.ColorConfidence);
				node.Show = any;
				if (!any)
					return false;
			}

			if (Filter.Type > NSurveillanceObjectType.None)
			{
				var flags = GetTypeFlags(info.Object.TypeDetails);
				bool any = flags.Any(f => Filter.Type.HasFlag(f.value) && f.conf >= Filter.TypeConfidence);
				node.Show = any;
				if (!any)
					return false;
			}

			if (Filter.Direction > NSurveillanceObjectDirection.None)
			{
				var flags = GetDirectionFlags(info.Object.DirectionDetails);
				bool any = flags.Any(f => Filter.Direction.HasFlag(f.value) && f.conf >= Filter.DirectionConfidence);
				node.Show = any;
				if (!any)
					return false;
			}

			node.Show = true;
			return node.Show;
		}

		private Graphics GetGraphicsObject()
		{
			if (_graphics != null)
				return _graphics;
			else
			{
				_graphics = Graphics.FromHwnd(Handle);
				return _graphics;
			}
		}

		private Font GetBoldFont()
		{
			if (_boldFont != null)
			{
				return _boldFont;
			}
			else
			{
				_boldFont = new Font(Font, FontStyle.Bold);
				return _boldFont;
			}
		}

		private bool HitTestNode(ObjectNode node, Point position)
		{
			return node.Show && (new Rectangle(node.Offset, node.Size)).Contains(position);
		}

		private ObjectNode FindNode(MouseEventArgs e)
		{
			var pos = new Point(e.X + HorizontalScroll.Value, e.Y + VerticalScroll.Value);
			if (_mouseOver == null || !HitTestNode(_mouseOver, pos))
			{
				_mouseOver = _shownNodes.FirstOrDefault(x => HitTestNode(x.Value, pos)).Value;
			}
			return _mouseOver;
		}

		private string GetConfidenceString(int confidence, int threshold = 0)
		{
			return confidence > threshold ? $"Yes, Confidence: {confidence}" : $"No, Confidence: {confidence}";
		}

		private ObjectNode SelectNode(ObjectNode node, bool update = true)
		{
			if (node != _selectedNode)
			{
				if (_selectedNode != null)
					_selectedNode.IsSelected = false;
				_selectedNode = node;
				if (node != null)
					node.IsSelected = true;

				Selected = node?.Info;

				Invalidate();
				if (update)
				{
					Update();
				}

				return node;
			}
			return _selectedNode;
		}

		private void RemoveNodes(ObjectNode[] query)
		{
			bool vertical = Orientation == Orientation.Vertical;
			int position;
			if (vertical)
				position = VerticalScroll.Value;
			else
				position = HorizontalScroll.Value;
			var totalSize = 0;

			foreach (var node in query)
			{
				_nodes.Remove(node.Info.TraceIndex);
				if (node.Show)
				{
					if (vertical)
						totalSize += node.Size.Height + SubjectsMargin;
					else
						totalSize += node.Size.Width + SubjectsMargin;
					_shownNodes.Remove(node.Info.TraceIndex);
				}

				if (vertical && node.Offset.Y < position)
				{
					position -= node.Size.Height + SubjectsMargin;
				}
				else if (!vertical && node.Offset.X < position)
				{
					position -= node.Size.Width + SubjectsMargin;
				}

				if (node == _mouseOver)
				{
					_mouseOver = null;
				}

				node.Dispose();
			}

			if (vertical)
				_autoScrollMinSize.Height -= totalSize;
			else
				_autoScrollMinSize.Width -= totalSize;
			AutoScrollMinSize = _autoScrollMinSize;
			if ((vertical && position != VerticalScroll.Value) || (!vertical && position != HorizontalScroll.Value))
			{
				AutoScrollPosition = new Point(vertical ? 0 : position, vertical ? position : 0);
			}

			Invalidate();
		}

		private void LimitNodeCount(int limit)
		{
			var remove = _nodes.Count - limit;
			if (remove > 0)
			{
				var query = _nodes.Values
					.Where(x => !x.IsSelected && x.Info.IsDisappeared)
					.OrderBy(x => x.Show)
					.ThenBy(x => x.Info.TraceIndex)
					.Take(remove)
					.ToArray();

				if (query.Any())
				{
					RemoveNodes(query);
				}
			}
		}

		private void ReMeasureIfNeeded(Graphics g)
		{
			if (_measure)
			{
				bool vertical = Orientation == Orientation.Vertical;
				var size = GetTargetSize();
				var total = 0;
				foreach (var node in _shownNodes.Values)
				{
					var sz = Measure(g, size, node);
					if (vertical)
						total += sz.Height + SubjectsMargin;
					else
						total += sz.Width + SubjectsMargin;
				}
				_autoScrollMinSize = vertical ? new Size(size, total) : new Size(total, size);
				AutoScrollMinSize = _autoScrollMinSize;
				_measure = false;
			}
		}

		private int GetTargetSize()
		{
			if (Orientation == Orientation.Vertical)
			{
				return ClientSize.Width - SystemInformation.VerticalScrollBarWidth - SubjectsMargin;
			}
			else
			{
				return ClientSize.Height - SystemInformation.HorizontalScrollBarHeight - SubjectsMargin;
			}
		}

		private IEnumerable<(NSurveillanceObjectType value, float conf)> GetTypeFlags(NSurveillanceObjectTypeDetails details)
		{
			yield return (NSurveillanceObjectType.Car, details.CarConfidence);
			yield return (NSurveillanceObjectType.Person, details.PersonConfidence);
			yield return (NSurveillanceObjectType.Truck, details.TruckConfidence);
			yield return (NSurveillanceObjectType.Bus, details.BusConfidence);
			yield return (NSurveillanceObjectType.Bike, details.BikeConfidence);
		}

		private IEnumerable<(NSurveillanceObjectColor value, float conf)> GetColorFlags(NSurveillanceObjectColorDetails details)
		{
			yield return (NSurveillanceObjectColor.Red, details.RedColorConfidence);
			yield return (NSurveillanceObjectColor.Orange, details.OrangeColorConfidence);
			yield return (NSurveillanceObjectColor.Yellow, details.YellowColorConfidence);
			yield return (NSurveillanceObjectColor.Green, details.GreenColorConfidence);
			yield return (NSurveillanceObjectColor.Blue, details.BlueColorConfidence);
			yield return (NSurveillanceObjectColor.Silver, details.SilverColorConfidence);
			yield return (NSurveillanceObjectColor.White, details.WhiteColorConfidence);
			yield return (NSurveillanceObjectColor.Black, details.BlackColorConfidence);
			yield return (NSurveillanceObjectColor.Brown, details.BrownColorConfidence);
			yield return (NSurveillanceObjectColor.Gray, details.GrayColorConfidence);
		}

		private IEnumerable<(NSurveillanceObjectDirection value, float conf)> GetDirectionFlags(NSurveillanceObjectDirectionDetails details)
		{
			yield return (NSurveillanceObjectDirection.North, details.NorthConfidence);
			yield return (NSurveillanceObjectDirection.NorthEast, details.NorthEastConfidence);
			yield return (NSurveillanceObjectDirection.East, details.EastConfidence);
			yield return (NSurveillanceObjectDirection.SouthEast, details.SouthEastConfidence);
			yield return (NSurveillanceObjectDirection.South, details.SouthConfidence);
			yield return (NSurveillanceObjectDirection.SouthWest, details.SouthWestConfidence);
			yield return (NSurveillanceObjectDirection.West, details.WestConfidence);
			yield return (NSurveillanceObjectDirection.NorthWest, details.NorthWestConfidence);
		}

		private Size Measure(Graphics g, int targetSize, ObjectNode node)
		{
			var boldFont = GetBoldFont();

			SubjectInfo si = node.Info;
			bool hasFace = !si.Face.IsEmpty;
			bool hasObjects = !si.Object.IsEmpty;
			int y = SubjectsMargin;
			bool vertical = Orientation == Orientation.Vertical;
			int targetWidth = vertical ? targetSize : HorizontalSize;
			bool showGallery = si.Face.GalleryThumbnail != null;
			int imageWidth = showGallery ? (targetWidth - SubjectsMargin) / 2 : targetWidth;

			var time = !si.IsFromVideoFile ? $"{si.TimeStamp.ToLocalTime():HH\\:mm\\:ss}" : si.VideoTimeSpan.ToString("hh\\:mm\\:ss");
			var text = $"{time}   Subject {si.TraceIndex},   " + (si.IsDisappeared ? "Disappeared " : "Tracking");
			node.Header = node.ReMeasureTextAndAdvance(SubjectsMargin, g, boldFont, targetWidth, text, node.Header, ref y);

			var probeHeight = si.Thumbnail.Height;
			var probeWidth = si.Thumbnail.Width;
			var galleryWidth = si.Face.GalleryThumbnail?.Width ?? 0;
			var galleryHeight = si.Face.GalleryThumbnail?.Height ?? 0;

			var probeScale = GetScale(imageWidth, probeWidth, MaxImageHeight, probeHeight);
			var galleryScale = showGallery ? GetScale(imageWidth, galleryWidth, MaxImageHeight, galleryHeight) : probeScale;

			var probeRect = new RectangleF(0, y, probeScale * probeWidth, probeScale * probeHeight);
			probeRect.X += (imageWidth - probeRect.Width) / 2;
			var galleryRect = showGallery ? new RectangleF(imageWidth + SubjectsMargin, y, galleryScale * galleryWidth, galleryScale * galleryHeight) : RectangleF.Empty;
			galleryRect.X += (imageWidth - galleryRect.Width) / 2;

			var maxImageHeight = Math.Max(probeRect.Height, galleryRect.Height);
			probeRect.Y += (maxImageHeight - probeRect.Height) / 2;
			if (showGallery)
				galleryRect.Y += (maxImageHeight - galleryRect.Height) / 2;

			node.ProbeRect = probeRect;
			node.GalleryRect = galleryRect;

			y += (int)Math.Ceiling(maxImageHeight) + SubjectsMargin;

			if (hasFace)
			{
				text = si.Face.StatusText;
				node.FaceStatus = node.ReMeasureTextAndAdvance(SubjectsMargin, g, boldFont, targetWidth, text, node.FaceStatus, ref y);

				var attributes = si.Face.BestAttributes;
				if (DetailsFilter.ShowFaceQuality)
				{
					text = "Face Quality: " + attributes.Quality;
					node.FaceQuality = node.ReMeasureTextAndAdvance(SubjectsMargin, g, boldFont, targetWidth, text, node.FaceQuality, ref y);
				}
				IEnumerable<ObjectNode.AttributeIcon> GetAttribtues()
				{
					yield return new ObjectNode.AttributeIcon
					{
						Value = attributes.Gender,
						Conf = attributes.GetAttributeValue(attributes.Gender == NGender.Male ? NBiometricAttributeId.GenderMale : NBiometricAttributeId.GenderFemale),
						Set = true
					};

					bool TestConfidence(byte value)
					{
						return 50 <= value && value <= 100;
					}

					var attributeIds = new[] { NBiometricAttributeId.Glasses, NBiometricAttributeId.DarkGlasses, NBiometricAttributeId.Beard, NBiometricAttributeId.Mustache, NBiometricAttributeId.FaceMask };
					foreach (var id in attributeIds)
					{
						var conf = attributes.GetAttributeValue(id);
						yield return new ObjectNode.AttributeIcon { Value = id, Conf = conf, Set = TestConfidence(conf) };
					}
				}
				if (DetailsFilter.ShowFaceAttributes)
				{
					node.FaceProperties = GetAttribtues().ToArray();
					foreach (var prop in node.FaceProperties)
					{
						node.MeasureTextWithIcon(prop, g, Font, string.Empty, SubjectsMargin);
						if (prop.Value is NGender gender)
						{
							prop.Hint = $"Gender: {gender}, Confidence: {prop.Conf}";
						}
						else if (prop.Value is NBiometricAttributeId fp)
						{
							switch (fp)
							{
								case NBiometricAttributeId.Glasses:
									text = $"Glasses: {GetConfidenceString((int)prop.Conf)}";
									break;
								case NBiometricAttributeId.DarkGlasses:
									text = $"Dark Glasses: {GetConfidenceString((int)prop.Conf)}";
									break;
								case NBiometricAttributeId.Beard:
									text = $"Beard: {GetConfidenceString((int)prop.Conf)}";
									break;
								case NBiometricAttributeId.Mustache:
									text = $"Mustache: {GetConfidenceString((int)prop.Conf)}";
									break;
								case NBiometricAttributeId.FaceMask:
									text = $"Mask: {GetConfidenceString((int)prop.Conf)}";
									break;
								default:
									break;
							}
							prop.Hint = text;
						}
					}
					node.PositionLine(ref y, targetWidth, SubjectsMargin, node.FaceProperties);
				}
				else
				{
					node.FaceProperties = new ObjectNode.AttributeIcon[0];
				}
			}
			else if (hasObjects)
			{
				text = $"Detection Confidence: {si.Object.DetectionConfidence * 100:0.00}";
				node.DetectionConf = node.ReMeasureTextAndAdvance(SubjectsMargin, g, boldFont, targetWidth, text, node.DetectionConf, ref y);
				node.DetectionConf.Hint = $"Detection Confidence: {si.Object.DetectionConfidence * 100:0.00}";

				if (DetailsFilter.ShowObjectType)
				{
					var typeFlags = GetTypeFlags(si.Object.TypeDetails)
						.Where(x => x.conf > .5f || (Filter.Type.HasFlag(x.value) && x.conf >= Filter.TypeConfidence));
					node.Types = typeFlags.Select(x => new ObjectNode.TypeTextAndIcon { Value = x.value, Conf = x.conf }).ToArray();
					foreach (var type in node.Types)
					{
						node.MeasureTextWithIcon(type, g, Font, $"{type.Value} ({type.Conf * 100:0.00})", SubjectsMargin);
						type.Hint = $"Type: {type.Value}, Confidence {type.Conf * 100:0.00}";
					}
					node.PositionLine(ref y, targetWidth, SubjectsMargin, node.Types);
				}

				if (DetailsFilter.ShowAgeGroups && si.Object.AgeGroupDetails != null)
				{
					var ageGroup = si.Object.AgeGroupDetails;
					text = $"Age: {ageGroup.Group} ({ageGroup.GroupConfidence * 100:0.00})";
					node.AgeGroup = node.ReMeasureTextAndAdvance(SubjectsMargin, g, Font, targetWidth, text, node.AgeGroup, ref y);
				}

				if (DetailsFilter.ShowObjectDirection)
				{
					var directionFlags = GetDirectionFlags(si.Object.DirectionDetails)
						.Where(x => x.conf > .3f || (Filter.Direction.HasFlag(x.value) && x.conf >= Filter.DirectionConfidence));
					node.Directions = directionFlags.Select(x => new ObjectNode.DirectionTextAndIcon { Value = x.value, Conf = x.conf }).ToArray();
					if (node.Directions.Any())
					{
						foreach (var d in node.Directions)
						{
							node.MeasureTextWithIcon(d, g, Font, $"{d.Value} ({d.Conf * 100:0.00})", SubjectsMargin);
							d.Hint = $"Direction: {d.Value}, confidence {d.Conf * 100:0.00}";
						}
					}
					else
					{
						node.Directions = new[] { new ObjectNode.DirectionTextAndIcon { Value = NSurveillanceObjectDirection.None } };
						node.MeasureTextWithIcon(node.Directions[0], g, Font, "Direction: Unknown", SubjectsMargin);
						node.Directions[0].IconRect = RectangleF.Empty;
						node.Directions[0].Hint = "Direction: Unknown";
					}
					node.PositionLine(ref y, targetWidth, SubjectsMargin, node.Directions);
				}

				if (DetailsFilter.ShowObjectColor)
				{
					var colorFlags = GetColorFlags(si.Object.ColorDetails)
						.Where(x => x.conf >= .5f || (Filter.Color.HasFlag(x.value) && x.conf >= Filter.ColorConfidence));
					node.Colors = colorFlags.Select(x => new ObjectNode.ColorTextAndIcon { Value = x.value, Conf = x.conf }).ToArray();
					if (node.Colors.Any())
					{
						foreach (var c in node.Colors)
						{
							node.MeasureTextWithIcon(c, g, Font, $"{c.Value} ({c.Conf * 100:0.00})", SubjectsMargin);
							c.Hint = $"Color: {c.Value}, confidence {c.Conf * 100:0.00}";
						}
					}
					else
					{
						node.Colors = new[] { new ObjectNode.ColorTextAndIcon { Value = NSurveillanceObjectColor.None } };
						node.MeasureTextWithIcon(node.Colors[0], g, Font, "Color: Unknown", SubjectsMargin);
						node.Colors[0].IconRect = RectangleF.Empty;
						node.Colors[0].Hint = "Color: Unknown";
					}
					node.PositionLine(ref y, targetWidth, SubjectsMargin, node.Colors);
				}

				if (DetailsFilter.ShowVehicleModel && si.Object.VehicleDetails != null && si.Object.VehicleDetails.Models?.Count > 0)
				{
					var model = si.Object.VehicleDetails.Models[0];
					var makeModel = model.MakeModels.First();
					text = $"Make: {makeModel.Key} ({model.Confidence * 100:0.00})";
					node.VehicleMake = node.ReMeasureTextAndAdvance(SubjectsMargin, g, Font, targetWidth, text, node.VehicleMake, ref y);
					text = $"Model: {makeModel.Value}";
					node.VehicleModel = node.ReMeasureTextAndAdvance(SubjectsMargin, g, Font, targetWidth, text, node.VehicleModel, ref y);
				}

				if (DetailsFilter.ShowTags && si.Object.VehicleDetails?.Tags?.Count > 0)
				{
					var tag = si.Object.VehicleDetails.Tags[0];
					node.Tags = node.ReMeasureTextAndAdvance(SubjectsMargin, g, Font, targetWidth, $"Tags: {tag.Name} ({tag.Confidence * 100:0.00})", node.Tags, ref y);
				}
			}

			if (!si.LicensePlate.IsEmpty)
			{
				if (hasObjects)
				{
					var lprScale = GetScale(targetWidth, si.LicensePlate.Thumbnail.Width, MaxLicensePlateHeight, si.LicensePlate.Thumbnail.Height);
					var lprRect = new RectangleF(0, y, lprScale * si.LicensePlate.Thumbnail.Width, lprScale * si.LicensePlate.Thumbnail.Height);
					lprRect.X += (targetWidth - lprRect.Width) / 2;
					node.LicenseThumbRect = lprRect;
					y += (int)node.LicenseThumbRect.Height + SubjectsMargin;
				}

				if (si.LicensePlate.Watchlist != null)
				{
					node.LicensePlateWatchlistRect = node.ReMeasureTextAndAdvance(SubjectsMargin, g, boldFont, targetWidth, $"In Watchlist: {si.LicensePlate.Watchlist.Owner}", node.LicensePlateWatchlistRect, ref y);
				}
				else
				{
					node.LicensePlateWatchlistRect = new ObjectNode.TextAndRect();
				}

				var lpr = si.LicensePlate.Best;
				var lpValue = DetailsFilter.ShowLPFormattedValue ? lpr.FormattedValue : lpr.Value;
				node.LicensePlate = node.ReMeasureTextAndAdvance(SubjectsMargin, g, Font, targetWidth, $"License plate: {lpValue}", node.LicensePlate, ref y);
				node.LicensePlate.Hint = $"License plate: {lpValue}, OCR confidence: {lpr.OcrConfidence * 100:0.00}";
				if (DetailsFilter.ShowLPOrigin)
				{
					node.LicenseOrigin = node.ReMeasureTextAndAdvance(SubjectsMargin, g, Font, targetWidth, $"Origin: {lpr.Origin}", node.LicenseOrigin, ref y);
					var ocrOriginHint = lpr.OcrOriginConfidence > 0 ? $", confidence {lpr.OcrOriginConfidence * 100:0.00}" : string.Empty;
					node.LicenseOrigin.Hint = $"Origin: {lpr.Origin}{ocrOriginHint}\nOCR confidence: {lpr.OcrConfidence * 100:0.00}";
				}
			}
			else
			{
				node.LicensePlate = new ObjectNode.TextAndRect();
				node.LicenseThumbRect = RectangleF.Empty;
				node.LicensePlateWatchlistRect = new ObjectNode.TextAndRect();
				node.LicenseOrigin = new ObjectNode.TextAndRect();
			}

			if ((DetailsFilter.ShowAnalyticEvent || DetailsFilter.ShowAnalyticEventBorder) && si.HasEvents)
			{
				var eventToShow = si.Events
					.OrderByDescending(x => x.EventType == NAnalyticEventType.Timer)
					.ThenByDescending(x => x.EventType == NAnalyticEventType.CrossedIn || x.EventType == NAnalyticEventType.CrossedOut)
					.ThenBy(x => x.TimeStamp)
					.First();

				if (node.AnalyticEvent?.Value != eventToShow.UniqueId)
				{
					// TODO: What should happen on merge/split?
					node.AnalyticEventBorder = eventToShow.GetTriggerColor();
				}
				if (DetailsFilter.ShowAnalyticEvent)
				{
					node.AnalyticEvent = new ObjectNode.AnalyticEventTextAndIcon(eventToShow.UniqueId) { IsTripwire = eventToShow.IsTriggerTripwire() };
					node.AnalyticEvent.Hint = eventToShow.GetEventDescriptionWithTime(si.IsFromVideoFile);
					node.MeasureTextWithIcon(node.AnalyticEvent, g, Font, eventToShow.GetEventDescription(), SubjectsMargin);
					node.PositionLine(ref y, targetWidth, SubjectsMargin, node.AnalyticEvent);
				}
				else
				{
					node.AnalyticEvent = new ObjectNode.AnalyticEventTextAndIcon(-1);
				}
			}
			else
			{
				node.AnalyticEvent = new ObjectNode.AnalyticEventTextAndIcon(-1);
				node.AnalyticEventBorder = null;
			}

			node.Size = new Size(targetWidth, y);
			return node.Size;
		}

		private GraphicsPath GetPropertyPath(NBiometricAttributeId value)
		{
			switch (value)
			{
				case NBiometricAttributeId.Glasses: return _glassesPath;
				case NBiometricAttributeId.Mustache: return _mustachePath;
				case NBiometricAttributeId.Beard: return _beardPath;
				case NBiometricAttributeId.DarkGlasses: return _darkGlassesPath;
				case NBiometricAttributeId.FaceMask: return _maskPath;
				default:
					throw new NotImplementedException();
			}
		}

		private GraphicsPath GetTypePath(NSurveillanceObjectType type)
		{
			switch (type)
			{
				case NSurveillanceObjectType.Car: return _carPath;
				case NSurveillanceObjectType.Person: return _personPath;
				case NSurveillanceObjectType.Bus: return _busPath;
				case NSurveillanceObjectType.Truck: return _truckPath;
				case NSurveillanceObjectType.Bike: return _bikePath;
				default:
					throw new NotImplementedException();
			}
		}

		private GraphicsPath GetDirectionPath(NSurveillanceObjectDirection direction)
		{
			switch (direction)
			{
				case NSurveillanceObjectDirection.North: return _northPath;
				case NSurveillanceObjectDirection.NorthEast: return _northEastPath;
				case NSurveillanceObjectDirection.East: return _eastPath;
				case NSurveillanceObjectDirection.SouthEast: return _southEastPath;
				case NSurveillanceObjectDirection.South: return _southPath;
				case NSurveillanceObjectDirection.SouthWest: return _southWestPath;
				case NSurveillanceObjectDirection.West: return _westPath;
				case NSurveillanceObjectDirection.NorthWest: return _northWestPath;
				default:
					throw new NotImplementedException();
			}
		}

		private RectangleF OffsetRect(RectangleF r, int x, int y)
		{
			return new RectangleF(r.X + x, r.Y + y, r.Width, r.Height);
		}

		private void PaintAttributePath(Graphics g, GraphicsPath gp, RectangleF rect, bool isSelected, bool isSet)
		{
			if (isSet)
			{
				PaintPath(g, gp, rect, isSelected ? Brushes.White : Brushes.Black, null);
			}
			else
			{
				PaintPath(g, gp, rect, isSelected ? Brushes.DarkGray : Brushes.LightGray, null);
			}
		}

		private void PaintPath(Graphics g, GraphicsPath gp, RectangleF rect, Brush fill, Pen border = null)
		{
			var path = (GraphicsPath)gp.Clone();

			var bounds = path.GetBounds();
			var m = new Matrix();
			var scaleX = rect.Width / bounds.Width;
			var scaleY = rect.Height / bounds.Height;
			var scale = Math.Min(scaleX, scaleY);
			var dx = (rect.Width - scale * bounds.Width) / 2f;
			var dy = (rect.Height - scale * bounds.Height) / 2f;
			m.Translate(rect.X + dx, rect.Y + dy);
			m.Scale(scale, scale);
			path.Transform(m);

			g.FillPath(fill, path);
			if (border != null)
				g.DrawPath(border, path);
		}

		private void PaintNode(Graphics g, int x, int y, ObjectNode node)
		{
			if (!IsNodeVisible(node))
			{
				return;
			}

			var boldFont = GetBoldFont();

			bool isSelected = node.IsSelected;
			if (isSelected)
			{
				g.FillRectangle(SystemBrushes.HotTrack, x, y, node.Size.Width, node.Size.Height);
			}

			var si = node.Info;
			var brush = isSelected ? Brushes.White : Brushes.Black;

			var format = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
			var leftFormat = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near };
			g.DrawString(node.Header.Text, boldFont, brush, OffsetRect(node.Header.TextRect, x, y), leftFormat);

			if (!node.ProbeRect.IsEmpty)
			{
				g.DrawImage(si.Thumbnail, OffsetRect(node.ProbeRect, x, y));
			}

			if (!node.GalleryRect.IsEmpty)
			{
				g.DrawImage(si.Face.GalleryThumbnail, OffsetRect(node.GalleryRect, x, y));
			}
			if (!si.Face.IsEmpty)
			{
				if (!node.FaceStatus.TextRect.IsEmpty)
				{
					g.DrawString(node.FaceStatus.Text, Font, brush, OffsetRect(node.FaceStatus.TextRect, x, y), format);
				}

				if (DetailsFilter.ShowFaceQuality)
				{
					if (!node.FaceQuality.TextRect.IsEmpty)
					{
						g.DrawString(node.FaceQuality.Text, Font, brush, OffsetRect(node.FaceQuality.TextRect, x, y), format);
					}
				}

				if (DetailsFilter.ShowFaceAttributes)
				{
					foreach (var prop in node.FaceProperties)
					{
						if (prop.Value is NBiometricAttributeId attribute)
							PaintAttributePath(g, GetPropertyPath(attribute), OffsetRect(prop.IconRect, x, y), isSelected, prop.Set);
						else if (prop.Value is NGender gender)
							PaintAttributePath(g, gender == NGender.Male ? _malePath : _femalePath, OffsetRect(prop.IconRect, x, y), isSelected, true);
					}
				}
			}
			else
			{

				if (!node.DetectionConf.TextRect.IsEmpty)
				{
					g.DrawString(node.DetectionConf.Text, Font, brush, OffsetRect(node.DetectionConf.TextRect, x, y), format);
				}

				if (DetailsFilter.ShowObjectType)
				{
					foreach (var type in node.Types)
					{
						g.DrawString(type.Text, Font, brush, OffsetRect(type.TextRect, x, y), leftFormat);
						PaintPath(g, GetTypePath(type.Value), OffsetRect(type.IconRect, x, y), brush);
					}
				}

				if (DetailsFilter.ShowAgeGroups && !node.AgeGroup.TextRect.IsEmpty)
				{
					g.DrawString(node.AgeGroup.Text, Font, brush, OffsetRect(node.AgeGroup.TextRect, x, y), format);
				}

				if (DetailsFilter.ShowObjectColor)
				{
					foreach (var c in node.Colors)
					{
						using (var b = new SolidBrush(c.GetColorValue()))
						{
							g.FillEllipse(b, OffsetRect(c.IconRect, x, y));
							g.DrawEllipse(isSelected ? Pens.White : Pens.Black, OffsetRect(c.IconRect, x, y));
							g.DrawString(c.Text, Font, brush, OffsetRect(c.TextRect, x, y), format);
						}
					}
				}

				if (DetailsFilter.ShowObjectDirection)
				{
					foreach (var direction in node.Directions)
					{
						if (!direction.IconRect.IsEmpty)
						{
							PaintPath(g, GetDirectionPath(direction.Value), OffsetRect(direction.IconRect, x, y), brush);
						}
						g.DrawString(direction.Text, Font, brush, OffsetRect(direction.TextRect, x, y), format);
					}
				}

				if (DetailsFilter.ShowVehicleModel && !node.VehicleMake.TextRect.IsEmpty)
				{
					g.DrawString(node.VehicleMake.Text, Font, brush, OffsetRect(node.VehicleMake.TextRect, x, y), format);
					g.DrawString(node.VehicleModel.Text, Font, brush, OffsetRect(node.VehicleModel.TextRect, x, y), format);
				}

				if (DetailsFilter.ShowTags && !node.Tags.TextRect.IsEmpty)
				{
					g.DrawString(node.Tags.Text, Font, brush, OffsetRect(node.Tags.TextRect, x, y), format);
				}

				if (!node.LicenseThumbRect.IsEmpty)
				{
					g.DrawImage(si.LicensePlate.Thumbnail, OffsetRect(node.LicenseThumbRect, x, y));
				}
				if (!node.LicensePlateWatchlistRect.TextRect.IsEmpty)
				{
					g.DrawString(node.LicensePlateWatchlistRect.Text, boldFont, brush, OffsetRect(node.LicensePlateWatchlistRect.TextRect, x, y), format);
				}
				if (!node.LicensePlate.TextRect.IsEmpty)
				{
					g.DrawString(node.LicensePlate.Text, Font, brush, OffsetRect(node.LicensePlate.TextRect, x, y), format);
				}
				if (DetailsFilter.ShowLPOrigin && !node.LicenseOrigin.TextRect.IsEmpty)
				{
					g.DrawString(node.LicenseOrigin.Text, Font, brush, OffsetRect(node.LicenseOrigin.TextRect, x, y), format);
				}
			}

			if (!node.AnalyticEvent.TextRect.IsEmpty)
			{
				g.DrawString(node.AnalyticEvent.Text, Font, brush, OffsetRect(node.AnalyticEvent.TextRect, x, y), format);
				g.DrawImage(node.AnalyticEvent.IsTripwire ? Properties.Resources.Tripwire : Properties.Resources.Polygon, node.AnalyticEvent.IconRect.X + x, node.AnalyticEvent.IconRect.Y + y);
			}

			if (!isSelected)
			{
				Color color = si.HasEvents && DetailsFilter.ShowAnalyticEventBorder ? node.AnalyticEventBorder.Value : Color.Black;
				using (var pen = new Pen(color, 2))
				{
					if (Orientation == Orientation.Vertical)
					{
						g.DrawLine(pen, x, y + node.Size.Height, x + node.Size.Width, y + node.Size.Height);
					}
					else
					{
						g.DrawLine(pen, x + node.Size.Width, y, x + node.Size.Width, y + node.Size.Height);
					}
				}
			}
		}

		private bool IsNodeVisible(ObjectNode node)
		{
			if (Orientation == Orientation.Vertical)
			{
				var scroll = VerticalScroll.Value;
				if (scroll >= (node.Offset + node.Size).Y)
				{
					return false;
				}
				else if (scroll + ClientSize.Height <= node.Offset.Y)
				{
					return false;
				}
			}
			else
			{
				var scroll = HorizontalScroll.Value;
				if (scroll > (node.Offset + node.Size).X)
				{
					return false;
				}
				else if (scroll + ClientSize.Width < node.Offset.X)
				{
					return false;
				}
			}

			return true;
		}

		#endregion

		#region Private static methods

		private static float GetScale(int targetWidth, int actualWidth, int targetHeight, int actualHeight)
		{
			return Math.Min((float)targetWidth / actualWidth, (float)targetHeight / actualHeight);
		}

		#endregion

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		private bool SetProperty<T>(ref T value, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!object.Equals(value, newValue))
			{
				value = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}

			return false;
		}

		#endregion
	}
}

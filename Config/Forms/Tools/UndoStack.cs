using System;
using System.Collections.Generic;

namespace Neurotec.Samples.Config.Forms.Tools
{
	public class UndoStack
	{
		#region Private fields

		private Stack<Tool> _stack = new Stack<Tool>();

		#endregion

		#region Public events

		public event EventHandler StackIsEmptyChanged;

		#endregion

		#region Public properties

		public bool IsEmpty
		{
			get => _stack.Count == 0;
		}

		#endregion

		#region Public methods

		public void Push(Tool value)
		{
			_stack.Push(value);
			if (_stack.Count == 1)
				StackIsEmptyChanged?.Invoke(this, EventArgs.Empty);
		}

		public Tool Pop()
		{
			var count = _stack.Count;
			if (count > 0)
			{
				var result = _stack.Pop();
				if (count == 1)
					StackIsEmptyChanged?.Invoke(this, EventArgs.Empty);
				return result;
			}
			return null;
		}

		public void Clear()
		{
			var count = _stack.Count;
			_stack.Clear();
			if (count > 0)
				StackIsEmptyChanged?.Invoke(this, EventArgs.Empty);
		}

		#endregion
	}
}

﻿// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.Commands.TextEditing;
using MfGames.Commands.TextEditing.Composites;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	public class SplitParagraphCommandFactory: TextEditingCommandFactory
	{
		#region Properties

		public override HierarchicalPath FactoryKey
		{
			get { return Key; }
		}

		/// <summary>
		/// Contains the key for the command provided by this factory.
		/// </summary>
		public static HierarchicalPath Key { get; private set; }

		#endregion

		#region Methods

		public override string GetTitle(
			CommandFactoryReference commandFactoryReference)
		{
			return "Split Paragraph";
		}

		protected override void Do(
			object context,
			CommandFactoryManager<OperationContext> commandFactory,
			object commandData,
			OperationContext operationContext,
			EditorViewController controller,
			IDisplayContext displayContext,
			TextPosition position)
		{
			// Create the command and execute it.
			var textPosition =
				new TextPosition(
					displayContext.Caret.Position.LinePosition,
					displayContext.Caret.Position.CharacterPosition);
			var splitCommand =
				new SplitParagraphCommand<OperationContext>(
					controller.CommandController, textPosition);

			controller.CommandController.Do(splitCommand, operationContext);

			// If we have a text position, we need to set it.
			if (operationContext.Results.HasValue)
			{
				displayContext.Caret.SetAndScrollToPosition(
					operationContext.Results.Value.TextPosition);
			}
		}

		#endregion

		#region Constructors

		static SplitParagraphCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Split Paragraph", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}

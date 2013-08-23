// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using GLib;

namespace MfGames.GtkExt.TextEditor.Renderers.Cache
{
	/// <summary>
	/// Background worker class that goes through the cached text renderer and
	/// caches each line.
	/// </summary>
	internal class BackgroundCachedLineUpdater
	{
		#region Methods

		/// <summary>
		/// Starts up the background thread, if needed, and triggers a reload
		/// on the lines.
		/// </summary>
		public void Restart()
		{
			// Set the flag so we loop through at least one more time.
			needRestart = true;

			// If we aren't running, then start it up again.
			if (!isRunning)
			{
				isRunning = true;
				Idle.Add(OnIdleUpdate);
			}
		}

		private bool OnIdleUpdate()
		{
			// Make sure we're identified as running.
			isRunning = true;

			// Keep track of when we started. UtcNow requires less CPU overhead
			// so we use that instead.
			DateTime started = DateTime.UtcNow;

			// Loop through the lines in the cache renderer and update each
			// one in turn. We restart at the last point we updated to make sure
			// we can get through all the lines in the short time we have in
			// this loop.
			for (; currentIndex < lines.Count;
				currentIndex++)
			{
				// Check to see if we exceeded our time yet.
				if ((DateTime.UtcNow - started) > maximumTime)
				{
					// We have to stop processing now, but we need to keep going.
					return true;
				}

				// Get the next line and check to see if it isn't cached. If it
				// isn't, then we need to cache it but also keep track so we
				// go through the lines again.
				CachedLine line = lines[currentIndex];

				if (!line.IsCached)
				{
					needRestart = true;
					line.Cache(renderer, currentIndex);
				}
			}

			// If we need to restart, then cycle through it again.
			if (needRestart)
			{
				needRestart = false;
				currentIndex = 0;
				return true;
			}

			// If we got this far, we have completely gone through the lines
			// without updating any of them. To avoid the overhead of calling
			// this repeatedly, we return false and will restart later.
			isRunning = false;
			return false;
		}

		#endregion

		#region Constructors

		public BackgroundCachedLineUpdater(
			CachedTextRenderer renderer,
			CachedLineList lines)
		{
			this.renderer = renderer;
			this.lines = lines;

			needRestart = true;
			maximumTime = TimeSpan.FromMilliseconds(13);
		}

		#endregion

		#region Fields

		private int currentIndex;
		private bool isRunning;
		private readonly CachedLineList lines;
		private readonly TimeSpan maximumTime;
		private bool needRestart;
		private readonly CachedTextRenderer renderer;

		#endregion
	}
}

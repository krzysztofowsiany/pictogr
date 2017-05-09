using System;
using System.Collections.Generic;

namespace PictOgr.Core.Domain
{
	public class CompositionName
	{
		public List<NameModule> NameModuoles { get; }
		public Guid CompositionId { get; private set; }

		public CompositionName(Guid compositionId)
		{
			NameModuoles = new List<NameModule>();
			SetCompositionId(compositionId);
		}

		private void SetCompositionId(Guid compositionId)
		{
			CompositionId = compositionId;
		}
	}
}

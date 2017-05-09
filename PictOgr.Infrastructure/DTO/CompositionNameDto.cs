using System;
using System.Collections.Generic;

namespace PictOgr.Infrastructure.DTO
{
	public class CompositionNameDto
	{
		public List<NameModuleDto> NameModuoles { get; set; }
		public Guid CompositionId { get; set; }
	}
}

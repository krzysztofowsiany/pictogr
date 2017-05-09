using System;
using PictOgr.Core.Domain;

namespace PictOgr.Infrastructure.DTO
{
	public class NameModuleDto
	{
		public ModuleType ModuleType { get; set; }
		public string Name { get; set; }
		public Guid NameModuleId { get; set; }
	}
}

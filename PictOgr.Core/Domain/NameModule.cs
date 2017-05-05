using System;

namespace PictOgr.Core.Domain
{
	public class NameModule
	{
		public ModuleType ModuleType { get; private set; }
		public string Name { get; private set; }
		public Guid NameModuleId { get; private set; }

		public NameModule(string name, Guid nameModuleId, ModuleType moduleType)
		{
			ModuleType = moduleType;
			Name = name;
			NameModuleId = nameModuleId;
		}
	}
}

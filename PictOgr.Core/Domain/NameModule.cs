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
			SetModuleType(moduleType);
			SetName(name);
			SetModuleId(nameModuleId);

			ModuleType = moduleType;
			Name = name;
			NameModuleId = nameModuleId;
		}

		private void SetModuleId(Guid nameModuleId)
		{
			NameModuleId = nameModuleId;
		}

		private void SetName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new Exception("Name must be set.");
			}

			Name = name;
		}

		private void SetModuleType(ModuleType moduleType)
		{
			ModuleType = moduleType;
		}
	}
}

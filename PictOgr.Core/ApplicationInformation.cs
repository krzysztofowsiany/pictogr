namespace PictOgr.Core
{
	public class ApplicationInformation
	{
		public ApplicationInformation(string version)
		{
			Version = version;
		}

		public string Version { get; private set; }
	}
}
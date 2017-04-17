﻿using Autofac;
using Autofac.Extras.NLog;

namespace PictOgr.Core
{
	public class CoreModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			
			builder.RegisterModule<NLogModule>();


		}
	}
}

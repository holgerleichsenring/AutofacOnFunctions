﻿using Autofac;
using AutofacOnFunctions.Sample.Services.Functions;

namespace AutofacOnFunctions.Sample.Services.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIt>().As<ITestIt>();
        }
    }
}

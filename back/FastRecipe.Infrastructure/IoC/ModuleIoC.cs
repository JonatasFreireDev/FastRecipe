using Autofac;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FastRecipe.Infrastructure.IoC
{
    public class ModuleIoC : Module
    {
        private static IEnumerable<IConfigurationSection> _configurationSections { get; set; }

        public ModuleIoC(IEnumerable<IConfigurationSection> configurations)
            : base()
        {
            _configurationSections = configurations;
        }

        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoC.Load(builder, _configurationSections);
        }
    }
}

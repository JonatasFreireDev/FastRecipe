using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace FastRecipe.API.Configurations
{
    public class DefaultApplicationRouteConvention : IApplicationModelConvention
    {
        private readonly string _versionedControllerTemplate;
        private readonly string _ConstraintRoutePrefix;
        private readonly string _ConstraintDefaultVersion;

        public DefaultApplicationRouteConvention()
        {
            _ConstraintRoutePrefix = "api";
            _ConstraintDefaultVersion = "v1";
            _versionedControllerTemplate = $"{_ConstraintRoutePrefix}/{_ConstraintDefaultVersion}/[controller]";
        }

        public void Apply(ApplicationModel application)
        {
            if (application is null) throw new ArgumentNullException(nameof(application), "Parameter were not loaded correctly");

            foreach (var controller in application.Controllers)
            {
                foreach (var selector in controller.Selectors)
                {
                    if (selector.AttributeRouteModel is null == false)
                    {
                        selector.AttributeRouteModel = new AttributeRouteModel
                        {
                            Template = $"{_ConstraintRoutePrefix}/{selector.AttributeRouteModel.Template}/[controller]"
                        };
                    }
                    else
                    {
                        selector.AttributeRouteModel = new AttributeRouteModel
                        {
                            Template = _versionedControllerTemplate
                        };
                    }
                }
            }
        }
    }
}

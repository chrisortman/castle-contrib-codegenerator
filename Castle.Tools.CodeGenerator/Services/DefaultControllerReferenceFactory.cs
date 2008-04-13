using System;
using Castle.Tools.CodeGenerator.Model;

namespace Castle.Tools.CodeGenerator.Services
{
	public class DefaultControllerReferenceFactory : IControllerReferenceFactory
	{
		public IControllerActionReference CreateActionReference(ICodeGeneratorServices services, Type controllerType,
		                                                        string areaName, string controllerName, string actionName,
		                                                        MethodSignature signature,
		                                                        params ActionArgument[] arguments)
		{
			return new ControllerActionReference(services, controllerType, areaName, controllerName, actionName, signature, arguments);
		}

		public IControllerViewReference CreateViewReference(ICodeGeneratorServices services, Type controllerType,
															string areaName, string controllerName, string actionName)
		{
			return new ControllerViewReference(services, controllerType, areaName, controllerName, actionName);
		}
	}
}
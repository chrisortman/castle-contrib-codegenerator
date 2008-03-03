using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using Castle.MonoRail.Framework;
using Castle.MonoRail.Framework.Routing;

namespace Castle.Tools.CodeGenerator.Model
{
	[DebuggerDisplay("StaticRoute {url}")]
	public class StaticRoute : IRoutingRule
	{
		private readonly string routeName;
		private readonly string area;
		private readonly string controller;
		private readonly string action;
		private readonly string url;
		private readonly string[] routeParts;

		public StaticRoute(string routeName, string url, string area, string controller, string action)
		{
			this.routeName = routeName;
			this.url = url;
			this.area = area;
			this.controller = controller;
			this.action = action;

			routeParts = GetParts(url);
		}

		public string RouteName
		{
			get { return routeName; }
		}

		public string CreateUrl(string hostname, string virtualPath, IDictionary parameters, out int points)
		{
			points = 0;
			if ((parameters["area"] != area) || (parameters["controller"] != controller) || (parameters["action"] != action))
				return null;

			StringBuilder text = new StringBuilder(virtualPath);

			foreach (string part in routeParts)
			{
				AppendSlash(text);

				text.Append(part);
			}

			AppendSlash(text);

			points = 100;
			return text.ToString();
		}

		public int Matches(string url, IRouteContext context, RouteMatch match)
		{
			string[] parts = GetParts(url);

			if (parts.Length != routeParts.Length)
			{
				return 0;
			}

			for (int i = 0; i < parts.Length; i++)
			{
				if (string.Compare(parts[i], routeParts[i], true) != 0)
				{
					return 0;
				}
			}

			match.Parameters.Add("area", area);
			match.Parameters.Add("controller", controller);
			match.Parameters.Add("action", action);

			return 100;
		}

		private static void AppendSlash(StringBuilder text)
		{
			if (text.Length == 0 || text[text.Length - 1] != '/')
			{
				text.Append('/');
			}
		}

		private static string[] GetParts(string url)
		{
			return url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}

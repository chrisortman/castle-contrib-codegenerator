// Copyright 2004-2007 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Tools.CodeGenerator.Services
{
	using Model.TreeNodes;
	using NUnit.Framework;

	[TestFixture]
	public class ControllerPartialsGeneratorControllerTests : ControllerPartialsGeneratorTests
	{
		[Test]
		public void VisitControllerNode_Always_CreatesType()
		{
			var node = new ControllerTreeNode("HomeController", "ControllerNamespace");

			mocks.ReplayAll();
			generator.Visit(node);
			mocks.VerifyAll();

			CodeDomAssert.AssertHasProperty(source.Ccu.Namespaces[0].Types[0], "MyActions");
			CodeDomAssert.AssertHasProperty(source.Ccu.Namespaces[0].Types[0], "MyViews");
			CodeDomAssert.AssertHasProperty(source.Ccu.Namespaces[0].Types[0], "MyRoutes");
			CodeDomAssert.AssertHasMethod(source.Ccu.Namespaces[0].Types[0], "PerformGeneratedInitialize");
		}
	}
}
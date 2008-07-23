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

using Castle.Tools.CodeGenerator.Services.Visitors;

namespace Castle.Tools.CodeGenerator.Services
{
	using System;
	using System.Collections.Generic;
	using ICSharpCode.NRefactory.Ast;
	using NUnit.Framework;

	[TestFixture]
	public class TypeResolvingVisitorTests
	{
		[Test]
		public void VisitingNamespace_MustAddParentNamespacesToTypeResolver()
		{
			var typeTables = new List<TypeTableEntry>();
			var usings = new List<String>();
			var aliases = new Dictionary<string, string>();
			var resolver = new TypeResolver(typeTables, usings, aliases);
			var nsDecl = new NamespaceDeclaration("System.Collections.Specialized");
			var visitor = new TypeResolvingVisitor(resolver);

			visitor.VisitNamespaceDeclaration(nsDecl, null);

			Assert.AreEqual(3, usings.Count);
		}
	}
}
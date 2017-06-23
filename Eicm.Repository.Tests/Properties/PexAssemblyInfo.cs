// <copyright file="PexAssemblyInfo.cs">Copyright ©  2017</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("Eicm.Repository")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("EntityFramework")]
[assembly: PexInstrumentAssembly("NLog")]
[assembly: PexInstrumentAssembly("Eicm.Core")]
[assembly: PexInstrumentAssembly("Eicm.DataLayer")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EntityFramework")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "NLog")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Eicm.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Eicm.DataLayer")]


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGN.ReflectionAssert.Tests
{
    [TestClass]
    public class MGNReflectionAssertAssemblyUnitTests : UnitTestsBase
    {
        [TestMethod]
        public void MGNReflectionAssertDllAssemblyShouldExist()
        {
            GetAssembly();
        }

        [TestMethod]
        public void ReflectionAssertTypeShouldExist()
        {
            GetType(
                typeName: typeName,
                shouldBeStatic: true
                );
        }
    }
}

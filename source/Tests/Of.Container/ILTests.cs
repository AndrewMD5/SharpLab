using System.Threading.Tasks;
using SharpLab.Server.Common;
using SharpLab.Tests.Internal;
using SharpLab.Tests.Of.Container.Internal;
using Xunit;

namespace SharpLab.Tests.Of.Container {
    [Collection(TestCollectionNames.Execution)]
    public class ILTests {
        [Fact]
        public async Task IL_Simple() {
            var code = @"
                .assembly ConsoleApp
                {
                }

                .class private auto ansi abstract sealed beforefieldinit Program
                    extends [System.Private.CoreLib]System.Object
                {
                    .method private hidebysig static void Main (string[] args) cil managed 
                    {
                        .maxstack 8
                        .entrypoint

                        ldstr ""🌄""
                        call void [System.Console]System.Console::Write(string)
                        ret
                    }
                }
            ";

            var output = await ContainerTestDriver.CompileAndExecuteAsync(code, LanguageNames.IL);

            Assert.Equal("🌄", output);
        }
    }
}

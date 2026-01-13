using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.Dados.ClubeEstrutura;
using ClubeFutebol.Regras;

namespace ClubeFutebol.Tests.Regras
{
    [TestClass]
    public class RegrasClubeTests
    {
        [TestMethod]
        public void CriarClube_ClubeValido_RetornaTrue()
        {
            // Arrange
            var dados = new ClubeDados();
            var regras = new RegrasClube(dados);

            var clube = new Clube(
                "Gil Vicente",
                2000,
                "gilvicente@alunos.ipca.pt",
                123456789,
                "Portugal"
            );

            // Act
            bool resultado = regras.CriarClube(clube);

            // Assert
            Assert.IsTrue(resultado);
            Assert.AreEqual(1, dados.ListarClubes().Count);
        }
    }
}


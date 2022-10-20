using System;
using Xunit;
using NewTalents;

namespace TestProject1
{
    public class UnitTest1
    {

        public Calculadora construirClasse()
        {
            string data = "20/10/2022";
            Calculadora calc = new Calculadora();
            return calc;
        }

        [Theory]
        [InLineData (1, 2, 3)]
        [InLineData (4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();
                
            int resultadoCalculadora = calc.somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);

        }
        [Theory]
        [InLineData(2, 1, 1)]
        [InLineData(6, 4, 2)]
        public void TesteSubitrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.subitrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);

        }
        [Theory]
        [InLineData(1, 2, 2)]
        [InLineData(4, 5, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);

        }
        [Theory]
        [InLineData(2, 1, 2)]
        [InLineData(10, 2, 5)]
        public void TesteDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);

        }
        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = construirClasse();
            Assert.Throws<DivideByZeroException>(
                () => calc.dividir(3, 0)
            );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();

            calc.somar = (1, 2);
            calc.somar = (2, 8);
            calc.somar = (3, 7);
            calc.somar = (4, 1);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }

    }
}

/*
*	<copyright file="FinancasRegras.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;
using ClubeFutebol.Exceptions;
using System.IO;

namespace ClubeFutebol.Regras
{
    public class RegrasFinancas
    {
        #region Atributos

        private readonly InterfaceFinancasDados financasDados;   // acesso aos dados financeiros

        #endregion

        #region Construtor

        public RegrasFinancas(InterfaceFinancasDados financasDados)   // injecao da camada de dados
        {
            this.financasDados = financasDados;
        }

        #endregion

        #region Saldo e Orçamentos

        public bool AtualizarSaldo(Clube clube, float valor)    // atualiza o saldo do clube
        {
            if (clube == null)                  // se o clube nao existir
                return false;

            if (valor < 0)                      // saldo nao pode ser negativo
                throw new ValorInvalidoException("Saldo");

            return financasDados.AtualizarSaldo(clube, valor);
        }

        public bool AtualizarOrcamentoSalarios(Clube clube, float valor)   // atualiza orcamento de salarios
        {
            if (clube == null)
                return false;

            if (valor < 0)                      // orcamento invalido
                throw new ValorInvalidoException("Orçamento de Salários");

            if (valor + clube.Financas.OrcamentoTransferencias > clube.Financas.SaldoClube)
                throw new SaldoInsuficienteException();          // nao pode ultrapassar o saldo

            return financasDados.AtualizarOrcamentoSalarios(clube, valor);
        }

        public bool AtualizarOrcamentoTransferencias(Clube clube, float valor)   // atualiza orcamento de transferencias
        {
            if (clube == null)
                return false;

            if (valor < 0)
                throw new ValorInvalidoException("Orçamento de Transferências");

            if (clube.Financas.OrcamentoSalarios + valor > clube.Financas.SaldoClube)
                throw new SaldoInsuficienteException();

            return financasDados.AtualizarOrcamentoTransferencias(clube, valor);
        }

        #endregion

        #region Salários

        public bool DefinirSalario(Clube clube, Pessoa pessoa, float valor)   // define salario de uma pessoa
        {
            if (clube == null || pessoa == null)
                return false;

            if (valor <= 0)
                throw new ValorInvalidoException("Salário");

            if (valor > clube.Financas.OrcamentoSalarios)
                throw new OrcamentoInsuficienteException();     // ultrapassa orcamento

            if (valor > clube.Financas.SaldoClube)
                throw new SaldoInsuficienteException();         // ultrapassa saldo

            return financasDados.DefinirSalario(clube, pessoa, valor);
        }

        public bool RemoverSalario(Clube clube, Pessoa pessoa)   // remove salario da pessoa
        {
            if (clube == null || pessoa == null)
                return false;

            return financasDados.RemoverSalario(clube, pessoa);
        }

        #endregion

        #region Transferências

        public bool ComprarPessoa(Clube clube, Pessoa pessoa, float valorMercado)   // compra uma pessoa
        {
            if (clube == null || pessoa == null)
                return false;

            if (valorMercado <= 0)
                throw new ValorInvalidoException("Valor de Mercado");

            if (valorMercado > clube.Financas.SaldoClube)
                throw new SaldoInsuficienteException();

            if (valorMercado > clube.Financas.OrcamentoTransferencias)
                throw new OrcamentoInsuficienteException();

            financasDados.AtualizarSaldo(clube, clube.Financas.SaldoClube - valorMercado);
            financasDados.AtualizarOrcamentoTransferencias(
                clube, clube.Financas.OrcamentoTransferencias - valorMercado);

            return financasDados.DefinirValorMercado(clube, pessoa, valorMercado);
        }

        public bool VenderPessoa(Clube clube, Pessoa pessoa, float valorMercado)   // vende uma pessoa
        {
            if (clube == null || pessoa == null)
                return false;

            if (valorMercado <= 0)
                throw new ValorInvalidoException("Valor de Mercado");

            financasDados.AtualizarSaldo(clube, clube.Financas.SaldoClube + valorMercado);
            return financasDados.RemoverValorMercado(clube, pessoa);
        }

        #endregion

        #region Ficheiros

        public bool GuardarDados(string ficheiro)   // guarda os dados financeiros
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return financasDados.GuardarFinancas(ficheiro);
        }

        public bool LerDados(string ficheiro)   // le os dados financeiros
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            if (!File.Exists(ficheiro))
                return false;

            return financasDados.LerFinancas(ficheiro);
        }

        #endregion
    }
}
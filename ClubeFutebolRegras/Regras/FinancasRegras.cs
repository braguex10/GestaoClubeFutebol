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
    /// <summary>
    /// Camada de Dados responsável pela Validação das finanças do clube
    /// </summary>
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
        /// <summary>
        /// Veriifica a atualização de saldo
        /// </summary>
        public bool AtualizarSaldo(Clube clube, float valor)    // atualiza o saldo do clube
        {
            if (clube == null)                  // se o clube nao existir
                return false;

            if (valor < 0)                      // saldo nao pode ser negativo
                throw new ValorInvalidoException("Saldo");

            return financasDados.AtualizarSaldo(clube, valor);
        }
        /// <summary>
        /// Valida a atualização de orçamento para salários
        /// </summary>
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
        /// <summary>
        /// Valida a atualização de orçamento para transferências
        /// </summary>
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
        /// <summary>
        /// Valida a definição do salário
        /// </summary>
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
        /// <summary>
        /// Valida a remoção de salário
        /// </summary>
        public bool RemoverSalario(Clube clube, Pessoa pessoa)   // remove salario da pessoa
        {
            if (clube == null || pessoa == null)
                return false;

            return financasDados.RemoverSalario(clube, pessoa);
        }

        #endregion

        #region Transferências
        /// <summary>
        /// Valida a possibilidade de comprar certa pessoas
        /// </summary>
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
        /// <summary>
        /// Valida a possibilidade de vender pessoa
        /// </summary>
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
        /// <summary>
        /// Valida os dados de finanças de clube a serem guardados
        /// </summary>
        public bool GuardarDados(string ficheiro)   // guarda os dados financeiros
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return financasDados.GuardarFinancas(ficheiro);
        }
        /// <summary>
        /// Valida a leitura de ficheiro das finanças do clube
        /// </summary>
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
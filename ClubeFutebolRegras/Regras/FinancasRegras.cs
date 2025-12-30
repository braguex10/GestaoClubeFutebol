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

        private readonly InterfaceFinancasDados financasDados;

        #endregion

        #region Construtor

        public RegrasFinancas(InterfaceFinancasDados financasDados)
        {
            this.financasDados = financasDados;
        }

        #endregion

        #region Gestão Geral

        public bool InserirFinancas(Financas f)
        {
            if (f == null)
                return false;

            return financasDados.InserirFinancas(f);
        }

        public bool RemoverFinancas(Financas f)
        {
            if (f == null)
                return false;

            // regra: não remover se houver salários associados
            if (financasDados.TotalSalarios(f) > 0)
                return false;

            return financasDados.RemoverFinancas(f);
        }

        #endregion

        #region Saldo e Orçamentos

        public bool AtualizarSaldo(Financas f, float valor)
        {
            if (f == null)
                return false;

            if (!financasDados.ExisteFinancas(f))
                return false;

            if (valor < 0)
                throw new ValorInvalidoException("Saldo");

            return financasDados.AtualizarSaldo(f, valor);
        }

        public bool AtualizarOrcamentoSalarios(Financas f, float valor)
        {
            if (f == null)
                return false;

            if (!financasDados.ExisteFinancas(f))
                return false;

            if (valor < 0)
                throw new ValorInvalidoException("Orçamento de Salários");

            // regra: novo orçamento + transferências não pode ultrapassar o saldo
            if (valor + f.OrcamentoTransferencias > f.SaldoClube)
                throw new SaldoInsuficienteException();

            return financasDados.AtualizarOrcamentoSalarios(f, valor);
        }

        public bool AtualizarOrcamentoTransferencias(Financas f, float valor)
        {
            if (f == null)
                return false;

            if (!financasDados.ExisteFinancas(f))
                return false;

            if (valor < 0)
                throw new ValorInvalidoException("Orçamento de Transferências");

            // regra: salários + novo orçamento não pode ultrapassar o saldo
            if (f.OrcamentoSalarios + valor > f.SaldoClube)
                throw new SaldoInsuficienteException();

            return financasDados.AtualizarOrcamentoTransferencias(f, valor);
        }

        #endregion

        #region Salários

        public bool DefinirSalario(Financas f, Pessoa p, float valor)
        {
            if (f == null || p == null)
                return false;

            if (!financasDados.ExisteFinancas(f))
                return false;

            if (valor <= 0)
                throw new ValorInvalidoException("Salário");

            // regra: salário não pode ultrapassar orçamento
            if (valor > f.OrcamentoSalarios)
                throw new OrcamentoInsuficienteException();

            // regra: salário não pode ultrapassar saldo
            if (valor > f.SaldoClube)
                throw new SaldoInsuficienteException();

            return financasDados.DefinirSalario(f, p, valor);
        }

        public bool RemoverSalario(Financas f, Pessoa p)
        {
            if (f == null || p == null)
                return false;

            if (!financasDados.ExisteFinancas(f))
                return false;

            return financasDados.RemoverSalario(f, p);
        }

        #endregion

        #region Transferências

        public bool ComprarPessoa(Financas f, Pessoa p, float valorMercado)
        {
            if (f == null || p == null)
                return false;

            if (!financasDados.ExisteFinancas(f))
                return false;

            if (valorMercado <= 0)
                throw new ValorInvalidoException("Valor de Mercado");

            if (valorMercado > f.SaldoClube)
                throw new SaldoInsuficienteException();

            if (valorMercado > f.OrcamentoTransferencias)
                throw new OrcamentoInsuficienteException();

            // debitar saldo e orçamento
            financasDados.AtualizarSaldo(f, f.SaldoClube - valorMercado);
            financasDados.AtualizarOrcamentoTransferencias(
                f, f.OrcamentoTransferencias - valorMercado);

            financasDados.DefinirValorMercado(f, p, valorMercado);
            return true;
        }

        public bool VenderPessoa(Financas f, Pessoa p, float valorMercado)
        {
            if (f == null || p == null)
                return false;

            if (!financasDados.ExisteFinancas(f))
                return false;

            if (valorMercado <= 0)
                throw new ValorInvalidoException("Valor de Mercado");

            // creditar saldo
            financasDados.AtualizarSaldo(f, f.SaldoClube + valorMercado);
            financasDados.RemoverValorMercado(f, p);

            return true;
        }

        #endregion

        #region Ficheiros

        public bool GuardarDados(string ficheiro)
        {
            if (string.IsNullOrWhiteSpace(ficheiro))
                return false;

            return financasDados.GuardarFinancas(ficheiro);
        }

        public bool LerDados(string ficheiro)
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

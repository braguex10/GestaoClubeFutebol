/*
*	<copyright file="InterfaceFinancasDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;

namespace ClubeFutebol.Dados.Interfaces
{
    public interface InterfaceFinancasDados
    {
        #region Gestão Geral

        bool InserirFinancas(Financas f);
        bool RemoverFinancas(Financas f);
        bool ExisteFinancas(Financas f);

        #endregion

        #region Saldo e Orçamentos

        bool AtualizarSaldo(Financas f, float valor);
        bool AtualizarOrcamentoSalarios(Financas f, float valor);
        bool AtualizarOrcamentoTransferencias(Financas f, float valor);

        #endregion

        #region Salários

        bool DefinirSalario(Financas f, Pessoa p, float valor);
        bool RemoverSalario(Financas f, Pessoa p);
        float ObterSalario(Financas f, Pessoa p);
        float TotalSalarios(Financas f);

        #endregion

        #region Valores de Mercado

        bool DefinirValorMercado(Financas f, Pessoa p, float valor);
        bool RemoverValorMercado(Financas f, Pessoa p);
        float ObterValorMercado(Financas f, Pessoa p);

        #endregion

        bool GuardarFinancas(string ficheiro);
        bool LerFinancas(string ficheiro);
    }
}
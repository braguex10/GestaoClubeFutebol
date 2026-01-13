/*
*	<copyright file="~Financas.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.BOO.ClubeEstrutura
{
    [Serializable]
    public class Financas
    {
        #region Atributos

        float saldoClube;                     // dinheiro do clube
        float orcamentoSalarios;              // limites financeiros do clube
        float orcamentoTransferencias;        //         ""

        #endregion

        #region Construtores

        public Financas()                   // inicializado os atributos, com os valores todos zero
        {
            saldoClube = 0f;
            orcamentoSalarios = 0f;
            orcamentoTransferencias = 0f;
        }

        public Financas(float saldoClube, float orcamentoSalarios, float orcamentoTransferencias)   // atribuidos valores aos atributos
        {
            SaldoClube = saldoClube;
            OrcamentoSalarios = orcamentoSalarios;
            OrcamentoTransferencias = orcamentoTransferencias;
        }

        #endregion

        #region Propriedades

        public float SaldoClube
        {
            get { return saldoClube; }
            set { saldoClube = value; }
        }

        public float OrcamentoSalarios
        {
            get { return orcamentoSalarios; }
            set { orcamentoSalarios = value; }
        }

        public float OrcamentoTransferencias
        {
            get { return orcamentoTransferencias; }
            set { orcamentoTransferencias = value; }
        }

        #endregion

        #region Overrides

        public override string ToString()  // como as financas do clube sao representadas em texto
        {
            return $"Saldo: {saldoClube} | Salários: {orcamentoSalarios} | Transferências: {orcamentoTransferencias}";
        }

        #endregion
    }
}